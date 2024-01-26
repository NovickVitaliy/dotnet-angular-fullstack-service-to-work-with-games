using GameProject.Application.Models.Bussiness.DTOs;

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
    public int DaysWithUs { get; set; }
    public bool EmailConfirmed { get; set; }
    public List<BaseGameResponse> StartedGames { get; set; } = new();
    public List<BaseGameResponse> InProgressGames { get; set; } = new();
    public List<BaseGameResponse> FinishedGames { get; set; } = new();
    public List<BaseGameResponse> AbandonedGames { get; set; } = new();
    public List<BaseGameResponse> DesiredGames { get; set; } = new();
    public List<GameReviewDto> GameReviews { get; set; } = new();
}