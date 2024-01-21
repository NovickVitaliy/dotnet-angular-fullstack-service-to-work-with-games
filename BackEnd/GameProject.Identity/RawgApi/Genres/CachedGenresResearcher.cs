using GameProject.Application.Contracts.RawgApi.Genres;
using GameProject.Domain.Models.RawgApi.Genres;
using Microsoft.Extensions.Caching.Memory;

namespace GameProject.Infrastructure.RawgApi.Genres;

public class CachedGenresResearcher : IGenresResearcher
{
    private readonly IMemoryCache _cache;
    private readonly IGenresResearcher _genresResearcher;
    private const string GenreCacheKey = "GenreCacheKey";

    public CachedGenresResearcher(IMemoryCache cache, IGenresResearcher genresResearcher)
    {
        _cache = cache;
        _genresResearcher = genresResearcher;
    }

    public async Task<List<GenreMainInfo>> GetGenres()
    {
        if (_cache.TryGetValue(GenreCacheKey, out List<GenreMainInfo> genres))
        {
            return genres;
        }

        genres = await _genresResearcher.GetGenres();
        _cache.Set(GenreCacheKey, genres);
        return genres;
    }
}