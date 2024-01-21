using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Account;

public class ChangeAccountPasswordRequest : BaseRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string OldPassword { get; set; }
    
    [Required]
    public string NewPassword { get; set; }
    
    [Required]
    [Compare(nameof(NewPassword))]
    public string NewPasswordRepeat { get; set; }
}