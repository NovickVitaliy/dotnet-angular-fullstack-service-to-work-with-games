using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Account.ResetPasswordDtos;

public class ResetPasswordRequest : BaseRequest
{
    [Required] public string NewPassword { get; set; } = string.Empty;

    [Required]
    [Compare(nameof(NewPassword))]
    public string NewPasswordConfirm { get; set; } = string.Empty;
    
    [Required]
    public string Token { get; set; } = string.Empty;
}