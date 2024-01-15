using GameProject.Application.Contracts.Games;
using GameProject.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GameProject.Infrastructure.Games;

public class CachedGamesResearcher : IGamesResearcher
{
    private readonly IGamesResearcher _gamesResearcher;
    private readonly IMemoryCache _cache;
    private const string Top10HighestRatedGamesOfAllTimeKey = "Top10HighestRatedGamesOfAllTime";

    public CachedGamesResearcher(IGamesResearcher gamesResearcher, IMemoryCache cache)
    {
        _gamesResearcher = gamesResearcher;
        _cache = cache;
    }

    public async Task<List<GameCardItem>> Get10HighestRatedGamesOfAllTime()
    {
        if (_cache.TryGetValue(Top10HighestRatedGamesOfAllTimeKey, out List<GameCardItem>? games))
        {
            return games!;
        }

        games = await _gamesResearcher.Get10HighestRatedGamesOfAllTime();
        _cache.Set(Top10HighestRatedGamesOfAllTimeKey, games,
            new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7),
            });
        return games;
    }
}