using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;
    public AccountService(
        UserManager<ApplicationUser> userManager, 
        IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<BaseResponse<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);
        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

        if (!isPasswordCorrect || user == null)
        {
            throw new BadRequestException("user with given email was not found or given password is incorrect");
        }

        var jwtToken = _jwtService.CreateJwtToken(user);

        return new BaseResponse<AuthenticationResponse>()
        {
            StatusCode = StatusCodes.Status200OK,
            Data = new AuthenticationResponse()
            {
                Email = user.Email,
                Token = jwtToken
            }
        };
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
            var jwtToken = _jwtService.CreateJwtToken(user);
            return new BaseResponse<AuthenticationResponse>()
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new AuthenticationResponse()
                {
                    Email = user.Email,
                    Token = jwtToken
                }
            };
        }
        throw new BadRequestException(string.Join("\n", identityResult.Errors.SelectMany(err => err.Description)));
    }

    public async Task ConfigureAccountAsync(ConfigureAccountRequest configureAccountRequest)
    {
        throw new NotImplementedException();
    }
}