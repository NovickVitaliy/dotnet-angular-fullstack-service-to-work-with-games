using System.Text.Json;
using GameProject.Application.Contracts.RawgApi.Genres;
using GameProject.Domain.Models.RawgApi.Genres;
using GameProject.Infrastructure.Models.Games;
using Microsoft.Extensions.Options;

namespace GameProject.Infrastructure.RawgApi.Genres;

public class GenresResearcher : IGenresResearcher
{
    private readonly HttpClient _httpClient;
    private readonly string _authenticationToken;

    public GenresResearcher(IHttpClientFactory httpClientFactory, IOptions<RawgSettings> options)
    {
        _httpClient = httpClientFactory.CreateClient(options.Value.ClientName);
        _authenticationToken = options.Value.AuthenticationToken;
    }
    
    public async Task<List<GenreMainInfo>> GetGenres()
    {
        var response = await _httpClient.GetAsync($"genres?key={_authenticationToken}");

        string dataAsString = await response.Content.ReadAsStringAsync();

        RawgResponse<GenreMainInfo> result = JsonSerializer.Deserialize<RawgResponse<GenreMainInfo>>(dataAsString,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        return result.Results;
    }
}