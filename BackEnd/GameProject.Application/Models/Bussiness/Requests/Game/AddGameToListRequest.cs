using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;
using GameProject.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameProject.Application.Models.Bussiness;

public class AddGameToListRequest : BaseRequest
{
    public GameAllInfo Game { get; set; }
    
    [JsonConverter(typeof(StringEnumConverter))] 
    public GameStatus Status { get; set; }
    
    [Required]
    public string Platform { get; set; } 
}