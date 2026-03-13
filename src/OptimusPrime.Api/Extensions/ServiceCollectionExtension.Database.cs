using Microsoft.EntityFrameworkCore;
using OptimusPrime.Infrastructure.Persistence.Options;

namespace OptimusPrime.Api.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseOptions = configuration.GetSection(DatabaseOptions.Database)
            .Get<DatabaseOptions>();

        if (databaseOptions is null)
        {
            throw new InvalidOperationException($"Unsupported database configuration");
        }

        services.AddDbContext<Infrastructure.Persistence.OptimusPrimeDbContext>((options) =>
        {
            var provider = databaseOptions.Provider.Name;
            if (provider == Provider.Sqlite.Name)
            {
                options.UseSqlite(
                    configuration.GetConnectionString(Provider.Sqlite.Name)!
                );
            }
            else
            {
                throw new InvalidOperationException($"Unsupported database provider: {provider}");
            }
        });

        return services;
    }
}
