using GameProject.Domain.Models;
using GameProject.Infrastructure.RawgApi.Models.Games;

namespace GameProject.Application.Contracts.Games;

public interface IGamesResearcher
{
    Task<List<GameCardItem>> Get10HighestRatedGamesOfAllTime();
    Task<List<GameMainInfo>> GetGames(GameFilterQuery filterQuery);
}