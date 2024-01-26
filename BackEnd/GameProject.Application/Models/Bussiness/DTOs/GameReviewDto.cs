namespace GameProject.Application.Models.Bussiness.DTOs;

public class GameReviewDto
{
    public Guid ReviewId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorEmail { get; set; }
    public string? AuthorProfilePhotoUrl { get; set; }
    public string Review { get; set; }
    public int Score { get; set; }
    public DateTime DateWritten { get; set; }
    public string GameName { get; set; }
    public int GameRawgId { get; set; }
}