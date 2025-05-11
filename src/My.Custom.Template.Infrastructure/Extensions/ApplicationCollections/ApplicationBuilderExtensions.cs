using Microsoft.AspNetCore.Builder;

namespace My.Custom.Template.Infrastructure.Extensions.ApplicationCollections;

public static partial class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddInfrastructureApplicationConfigurations(this IApplicationBuilder app)
    {
        RunDbMigration(app);

        return app;
    }
}
