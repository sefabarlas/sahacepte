using SahaCepteApp.Domain.Entities;

namespace SahaCepteApp.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}