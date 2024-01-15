using System.Text.Json;
using GameProject.Application.Contracts.Games;
using GameProject.Domain.Models;
using GameProject.Infrastructure.Models.Games;
using Microsoft.Extensions.Options;

namespace GameProject.Infrastructure.Games;

public class GamesResearcher : IGamesResearcher
{
    private readonly HttpClient _http;
    private readonly string _authenticationToken;

    public GamesResearcher(HttpClient http, IOptions<RawgSettings> options)
    {
        _http = http;
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
}