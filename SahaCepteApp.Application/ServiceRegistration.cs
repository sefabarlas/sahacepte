using Microsoft.Extensions.DependencyInjection;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Application.Services;

namespace SahaCepteApp.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<IPitchService, PitchService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}