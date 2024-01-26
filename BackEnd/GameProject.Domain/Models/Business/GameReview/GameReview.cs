using GameProject.Domain.Models.Identity;

namespace GameProject.Domain.Models.Business;

public class GameReview
{
    public Guid Id { get; set; }
    public string Review { get; set; }
    public int Score { get; set; }
    public DateTime DateWritten { get; set; }
    public virtual ApplicationUser Author { get; set; }
    public Guid AuthorId { get; set; }
    public int GameRawgId { get; set; }
    public string GameName { get; set; }
}