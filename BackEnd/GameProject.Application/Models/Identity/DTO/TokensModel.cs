using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Identity;

public class TokensModel : BaseRequest
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}