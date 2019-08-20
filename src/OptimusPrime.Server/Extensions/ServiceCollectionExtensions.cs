using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptimusPrime.Server.Configuration;
using OptimusPrime.Server.Configuration.Options;

namespace OptimusPrime.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureOptimusPrime(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureAndValidate<OptimusPrimeOptions>(configuration);
            services.ConfigureAndValidate<DatabaseOptions>(configuration.GetSection(nameof(OptimusPrimeOptions.Database)));

            return services;
        }

        public static IServiceCollection ConfigureAndValidate<TOptions>(
            this IServiceCollection services,
            IConfiguration config)
          where TOptions : class
        {
            services.Configure<TOptions>(config);
            services.AddSingleton<IPostConfigureOptions<TOptions>, ValidatePostConfigureOptions<TOptions>>();

            return services;
        }
    }
}
