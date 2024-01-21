using System.Text;
using GameProject.Application.Contracts.Games;
using GameProject.Application.Models.Shared;
using GameProject.Domain.Models;
using GameProject.Infrastructure.RawgApi.Models.Games;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

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

    public async Task<PagedResult<GameMainInfo>> GetGames(GameFilterQuery filterQuery)
    {
        StringBuilder queryKey = new StringBuilder();
        queryKey.Append(string.Join(',', filterQuery.Platforms));
        queryKey.Append(string.Join(',', filterQuery.Genres));
        queryKey.Append(filterQuery.SearchString);
        queryKey.Append(filterQuery.PageNumber);
        queryKey.Append(filterQuery.PageSize);

        if (_cache.TryGetValue(queryKey.ToString(), out PagedResult<GameMainInfo> games))
        {
            return games!;
        }

        games = await _gamesResearcher.GetGames(filterQuery);

        _cache.Set(queryKey.ToString(), games, new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
        });
        return games;
    }

    public async Task<GameAllInfo> GetGameInfo(int gameId)
    {
        if (_cache.TryGetValue(gameId, out GameAllInfo gameAllInfo))
        {
            return gameAllInfo!;
        }

        gameAllInfo = await _gamesResearcher.GetGameInfo(gameId);

        _cache.Set(gameId.ToString(), gameAllInfo, new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
        });

        return gameAllInfo;
    }

    public async Task<List<GameScreenshot>> GetGamesScreenshots(int gameId)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(gameId);
        stringBuilder.Append("screenshots");
        string key = stringBuilder.ToString();
        if (_cache.TryGetValue(key, out List<GameScreenshot> screenshots))
        {
            return screenshots;
        }

        screenshots = await _gamesResearcher.GetGamesScreenshots(gameId);

        _cache.Set(key, screenshots, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
        });

        return screenshots;
    }

    public async Task<List<GameTrailer>> GetGamesTrailers(int gameId)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(gameId);
        stringBuilder.Append("movies");
        string key = stringBuilder.ToString();
        if (_cache.TryGetValue(key, out List<GameTrailer> trailers))
        {
            return trailers;
        }

        trailers = await _gamesResearcher.GetGamesTrailers(gameId);

        _cache.Set(key, trailers, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
        });

        return trailers;
    }
}