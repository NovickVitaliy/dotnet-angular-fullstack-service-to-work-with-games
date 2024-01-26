using GameProject.Domain.Models.Business.Games;
using GameProject.Domain.Models.Identity;

namespace GameProject.Domain.Models.Shared;

public class UsersInProgressGames
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
    public Guid InProgressGameId { get; set; }
    public virtual InProgressGame InProgressGame { get; set; }
}