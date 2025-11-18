using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Interfaces.Services;

public interface IAuthService
{
    Task<ServiceResponse<AuthResponse>> LoginAsync(LoginDto dto);
}