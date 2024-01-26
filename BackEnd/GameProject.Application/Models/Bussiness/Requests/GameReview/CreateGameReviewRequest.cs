using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Bussiness.Requests;

public class CreateGameReviewRequest : BaseRequest
{
    [Required] 
    public string Review { get; set; }
    [Required] 
    [Range(0, 10)] 
    public int Score { get; set; }
    [Required] 
    public int GameRawgId { get; set; }
    public string GameName { get; set; }
}