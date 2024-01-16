namespace GameProject.Domain.Models.RawgApi.Genres;

public class GenreMainInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Games_count { get; set; }
}