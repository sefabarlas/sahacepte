using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Helpers;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, LogHelper logHelper) : BaseController(logHelper)
{
    [HttpPost("login")]
    public async Task<ServiceResponse<AuthResponse>> Login(LoginDto dto)
    {
        if (Program.Logable) Logger.InfoLog(JsonSerializer.Serialize(dto));
        
        var response = await authService.LoginAsync(dto);

        Logger.HandleResult((int)response.ResponseDataType, JsonSerializer.Serialize(dto), JsonSerializer.Serialize(response.Data), response.Message);
            
        return response;
    }
}