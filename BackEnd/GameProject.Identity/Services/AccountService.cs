using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public Task<BaseResponse<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public Task ConfigureAccountAsync(ConfigureAccountRequest configureAccountRequest)
    {
        throw new NotImplementedException();
    }
}