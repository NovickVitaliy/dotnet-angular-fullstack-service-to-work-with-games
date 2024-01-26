using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Bussiness.Requests.GameReview;

public class UpdateGameReviewRequest : BaseRequest
{
    public Guid ReviewId { get; set;  }
    [Required]
    public string EditedReview { get; set; }
    [Required]
    [Range(0,10)]
    public int EditedScore { get; set; }
}