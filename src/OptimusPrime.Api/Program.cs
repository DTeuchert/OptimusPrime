using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OptimusPrime.Api.Extensions;
using OptimusPrime.Infrastructure.Persistence;
using OptimusPrime.Infrastructure.Persistence.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddConfigurations(builder.Configuration)
    .AddDatabaseConfiguration(builder.Configuration)
    .AddRepositories()
    .AddMediator(options =>
    {
        options.ServiceLifetime = ServiceLifetime.Scoped;
    })
    .AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

#region Apply database migration and seeding
using (var scope = app.Services.CreateScope())
{
    var databaseOptions = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var db = scope.ServiceProvider.GetRequiredService<OptimusPrimeDbContext>();

    if (databaseOptions.RunMigrationsAtStartup)
    {
        try
        {
            var migrations = db.Database.GetPendingMigrations().ToList();
            if (migrations.Any())
            {
                logger.LogInformation("Running {Count} pending migrations", migrations.Count);
                migrations.ForEach(migration => logger.LogInformation(" - {Migration}", migration));
                db.Database.Migrate();
                logger.LogInformation("Migration process done");
            }
            else
            {
                logger.LogInformation("No pending migrations");
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error during migration");
        }
    }
}
#endregion

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
