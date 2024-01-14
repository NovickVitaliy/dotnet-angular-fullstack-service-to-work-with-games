using System.ComponentModel.DataAnnotations;

namespace GameProject.Application.Models.Account;

public class ChangeAccountDataRequest
{
    [Required]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    [Required]
    public string[] Platforms { get; set; } = Array.Empty<string>();
    
    public string Description { get; set; } = string.Empty;
}