namespace GameProject.Infrastructure.RawgApi.Models.Games;

public class GameFilterQuery
{
    public int[] Platforms { get; set; } = Array.Empty<int>();
    public int[] Genres { get; set; } = Array.Empty<int>();
    public string? SearchString { get; set; } = string.Empty;
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}