using MediatR;
using Microsoft.Extensions.DependencyInjection;
using My.Custom.Template.Application.Behaviours;
using My.Custom.Template.Common.Helpers;

namespace My.Custom.Template.Application.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDI(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped<IRequestService, RequestService>();

        return services;
    }
}
