using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.Models;

namespace GameProject.Domain.Models.Shared;

public class UsersInProgressGames
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
    public Guid InProgressGameId { get; set; }
    public virtual InProgressGame InProgressGame { get; set; }
}