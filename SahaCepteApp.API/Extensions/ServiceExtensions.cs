using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SahaCepte.Infrastructure;
using SahaCepte.Infrastructure.Persistence;
using SahaCepte.Infrastructure.Persistence.Context;
using SahaCepteApp.Application;

namespace SahaCepteApp.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureJwt(this IServiceCollection services, IConfiguration config)
    {
        var jwtSettings = config.GetSection("JwtSettings");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!))
                };
            });
    }

    public static void ConfigureDbConnection(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseNpgsql(config.GetConnectionString("DbConnectionString")), ServiceLifetime.Transient);
    }

    public static async Task AddSeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();

            await DbSeeder.SeedAsync(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Veritabanı seed edilirken bir hata oluştu.");
        }
    }

    public static void ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddInfrastructureServices();
    }

    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddApplicationServices();
    }
    
    public static void ConfigureAppContext(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}