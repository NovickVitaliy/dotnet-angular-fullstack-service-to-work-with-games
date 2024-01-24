using System.Text.Json;
using GameProject.Application.Contracts.RawgApi.Platforms;
using GameProject.Domain.Models;
using GameProject.Infrastructure.Models.Games;
using Microsoft.Extensions.Options;

namespace GameProject.Infrastructure.RawgApi.Platforms;

public class PlatformsResearcher : IPlatformsResearcher
{
    private readonly HttpClient _httpClient;
    private readonly string _authenticationToken;
    public PlatformsResearcher(IHttpClientFactory httpClient, IOptions<RawgSettings> options)
    {
        _httpClient = httpClient.CreateClient(options.Value.ClientName);
        _authenticationToken = options.Value.AuthenticationToken;
    }

    public async Task<List<GamingPlatform>> GetAllPlatforms()
    {
        var response = await _httpClient.GetAsync($"platforms?key={_authenticationToken}");

        var dataAsString = await response.Content.ReadAsStringAsync();
        
        RawgResponse<GamingPlatform> data =
            JsonSerializer.Deserialize<RawgResponse<GamingPlatform>>(dataAsString, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true})!;

        return data.Results;
    }
}