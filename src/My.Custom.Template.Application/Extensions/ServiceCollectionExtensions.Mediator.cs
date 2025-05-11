using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace My.Custom.Template.Application.Extensions;

public static partial class ServiceCollectionExtensions
{
    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}