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

    public Task<BaseResponse<AuthenticationResponse>> Login(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<AuthenticationResponse>> Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public Task ConfigureAccount(ConfigureAccountRequest configureAccountRequest)
    {
        throw new NotImplementedException();
    }
}