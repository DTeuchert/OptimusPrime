using OptimusPrime.Domain.Repositories;
using OptimusPrime.Infrastructure.Repositories;

namespace OptimusPrime.Api.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITransformerRepository, TransformerRepository>();
        
        return services;
    }
}
