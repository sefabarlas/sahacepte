using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FacilityController(IFacilityService facilityService) : ControllerBase
{
    [HttpGet]
    public async Task<ServiceResponse<IEnumerable<FacilityListDto>>> GetAll([FromQuery] FacilityFilterDto filter)
    {
        var response = await facilityService.GetAllFacilitiesAsync(filter);
        return response;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ServiceResponse<FacilityDto?>> GetById(Guid id)
    {
        var response = await facilityService.GetFacilityDetailAsync(id);
        return response;
    }
}