using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
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
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = await _userManager.FindByEmailAsync(registerRequest.Email);
        if (user != null)
        {
            return new BaseResponse<AuthenticationResponse>()
            {
                StatusCode = StatusCodes.Status400BadRequest, 
                Description = "User with given email already exists"
            };
        }

        user = new ApplicationUser()
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

        return new BaseResponse<AuthenticationResponse>()
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Description = string.Join('\n', identityResult.Errors.Select(err => err.Description))
        };
    }

    public async Task ConfigureAccountAsync(ConfigureAccountRequest configureAccountRequest)
    {
        throw new NotImplementedException();
    }
}