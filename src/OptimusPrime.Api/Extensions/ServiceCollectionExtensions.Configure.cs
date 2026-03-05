namespace OptimusPrime.Api.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(options => configuration.GetSection(DatabaseOptions.Database).Bind(options));

        return services;
    }
}