using SahaCepteApp.Domain.Entities;

namespace SahaCepteApp.Application.Interfaces.Persistence.Repositories;

public interface IFacilityRepository : IGenericRepository<Facility>
{
    Task<Facility?> GetFacilityWithPitchesAsync(Guid id);
}