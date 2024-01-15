namespace GameProject.Infrastructure.Models.Games;

public class RawgResponse<T>
{
    public int Count { get; set; }
    public List<T> Results { get; set; }
}