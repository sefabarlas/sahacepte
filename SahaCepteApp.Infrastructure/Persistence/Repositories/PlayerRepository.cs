using SahaCepte.Infrastructure.Persistence.Context;
using SahaCepteApp.Application.Interfaces.Persistence.Repositories;
using SahaCepteApp.Domain.Entities;

namespace SahaCepte.Infrastructure.Persistence.Repositories;

public class PlayerRepository(AppDbContext context) : GenericRepository<Player>(context), IPlayerRepository
{
    
}