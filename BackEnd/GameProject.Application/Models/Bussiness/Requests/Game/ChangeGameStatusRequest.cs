using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;
using GameProject.Domain.Models;

namespace GameProject.Application.Models.Bussiness;

public class ChangeGameStatusRequest : BaseRequest
{
    public GameStatus OldStatus { get; set; }
    public GameStatus NewStatus { get; set; }
    public GameAllInfo Game { get; set; }
    public int GameRawgId { get; set; }
    
    [Required]
    public string Platform { get; set; } 
}