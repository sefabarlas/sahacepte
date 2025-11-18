using Microsoft.Extensions.DependencyInjection;
using SahaCepte.Infrastructure.Persistence;
using SahaCepte.Infrastructure.Persistence.Repositories;
using SahaCepteApp.Application.Interfaces.Persistence;
using SahaCepteApp.Application.Interfaces.Persistence.Repositories;

namespace SahaCepte.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<IFacilityOwnerRepository, FacilityOwnerRepository>();
        services.AddScoped<IPitchRepository, PitchRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IReservationParticipantRepository, ReservationParticipantRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}