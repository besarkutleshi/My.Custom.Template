using My.Custom.Template.API.Extensions;
using Serilog;
using My.Custom.Template.Infrastructure.Extensions.ServiceCollections;
using My.Custom.Template.Infrastructure.Extensions.ApplicationCollections;
using My.Custom.Template.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServiceCollectionConfigurations(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddPresentationServices();

var app = builder.Build();

app.AddInfrastructureApplicationConfigurations();
app.AddPersistentApplicationBuilderConfigurations();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();