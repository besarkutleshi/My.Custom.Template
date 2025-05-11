using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using My.Custom.Template.Infrastructure.Persistence;

namespace My.Custom.Template.Infrastructure.Extensions.ServiceCollections;

public static partial class ServiceCollectionExtensions
{
    private static IServiceCollection AddEF(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DbName")
            ?? throw new ArgumentException("DbName connection string is missing");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 2,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null!);
            }));

        return services;
    }
}
