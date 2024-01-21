using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.Models;

namespace GameProject.Domain.Models.Shared;

public class UsersFinishedGames
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
    public Guid FinishedGameId { get; set; }
    public virtual FinishedGame FinishedGame { get; set; }
}