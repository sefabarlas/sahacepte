using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ServiceResponse<AuthResponse>> Login(LoginDto dto)
    {
        var response = await authService.LoginAsync(dto);
        return response;
    }
}