using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Interfaces.Services;

namespace SahaCepteApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReservationsController(IReservationService reservationService) : ControllerBase
{
    // [HttpPost]
    // public async Task<ServiceResponse<Guid>> Create(CreateReservationDto dto)
    // {
    //     var result = await reservationService.CreateReservationAsync(dto);
    //
    //     if (result.Success) 
    //         return CreatedAtAction(nameof(Create), new { id = result.Data }, result);
    //     
    //     if (result.Message.Contains("doldu"))
    //         return Conflict(new { message = result.Message });
    //             
    //     return BadRequest(new { message = result.Message });
    // }
}