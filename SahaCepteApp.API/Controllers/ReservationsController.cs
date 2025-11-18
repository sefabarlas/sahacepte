using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Helpers;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Enums;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReservationsController(IReservationService reservationService, LogHelper logHelper) : BaseController(logHelper)
{
    [HttpPost]
    public async Task<ServiceResponse<Guid>> Create(CreateReservationDto dto)
    {
        if (Program.Logable) Logger.InfoLog(JsonSerializer.Serialize(dto));
        
        var response = await reservationService.CreateReservationAsync(dto);
    
        Logger.HandleResult((int)response.ResponseDataType, JsonSerializer.Serialize(dto), JsonSerializer.Serialize(response.Data), response.Message);

        return response;
    }
}