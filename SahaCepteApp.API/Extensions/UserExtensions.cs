using System.Security.Claims;

namespace SahaCepteApp.API.Extensions;

public static class UserExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (string.IsNullOrWhiteSpace(principal.FindFirst("id")?.Value))
            return Guid.Empty;

        return new Guid(principal.FindFirst("id")?.Value!);
    }
}