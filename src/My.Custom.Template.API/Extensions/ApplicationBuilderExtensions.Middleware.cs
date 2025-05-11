using My.Custom.Template.API.Middlewares;

namespace My.Custom.Template.API.Extensions;

public static partial class ApplicationBuilderExtensions
{
    private static IApplicationBuilder UseServiceMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiMiddleware>();
        app.UseMiddleware<RequestLogContextMiddleware>();

        return app;
    }
}