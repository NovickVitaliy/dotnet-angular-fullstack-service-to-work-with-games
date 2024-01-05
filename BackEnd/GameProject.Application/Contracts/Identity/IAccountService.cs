using GameProject.Application.Common.DTO;
using GameProject.Application.Models.Identity;

namespace GameProject.Application.Contracts.Identity;

public interface IAccountService
{
    Task<BaseResponse<AuthenticationResponse>> Login(LoginRequest loginRequest);
    Task<BaseResponse<AuthenticationResponse>> Register(RegisterRequest registerRequest);
    Task ConfigureAccount(ConfigureAccountRequest configureAccountRequest);
}