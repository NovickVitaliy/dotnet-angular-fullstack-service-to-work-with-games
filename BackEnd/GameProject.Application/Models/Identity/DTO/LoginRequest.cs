using System.ComponentModel.DataAnnotations;

namespace GameProject.Application.Models.Identity;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}