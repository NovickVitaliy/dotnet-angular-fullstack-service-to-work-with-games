using GameProject.Domain.Models.RawgApi.Developers;
using GameProject.Domain.Models.RawgApi.Genres;
using GameProject.Domain.Models.RawgApi.Publishers;
using GameProject.Domain.Models.RawgApi.Tags;

namespace GameProject.Domain.Models;

public class GameAllInfo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description_raw { get; set; }
    public int? Metacritic { get; set; }
    public DateOnly? Released { get; set; }
    public string? Background_image { get; set; }
    public string? Metacritic_url { get; set; }
    public List<PlatformInfo>? Platforms { get; set; } = new();
    public List<GameDeveloper>? Developers { get; set; } = new();
    public List<GenreMainInfo>? Genres { get; set; } = new();
    public List<GameTag>? Tags { get; set; } = new();
    public List<GamePublisher>? Publishers { get; set; } = new();
}