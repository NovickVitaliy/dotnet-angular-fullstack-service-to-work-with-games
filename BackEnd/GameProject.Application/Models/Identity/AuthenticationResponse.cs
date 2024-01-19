namespace GameProject.Application.Models.Identity;

public class AuthenticationResponse
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Location { get; set; }
    public string[] Platforms { get; set; }
    public string Description { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string? ProfilePhotoUrl { get; set; }
}