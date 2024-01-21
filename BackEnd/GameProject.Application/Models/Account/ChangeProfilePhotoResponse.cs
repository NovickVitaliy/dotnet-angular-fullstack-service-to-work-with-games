using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Account;

public class ChangeProfilePhotoResponse : BaseRequest
{
    public string PhotoUrl { get; set; }
}