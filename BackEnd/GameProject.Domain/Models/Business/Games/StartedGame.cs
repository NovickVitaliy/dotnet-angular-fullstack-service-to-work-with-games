using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Shared;

namespace GameProject.Domain.Models.Business.Games;

public class StartedGame : BaseGame
{
    public virtual List<UsersStartedGames> UsersStartedGames { get; set; } = new();
}