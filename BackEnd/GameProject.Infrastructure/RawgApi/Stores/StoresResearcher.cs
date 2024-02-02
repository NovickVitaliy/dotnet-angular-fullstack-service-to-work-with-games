using System.Text.Json;
using GameProject.Application.Contracts.RawgApi.Stores;
using GameProject.Domain.Models.RawgApi.Stores;
using GameProject.Infrastructure.Models.Games;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameProject.Identity.RawgApi.Stores;

public class StoresResearcher : IStoresResearcher
{
    private readonly HttpClient _http;
    private readonly string _authenticationToken;

    public StoresResearcher(IHttpClientFactory factory, IOptionsSnapshot<RawgSettings> snapshot)
    {
        _http = factory.CreateClient(snapshot.Value.ClientName);
        _authenticationToken = snapshot.Value.AuthenticationToken;
    }

    public async Task<Store> GetStoreInfo(int storeId)
    {
        var httpResponseMessage = await _http.GetAsync($"stores/{storeId}?key={_authenticationToken}");

        string content = await httpResponseMessage.Content.ReadAsStringAsync();

        Store store = JsonSerializer.Deserialize<Store>(content,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        return store;
    }
}