using System.Security.Claims;

namespace SahaCepteApp.API.Extensions;

public static class UserExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        return string.IsNullOrWhiteSpace(principal.FindFirst("id")?.Value) 
            ? Guid.Empty 
            : new Guid(principal.FindFirst("id")?.Value!);
    }
}