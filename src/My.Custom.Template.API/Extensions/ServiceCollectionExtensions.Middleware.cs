using My.Custom.Template.API.Middlewares;

namespace My.Custom.Template.API.Extensions;

public static partial class ServiceCollectionExtensions
{
    private static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ApiMiddleware>();

        return services;
    }
}