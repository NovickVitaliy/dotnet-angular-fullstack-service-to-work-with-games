using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Shared;

namespace GameProject.Domain.Models.Business.Games;

public class AbandonedGame : BaseGame
{
    public virtual List<UsersAbandonedGames> UsersAbandonedGames { get; set; } = new();
}