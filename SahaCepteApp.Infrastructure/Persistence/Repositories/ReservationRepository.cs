using SahaCepte.Infrastructure.Persistence.Context;
using SahaCepteApp.Application.Interfaces.Persistence.Repositories;
using SahaCepteApp.Domain.Entities;

namespace SahaCepte.Infrastructure.Persistence.Repositories;

public class ReservationRepository(AppDbContext context) : GenericRepository<Reservation>(context), IReservationRepository
{
    
}