using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace GameProject.Identity.Services;

public class IJwtService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public IJwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string CreateAccessToken(ApplicationUser user)
    {
        Claim[] claims = {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.NameId, user.Id.ToString())
        };
        
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken securityToken = new JwtSecurityToken(
            claims:claims,
            audience:_jwtSettings.Audience,
            issuer:_jwtSettings.Issuer,
            expires:DateTime.UtcNow.AddMinutes(_jwtSettings.LifeTimeInMinutes),
            signingCredentials:signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    public ClaimsPrincipal GetClaimsFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            ValidateIssuerSigningKey = true
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new BadRequestException("Invalid token", new SecurityTokenException("Invalid token"));

        return principal;
    }
}