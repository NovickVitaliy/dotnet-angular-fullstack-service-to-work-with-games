using System.Text;
using System.Text.Json;
using GameProject.Application.Contracts.Games;
using GameProject.Application.Models.Shared;
using GameProject.Domain.Models;
using GameProject.Infrastructure.Models.Games;
using GameProject.Infrastructure.RawgApi.Models.Games;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace GameProject.Infrastructure.Games;

public class GamesResearcher : IGamesResearcher
{
    private readonly HttpClient _http;
    private readonly string _authenticationToken;

    public GamesResearcher(IHttpClientFactory http, IOptions<RawgSettings> options)
    {
        _http = http.CreateClient(options.Value.ClientName);
        _authenticationToken = options.Value.AuthenticationToken;
    }

    public async Task<List<GameCardItem>> Get10HighestRatedGamesOfAllTime()
    {
        var response = await _http.GetAsync($"games?key={_authenticationToken}&ordering=-metacritic");

        var content = await response.Content.ReadAsStringAsync();
        
        RawgResponse<GameCardItem>? result =
            JsonSerializer.Deserialize<RawgResponse<GameCardItem>>(content, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});

        return result.Results.Take(10).ToList();
    }

    public async Task<PagedResult<GameMainInfo>> GetGames(GameFilterQuery filterQuery)
    {
        StringBuilder requestUrl = new StringBuilder($"games?key={_authenticationToken}");
        if (filterQuery.Platforms.Length > 0)
        {
            requestUrl.Append($"&platforms={string.Join(',', filterQuery.Platforms)}");
        }
        
        if (filterQuery.Genres.Length > 0)
        {
            requestUrl.Append($"&genres={string.Join(',', filterQuery.Platforms)}");
        }

        requestUrl.Append($"&page={filterQuery.PageNumber}&page_size={filterQuery.PageSize}");

        if (!string.IsNullOrEmpty(filterQuery.SearchString))
        {
            requestUrl.Append($"&search={filterQuery.SearchString}");
        }

        var response = await _http.GetAsync(requestUrl.ToString());

        var dataAsJson = await response.Content.ReadAsStringAsync();

        RawgResponse<GameMainInfo> games = JsonSerializer.Deserialize<RawgResponse<GameMainInfo>>(dataAsJson,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        return new PagedResult<GameMainInfo>()
        {
            CurrentPage = filterQuery.PageNumber,
            ItemsPerPage = filterQuery.PageSize,
            TotalCount = games.Count,
            Items = games.Results
            
        };
    }

    public async Task<GameAllInfo> GetGameInfo(int gameId)
    {
        var response = await _http.GetAsync($"games/{gameId}?key={_authenticationToken}");

        string dataAsString = await response.Content.ReadAsStringAsync();

        GameAllInfo result = JsonSerializer.Deserialize<GameAllInfo>(dataAsString,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        return result;
    }
}