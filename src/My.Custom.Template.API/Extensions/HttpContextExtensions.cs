using System.Net;
using System.Text.Json;

namespace My.Custom.Template.API.Extensions;

public static class HttpContextExtensions
{
    public static async Task WriteBody(this HttpContext httpContext, HttpStatusCode httpStatusCode, JsonSerializerOptions jsonOptions, object error)
    {
        var result = JsonSerializer.Serialize(error, jsonOptions);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)httpStatusCode;
        await httpContext.Response.WriteAsync(result);
    }
}
