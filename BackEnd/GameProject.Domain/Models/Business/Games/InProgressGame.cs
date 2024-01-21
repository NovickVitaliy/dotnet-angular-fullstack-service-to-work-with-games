using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Shared;

namespace GameProject.Domain.Models.Business.Games;

public class InProgressGame : BaseGame
{
    public virtual List<UsersInProgressGames> UsersInProgressGames { get; set; } = new();
}