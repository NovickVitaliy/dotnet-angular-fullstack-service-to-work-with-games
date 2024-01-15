using System.Security.Claims;

namespace GameProject.Identity.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserEmail(this ClaimsPrincipal claims)
    {
        return claims.FindFirst(ClaimTypes.Email)?.Value;
    }
}