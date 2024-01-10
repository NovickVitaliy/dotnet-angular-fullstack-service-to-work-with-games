namespace GameProject.Application.Models.Identity;

public class AuthenticationResponse
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}