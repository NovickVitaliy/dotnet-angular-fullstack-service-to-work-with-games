using System.Text.Json;
using GameProject.Application.Contracts.RawgApi.Stores;
using GameProject.Application.Models.Bussiness.DTOs;
using GameProject.Domain.Models.RawgApi.Stores;
using GameProject.Infrastructure.Models.Games;
using Microsoft.Extensions.Options;

namespace GameProject.Identity.RawgApi.GameStores;

public class GameStoresResearcher : IGamesStoreResearcher
{
    private readonly HttpClient _http;
    private readonly string _authenticationToken;
    private readonly IStoresResearcher _storesResearcher;

    public GameStoresResearcher(IHttpClientFactory factory, IOptionsSnapshot<RawgSettings> snapshot,
        IStoresResearcher storesResearcher)
    {
        _storesResearcher = storesResearcher;
        _http = factory.CreateClient(snapshot.Value.ClientName);
        _authenticationToken = snapshot.Value.AuthenticationToken;
    }

    public async Task<List<GameStore>> GetGamesStoreForGame(int gameId)
    {
        var response = await _http.GetAsync($"games/{gameId}/stores?key={_authenticationToken}");

        string body = await response.Content.ReadAsStringAsync();

        RawgResponse<GameStore> gameStores = JsonSerializer.Deserialize<RawgResponse<GameStore>>(body,
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            })!;

        var tasksStore = gameStores.Results.Select(store => _storesResearcher.GetStoreInfo(store.Store_Id));
        

        Store[] stores = await Task.WhenAll(tasksStore);

        foreach (var gameStoresResult in gameStores.Results)
        {
            gameStoresResult.Name = stores.Single(st => st.Id == gameStoresResult.Store_Id).Name;
        }

        return gameStores.Results;
    }
}