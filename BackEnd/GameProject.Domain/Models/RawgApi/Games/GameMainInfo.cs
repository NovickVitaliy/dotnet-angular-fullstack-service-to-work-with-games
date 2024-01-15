namespace GameProject.Domain.Models;

public class GameMainInfo
{
    public int? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public DateOnly? Released { get; set; }
    public string? Background_image { get; set; } = string.Empty;
    public int? Metacritic { get; set; }
    
}