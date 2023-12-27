using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ecco.Integrations.WebService.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//This line is required to run docker with ASPNETCORE_ENVIRONMENT=LocalDev
//either https configuration error will occur. WebApplication.CreateBuilder only load user secrets if
// ASPNETCORE_ENVIRONMENT Development
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "LocalDev")
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var configSection = builder.Configuration.GetSection("App");
var config = configSection.Get<AppConfig>();
builder.Services.Configure<AppConfig>(configSection);

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AppModule());
});

builder.Services.AddOptions();
builder.Services.AddAutoMapper(typeof(AppModule));

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

if (config.UseSwagger)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

if (config.UseSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

