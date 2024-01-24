using System.Security.Claims;
using GameProject.Identity.Models;

namespace GameProject.Identity.Contracts;

public interface ITokenService
{
    string CreateAccessToken(ApplicationUser user);
    string CreateRefreshToken();
    ClaimsPrincipal GetClaimsFromExpiredToken(string token);
}