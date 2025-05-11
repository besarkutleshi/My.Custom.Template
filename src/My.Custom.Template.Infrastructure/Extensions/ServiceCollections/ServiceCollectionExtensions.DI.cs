using Microsoft.Extensions.DependencyInjection;
using My.Custom.Template.Common;
using My.Custom.Template.Infrastructure.Repositories;

namespace My.Custom.Template.Infrastructure.Extensions.ServiceCollections;

public static partial class ServiceCollectionExtensions
{
    private static IServiceCollection AddDI(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        return services;
    }
}
