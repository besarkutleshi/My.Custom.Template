using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace My.Custom.Template.Infrastructure.Extensions.ServiceCollections;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEF(configuration);
        services.AddDI();

        return services;
    }
}