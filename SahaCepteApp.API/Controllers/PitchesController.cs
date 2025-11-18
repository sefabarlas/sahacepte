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
public class PitchesController(IPitchService pitchService, LogHelper logHelper) : BaseController(logHelper)
{
    /// <summary>
    /// Retrieves the availability of a specific pitch for a given date.
    /// </summary>
    /// <param name="id">The unique identifier of the pitch.</param>
    /// <param name="date">The date for which the availability is being queried.</param>
    /// <returns>A list of available time slots along with their status and details.</returns>
    [HttpGet("{id:guid}/availability")]
    public async Task<ServiceResponse<List<TimeSlotDto>>> GetAvailability(Guid id, [FromQuery] DateTime date)
    {
        if (Program.Logable) Logger.InfoLog($"id: {id}, date: {date}");
        
        var response = await pitchService.GetDailyAvailabilityAsync(id, date);
        
        Logger.HandleResult((int)response.ResponseDataType, $"id: {id}, date: {date}", JsonSerializer.Serialize(response.Data), response.Message);
        
        return response;
    }
}