using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Helpers;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FacilityController(IFacilityService facilityService, LogHelper logHelper) : BaseController(logHelper)
{
    [HttpGet]
    public async Task<ServiceResponse<IEnumerable<FacilityListDto>>> GetAll([FromQuery] FacilityFilterDto filter)
    {
        if (Program.Logable) Logger.InfoLog(JsonSerializer.Serialize(filter));
        
        var response = await facilityService.GetAllFacilitiesAsync(filter);
        
        Logger.HandleResult((int)response.ResponseDataType, JsonSerializer.Serialize(filter), JsonSerializer.Serialize(response.Data), response.Message);
        
        return response;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ServiceResponse<FacilityDto?>> GetById(Guid id)
    {
        if (Program.Logable) Logger.InfoLog(JsonSerializer.Serialize(id));
        
        var response = await facilityService.GetFacilityDetailAsync(id);
        
        Logger.HandleResult((int)response.ResponseDataType, JsonSerializer.Serialize(id), JsonSerializer.Serialize(response.Data), response.Message);
        
        return response;
    }
}