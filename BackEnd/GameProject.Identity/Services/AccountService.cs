using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;

namespace GameProject.Identity.Services;

public class AccountService : IAccountService
{
    public Task<AuthenticationResponse> Login(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public Task ConfigureAccount(ConfigureAccountRequest configureAccountRequest)
    {
        throw new NotImplementedException();
    }
}