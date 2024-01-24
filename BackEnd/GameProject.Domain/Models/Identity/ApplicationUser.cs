using GameProject.Domain.Models.Shared;
using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Platforms { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public virtual ProfilePhoto? ProfilePhoto { get; set; } = null;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public virtual List<UsersStartedGames> UsersStartedGames { get; set; } = new();
    public virtual List<UsersInProgressGames> UsersInProgressGames { get; set; } = new();
    public virtual List<UsersFinishedGames> UsersFinishedGames { get; set; } = new();
    public virtual List<UsersAbandonedGames> UsersAbandonedGames { get; set; } = new();
    public virtual List<UsersDesiredGames> UsersDesiredGames { get; set; } = new();
}