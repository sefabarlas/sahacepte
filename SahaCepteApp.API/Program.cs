using SahaCepteApp.API.Extensions;
using SahaCepteApp.API.Middlewares;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
    
    builder.Services.AddHttpContextAccessor();
    builder.Services.ConfigureDbConnection(builder.Configuration);
    builder.Services.ConfigureInfrastructureServices();
    builder.Services.ConfigureApplicationServices();
    builder.Services.ConfigureJwt(builder.Configuration);
    builder.Services.ConfigureAppContext();
    builder.Services.AddCustomSwagger();
    builder.Services.ConfigureLoggerService();

    builder.Services.AddControllers();
    
    var app = builder.Build();

    await app.AddSeedData();

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });

    app.MapScalarApiReference();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Uygulama beklenmedik bir hata nedeniyle sonlandı.");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program
{
    private static readonly WebApplicationBuilder Builder = WebApplication.CreateBuilder();

    public static readonly bool Logable = Convert.ToBoolean(Builder.Configuration["IsLoggingEnabled"]);
}