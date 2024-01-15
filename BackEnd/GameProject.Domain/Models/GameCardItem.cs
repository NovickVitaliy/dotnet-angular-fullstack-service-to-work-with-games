using System.Text.Json.Serialization;

namespace GameProject.Domain.Models;

public class GameCardItem
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("background_image")] 
    public string BackgroundImage { get; set; } = string.Empty;

    [JsonPropertyName("metacritic")] 
    public int MetacriticScore { get; set; }
}