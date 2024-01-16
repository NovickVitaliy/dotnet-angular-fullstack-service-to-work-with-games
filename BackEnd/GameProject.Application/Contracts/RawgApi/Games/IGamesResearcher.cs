using GameProject.Application.Models.Shared;
using GameProject.Domain.Models;
using GameProject.Infrastructure.RawgApi.Models.Games;

namespace GameProject.Application.Contracts.Games;

public interface IGamesResearcher
{
    Task<List<GameCardItem>> Get10HighestRatedGamesOfAllTime();
    Task<PagedResult<GameMainInfo>> GetGames(GameFilterQuery filterQuery);
}