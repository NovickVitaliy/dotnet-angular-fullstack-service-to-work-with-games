using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.Models;

namespace GameProject.Domain.Models.Shared;

public class UsersDesiredGames
{
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
    public Guid DesiredGameId { get; set; }
    public virtual DesiredGame DesiredGame { get; set; }
}