using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Interfaces.Services;

public interface IFacilityService
{
    Task<ServiceResponse<IEnumerable<FacilityListDto>>> GetAllFacilitiesAsync(FacilityFilterDto filter);
        
    Task<ServiceResponse<FacilityDto?>> GetFacilityDetailAsync(Guid id);
}