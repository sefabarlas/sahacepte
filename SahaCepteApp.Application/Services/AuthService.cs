using SahaCepteApp.Application.Interfaces.Persistence;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Services;

public class AuthService(IUnitOfWork unitOfWork, ITokenService tokenService) : IAuthService
{
    public async Task<ServiceResponse<AuthResponse>> LoginAsync(LoginDto dto)
    {
        var users = await unitOfWork.Users.FindAsync(u => u.PhoneNumber == dto.PhoneNumber);
        var user = users.FirstOrDefault();

        if (user == null)
        {
            return ServiceResponse<AuthResponse>.WarningResult("Kullanıcı bulunamadı. Lütfen kayıt olun.");
        }

        var token = tokenService.GenerateToken(user);

        return ServiceResponse<AuthResponse>.SuccessResult(new AuthResponse
        {
            Token = token,
            FullName = user.FullName
        });
    }
}