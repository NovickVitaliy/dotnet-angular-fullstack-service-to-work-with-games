using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Shared;

namespace GameProject.Domain.Models.Business.Games;

public class DesiredGame : BaseGame
{
    public virtual List<UsersDesiredGames> UsersDesiredGames { get; set; } = new();
}