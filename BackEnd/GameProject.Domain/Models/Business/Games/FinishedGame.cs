using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Shared;

namespace GameProject.Domain.Models.Business.Games;

public class FinishedGame : BaseGame
{
    public virtual List<UsersFinishedGames> UsersFinishedGames { get; set; } = new();
}