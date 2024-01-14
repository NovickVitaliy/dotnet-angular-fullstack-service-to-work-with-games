using System.ComponentModel.DataAnnotations;

namespace GameProject.Application.Models.Account;

public class ChangeAccountPasswordRequest
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