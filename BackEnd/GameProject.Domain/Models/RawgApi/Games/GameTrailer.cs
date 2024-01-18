using System.Text.Json.Serialization;

namespace GameProject.Domain.Models;

public class GameTrailer
{
    public int Id { get; set; }
    
    [JsonPropertyName("data")]
    public GameVideo Video { get; set; }
}