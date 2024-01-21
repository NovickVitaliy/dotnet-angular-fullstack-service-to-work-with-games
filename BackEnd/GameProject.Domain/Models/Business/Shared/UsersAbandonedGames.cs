using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.Models;

namespace GameProject.Domain.Models.Shared;

public class UsersAbandonedGames
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
    public Guid AbandonedGameId { get; set; }
    public virtual AbandonedGame AbandonedGame { get; set; }
}