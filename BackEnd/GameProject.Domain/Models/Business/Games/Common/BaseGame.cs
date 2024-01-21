namespace GameProject.Domain.Models.Business.Games.Common;

public abstract class BaseGame
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BackgroundImage { get; set; } = string.Empty;
    public int RawgId { get; set; }
    public string Platform { get; set; }
}