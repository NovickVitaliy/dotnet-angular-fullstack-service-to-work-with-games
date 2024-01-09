using System.ComponentModel.DataAnnotations;

namespace GameProject.Application.Models.Identity;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwors must match")]
    public string ConfirmPassword { get; set; }
}