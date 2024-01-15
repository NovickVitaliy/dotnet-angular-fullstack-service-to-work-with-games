using GameProject.Domain.Models;

namespace GameProject.Application.Contracts.Games;

public interface IGamesResearcher
{
    Task<List<GameCardItem>> Get10HighestRatedGamesOfAllTime();
}