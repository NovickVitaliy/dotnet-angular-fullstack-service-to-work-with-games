using GameProject.Application.Contracts.RawgApi.Stores;
using GameProject.Application.Models.Bussiness.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[ApiController]
[Route("api/games/{gameId}/stores")]
public class GameStoresController : ControllerBase
{
    private readonly IGamesStoreResearcher _gamesStoreResearcher;

    public GameStoresController(IGamesStoreResearcher gamesStoreResearcher)
    {
        _gamesStoreResearcher = gamesStoreResearcher;
    }

    [HttpGet]
    public async Task<ActionResult<List<GameStore>>> GetGamesStoresForGame(int gameId)
    {
        return await _gamesStoreResearcher.GetGamesStoreForGame(gameId);
    }
}