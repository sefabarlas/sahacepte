using Microsoft.EntityFrameworkCore;
using SahaCepte.Infrastructure.Persistence.Context;
using SahaCepteApp.Application.Interfaces.Persistence.Repositories;
using SahaCepteApp.Domain.Entities;

namespace SahaCepte.Infrastructure.Persistence.Repositories;

public class FacilityRepository(AppDbContext context) : GenericRepository<Facility>(context), IFacilityRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Facility?> GetFacilityWithPitchesAsync(Guid id)
    {
        return await _context.Facilities
            .Include(v => v.Pitches)
            .Include(v => v.FacilityOwner)
            .FirstOrDefaultAsync(v => v.Id == id);
    }
}