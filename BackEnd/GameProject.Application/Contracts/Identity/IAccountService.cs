using GameProject.Application.Common.DTO;
using GameProject.Application.Models.Identity;

namespace GameProject.Application.Contracts.Identity;

public interface IAccountService
{
    Task<BaseResponse<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest);
    Task<BaseResponse<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest);
    Task ConfigureAccountAsync(ConfigureAccountRequest configureAccountRequest);
}