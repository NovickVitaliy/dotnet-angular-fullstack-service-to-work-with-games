using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace GameProject.Identity.Services;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string CreateJwtToken(ApplicationUser user)
    {
        Claim[] claims = {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.Millisecond.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.NameId, user.Id.ToString())
        };
        
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);
        SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor();

        JwtSecurityToken securityToken = new JwtSecurityToken(
            claims:claims,
            audience:_jwtSettings.Audience,
            issuer:_jwtSettings.Issuer,
            expires:DateTime.UtcNow.AddMinutes(_jwtSettings.LifeTimeInMinutes),
            signingCredentials:signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}