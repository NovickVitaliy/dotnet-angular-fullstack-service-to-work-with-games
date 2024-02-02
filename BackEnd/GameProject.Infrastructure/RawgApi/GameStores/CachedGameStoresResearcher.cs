using System.Text;
using GameProject.Application.Contracts.RawgApi.Stores;
using GameProject.Application.Models.Bussiness.DTOs;
using Microsoft.Extensions.Caching.Memory;

namespace GameProject.Identity.RawgApi.GameStores;

public class CachedGameStoresResearcher : IGamesStoreResearcher
{
    private readonly IMemoryCache _cache;
    private readonly IGamesStoreResearcher _gamesStoreResearcher;

    public CachedGameStoresResearcher(IMemoryCache cache, IGamesStoreResearcher gamesStoreResearcher)
    {
        _cache = cache;
        _gamesStoreResearcher = gamesStoreResearcher;
    }

    public async Task<List<GameStore>> GetGamesStoreForGame(int gameId)
    {
        string key = GetKeyForGameStore(gameId);

        if (_cache.TryGetValue(key, out List<GameStore> gameStores))
        {
            return gameStores;
        }

        gameStores = await _gamesStoreResearcher.GetGamesStoreForGame(gameId);

        _cache.Set(key, gameStores);
        return gameStores;
    }

    private string GetKeyForGameStore(int gameId)
    {
        return new StringBuilder().Append("GameStore").Append(gameId).ToString();
    }
}