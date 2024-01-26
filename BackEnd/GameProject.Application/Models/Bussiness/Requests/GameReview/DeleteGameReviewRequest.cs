using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Bussiness.Requests.GameReview;

public class DeleteGameReviewRequest : BaseRequest
{
    [Required]
    public Guid ReviewId { get; set; }
}