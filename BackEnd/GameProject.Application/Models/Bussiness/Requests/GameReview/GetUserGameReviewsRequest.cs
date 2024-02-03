using System.ComponentModel.DataAnnotations;

namespace GameProject.Application.Models.Bussiness.Requests.GameReview;

public class GetUserGameReviewsRequest
{
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    public int Page { get; set; }
    
    [Required]
    public int ItemsPerPage { get; set; }
}