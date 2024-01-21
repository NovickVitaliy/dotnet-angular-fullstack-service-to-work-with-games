using System.Security.Claims;
using AutoMapper;
using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Bussiness.DTOs;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GameProject.Identity.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RefreshTokenSettings _refreshTokenSettings;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public AuthenticationService(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService,
        IOptionsSnapshot<RefreshTokenSettings> refreshTokenOptions,
        IMapper mapper)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _mapper = mapper;
        _refreshTokenSettings = refreshTokenOptions.Value;
    }

    public async Task<BaseResponse<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userManager
            .Users.Include(u => u.ProfilePhoto)
            .SingleAsync(u => u.Email == loginRequest.Email);
        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

        if (!isPasswordCorrect || user == null)
        {
            throw new BadRequestException("user with given email was not found or given password is incorrect");
        }

        var accessToken = _tokenService.CreateAccessToken(user);
        var refreshToken = _tokenService.CreateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(_refreshTokenSettings.RefreshTokenLifeTimeInHours);
        var identityResult = await _userManager.UpdateAsync(user);
        if (identityResult.Succeeded)
        {
            var userToReturn = _mapper.Map<AuthenticationResponse>(user);
            userToReturn.AccessToken = accessToken;
            userToReturn.RefreshToken = refreshToken;
            return new BaseResponse<AuthenticationResponse>()
            {
                Data = userToReturn
            };
        }

        throw new BadRequestException(string.Join('\n', identityResult.Errors.Select(err => err.Description)));
    }

    public async Task<BaseResponse<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = await _userManager.FindByEmailAsync(registerRequest.Email);
        if (user != null)
        {
            throw new BadRequestException("User with given email already exists");
        }

        user = new ApplicationUser
        {
            Email = registerRequest.Email,
            UserName = registerRequest.Username,
        };

        IdentityResult identityResult = await _userManager.CreateAsync(user, registerRequest.Password);

        if (identityResult.Succeeded)
        {
            var accessToken = _tokenService.CreateAccessToken(user);
            var refreshToken = _tokenService.CreateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow
                .AddHours(_refreshTokenSettings.RefreshTokenLifeTimeInHours);
            var updateAsync = await _userManager.UpdateAsync(user);
            if (!updateAsync.Succeeded)
            {
                throw new BadRequestException(string.Join('\n', 
                    updateAsync.Errors.Select(err => err.Description)));
            }
            var userToReturn = _mapper.Map<AuthenticationResponse>(user);
            return new BaseResponse<AuthenticationResponse>()
            {
                Data = new AuthenticationResponse()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Description = user.Description,
                    Location = user.Country,
                    Platforms = user.Platforms.Split(';')
                }
            };
        }

        throw new BadRequestException(string.Join("\n", 
            identityResult.Errors.SelectMany(err => err.Description)));
    }

    public async Task ConfigureAccountAsync(ConfigureAccountRequest configureAccountRequest)
    {
        var user = await _userManager.FindByEmailAsync(configureAccountRequest.Email);

        if (user == null)
        {
            throw new NotFoundException("User with given email does not exist");
        }

        user.Description = configureAccountRequest.Description;
        user.Platforms = string.Join(';', configureAccountRequest.Platforms);
        user.Country = configureAccountRequest.Location;
        user.FirstName = configureAccountRequest.FirstName;
        user.LastName = configureAccountRequest.LastName;
        var identityResult = await _userManager.UpdateAsync(user);

        if (!identityResult.Succeeded)
        {
            throw new BadRequestException(string.Join('\n', 
                identityResult.Errors.Select(err => err.Description)));
        }
    }

    public async Task<BaseResponse<TokensModel>> RefreshToken(TokensModel tokens)
    {
        var claimsFromExpiredToken = _tokenService.GetClaimsFromExpiredToken(tokens.AccessToken);

        var emailClaim = claimsFromExpiredToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);

        var user = await _userManager.FindByEmailAsync(emailClaim.Value);

        if (user == null)
        {
            throw new NotFoundException("User does not exist");
        }

        if (user.RefreshToken != tokens.RefreshToken)
        {
            throw new BadRequestException("Invalid refresh token");
        }

        if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new BadRequestException("Refresh token expired");
        }

        var newAccessToken = _tokenService.CreateAccessToken(user);
        var newRefreshToken = _tokenService.CreateRefreshToken();
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(_refreshTokenSettings.RefreshTokenLifeTimeInHours);
        var identityResult = await _userManager.UpdateAsync(user);

        if (identityResult.Succeeded)
        {
            return new BaseResponse<TokensModel>()
            {
                Data = new TokensModel()
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                }
            };
        }

        throw new BadRequestException(string.Join('\n', identityResult.Errors.Select(err => err.Description)));
    }
}