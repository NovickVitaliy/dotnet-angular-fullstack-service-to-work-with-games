using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Account;

public class SendResetPasswordMailRequest : BaseRequest
{
    [Required]
    [Url]
    public string ResetPasswordUrl { get; set; }
}