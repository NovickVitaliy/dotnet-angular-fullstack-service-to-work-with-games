using GameProject.Application.Common.DTO;
using GameProject.Application.Models.Identity;

namespace GameProject.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<BaseResponse<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest);
    Task<BaseResponse<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest);
    Task ConfigureAccountAsync(ConfigureAccountRequest configureAccountRequest);
    Task<BaseResponse<TokensModel>> RefreshToken(TokensModel tokens);
}