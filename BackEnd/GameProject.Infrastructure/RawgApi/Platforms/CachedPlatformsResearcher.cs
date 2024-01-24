using GameProject.Application.Contracts.Games;
using GameProject.Application.Contracts.RawgApi.Platforms;
using GameProject.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GameProject.Infrastructure.RawgApi.Platforms;

public class CachedPlatformsResearcher : IPlatformsResearcher
{
    private readonly IPlatformsResearcher _platformsResearcher;
    private readonly IMemoryCache _cache;
    private const string AllPlatformsForFilteringKey = "AllPlatformsForFiltering";
    
    public CachedPlatformsResearcher(IMemoryCache cache, IPlatformsResearcher platformsResearcher)
    {
        _cache = cache;
        _platformsResearcher = platformsResearcher;
    }

    public async Task<List<GamingPlatform>> GetAllPlatforms()
    {
        if (_cache.TryGetValue(AllPlatformsForFilteringKey, out List<GamingPlatform> platforms))
        {
            return platforms;
        }

        platforms = await _platformsResearcher.GetAllPlatforms();
        _cache.Set(AllPlatformsForFilteringKey, platforms);
        return platforms;
    }
}