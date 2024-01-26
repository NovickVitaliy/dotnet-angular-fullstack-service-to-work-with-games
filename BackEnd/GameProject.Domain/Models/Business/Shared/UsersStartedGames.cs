using GameProject.Domain.Models.Business.Games;
using GameProject.Domain.Models.Identity;

namespace GameProject.Domain.Models.Shared;

public class UsersStartedGames
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
    public Guid StartedGameId { get; set; }
    public virtual StartedGame StartedGame { get; set; }
}