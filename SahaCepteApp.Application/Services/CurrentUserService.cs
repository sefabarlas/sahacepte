using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SahaCepteApp.Application.Interfaces.Services;

namespace SahaCepteApp.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
        
    private readonly Guid? _userId;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

        var user = _httpContextAccessor.HttpContext?.User;
            
        var idClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
        if (!string.IsNullOrEmpty(idClaim) && Guid.TryParse(idClaim, out var id))
        {
            _userId = id;
        }
    }

    public Guid UserId => _userId ?? throw new UnauthorizedAccessException("Giriş yapılmış kullanıcı ID'si bulunamadı.");
    
    public bool IsAuthenticated => _userId.HasValue;
        
    public string FullName => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.GivenName)?.Value ?? "Misafir";
}