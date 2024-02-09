namespace GameProject.Identity.Models;

public class InitialAdminConfiguration
{
    public const string PathToConfiguration = "InitialAdminConfiguration";
    
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Platforms { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}