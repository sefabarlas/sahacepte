using SahaCepte.Infrastructure.Persistence.Context;
using SahaCepte.Infrastructure.Persistence.Repositories;
using SahaCepteApp.Application.Interfaces.Persistence;
using SahaCepteApp.Application.Interfaces.Persistence.Repositories;

namespace SahaCepte.Infrastructure.Persistence;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private FacilityRepository? _facilityRepository;
    
    private FacilityOwnerRepository? _facilityOwnerRepository;
    
    private PitchRepository? _pitchRepository;
    
    private PlayerRepository? _playerRepository;
    
    private ReservationRepository? _reservationRepository;
    
    private ReservationParticipantRepository? _reservationParticipantRepository;
    
    private UserRepository? _userRepository;
    

    public IFacilityRepository Facilities => _facilityRepository ??= new FacilityRepository(context);
    
    public IFacilityOwnerRepository FacilityOwners => _facilityOwnerRepository ??= new FacilityOwnerRepository(context);
    
    public IPitchRepository Pitches => _pitchRepository ??= new PitchRepository(context);
    
    public IPlayerRepository Players => _playerRepository ??= new PlayerRepository(context);
    
    public IReservationRepository Reservations => _reservationRepository ??= new ReservationRepository(context);
    
    public IReservationParticipantRepository ReservationParticipants => _reservationParticipantRepository ??= new ReservationParticipantRepository(context);
    
    public IUserRepository Users => _userRepository ??= new UserRepository(context);

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}