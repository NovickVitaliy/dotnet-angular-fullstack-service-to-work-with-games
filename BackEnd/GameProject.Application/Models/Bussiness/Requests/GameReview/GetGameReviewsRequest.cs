namespace GameProject.Application.Models.Bussiness.Requests.GameReview;

public class GetGameReviewsRequest
{
    public int GameRawgId { get; set; }
    public int ItemsPerPage { get; set; } = 10;
    public int Page { get; set; }
}