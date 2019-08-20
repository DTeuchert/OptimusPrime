using System;
using System.Linq;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OptimusPrime.Server.Configuration.Options;
using OptimusPrime.Server.Extensions;
using OptimusPrime.Server.GraphQL;

namespace OptimusPrime.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /* This method gets called by the runtime. Use this method to add services to the container. */
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureOptimusPrime(Configuration);

            #region Database
            services.AddHealthChecks()
                .AddDbContextCheck<Persistences.OptimusPrimeDbContext>();
            services.AddDbContext<Persistences.OptimusPrimeDbContext>((provider, options) =>
                {
                    var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();
                    options.UseSqlite(databaseOptions.Value.ConnectionString);
                });
            #endregion

            #region GraphQL
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<OptimusPrimeSchema>();
            services.AddGraphQL(option =>
                {
                    option.ExposeExceptions = true; //set true only in development mode. make it switchable.)
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OptimusPrime API", Version = "v1" });
            });

            services.AddScoped<Repositories.ITransformerRepository, Repositories.TransformerRepository>();
            services.AddScoped<Services.IPrimeService, Services.PrimeService>();
        }

        /* This method gets called by the runtime. Use this method to configure the HTTP request pipeline. */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            #region Migrations
            var options = Configuration.Get<OptimusPrimeOptions>();
            if (options.RunMigrationsAtStartup)
            {
                /* Applying database migrations. */
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        EnsureDataStorageIsReady(services);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Startup>>();
                        logger.LogError(ex, "An error occurred while migrating the database.");
                    }
                }
            }
            #endregion

            app.UseGraphQL<OptimusPrimeSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "OptimusPrime API V1");
            });

            app.UseHealthChecks("/ready");

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Running database migrations.
        /// </summary>
        /// <param name="services"></param>
        private static void EnsureDataStorageIsReady(IServiceProvider services)
        {
            var db = services.GetService<Persistences.OptimusPrimeDbContext>();
            var migrations = db.Database.GetPendingMigrations().ToList();
            if (migrations.Count > 0)
            {
                ConsoleExtension.PrintLine($"Running pending {migrations.Count} migrations:", ConsoleColor.White, ConsoleColor.Red);
                migrations.ForEach(migration =>
                {
                    ConsoleExtension.PrintLine($" - {migration}", ConsoleColor.Red);
                });
                db.Database.Migrate();
                ConsoleExtension.PrintLine("Migration process done!", ConsoleColor.White, ConsoleColor.Red);
            }
            else
            {
                ConsoleExtension.PrintLine("No migrations pending!", ConsoleColor.White, ConsoleColor.Red);
            }
        }
    }
}
