using SahaCepteApp.Application.Interfaces.Persistence.Repositories;

namespace SahaCepteApp.Application.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    IFacilityRepository Facilities { get; }
    
    IFacilityOwnerRepository FacilityOwners { get; }
    
    IPitchRepository Pitches { get; }
    
    IPlayerRepository Players { get; }
    
    IReservationRepository Reservations { get; }
    
    IReservationParticipantRepository ReservationParticipants { get; }
    
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync();
}