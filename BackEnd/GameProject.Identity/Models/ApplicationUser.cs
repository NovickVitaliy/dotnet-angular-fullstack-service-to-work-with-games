using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Description { get; set; } = string.Empty;
    public string Platforms { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}