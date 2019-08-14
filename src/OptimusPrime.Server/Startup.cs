using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OptimusPrime.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //if (env.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration = builder.Build();
        }

        /* This method gets called by the runtime. Use this method to add services to the container. */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Persistences.OptimusPrimeDbContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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

            //TODO Set options
            // var options = Configuration.Get<OtimusPrimeOptions>();

            if (true)//options.RunMigrationsAtStartup)
            {
                // Applying database migrations.
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
            if (migrations.Count() > 0)
            {
                Extensions.ConsoleExtension.PrintLine($"Running pending {migrations.Count()} migrations:", ConsoleColor.White, ConsoleColor.Red);
                migrations.ForEach(migration => {
                    Extensions.ConsoleExtension.PrintLine($" - {migration}", ConsoleColor.Red);
                });
                db.Database.Migrate();
                Extensions.ConsoleExtension.PrintLine("Migration process done!", ConsoleColor.White, ConsoleColor.Red);
            }
            else
            {
                Extensions.ConsoleExtension.PrintLine("No migrations pending!", ConsoleColor.White, ConsoleColor.Red);
            }
        }
    }
}
