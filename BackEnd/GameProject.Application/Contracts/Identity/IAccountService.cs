using GameProject.Application.Models.Identity;

namespace GameProject.Application.Contracts.Identity;

public interface IAccountService
{
    Task<AuthenticationResponse> Login(LoginRequest loginRequest);
    Task<AuthenticationResponse> Register(RegisterRequest registerRequest);
    Task ConfigureAccount(ConfigureAccountRequest configureAccountRequest);
}