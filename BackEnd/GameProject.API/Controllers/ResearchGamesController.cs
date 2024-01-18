using GameProject.Application.Contracts.Games;
using GameProject.Domain.Models;
using GameProject.Identity.Extensions;
using GameProject.Infrastructure.RawgApi.Models.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ResearchGamesController : ControllerBase
{
    private readonly IGamesResearcher _gamesResearcher;

    public ResearchGamesController(IGamesResearcher gamesResearcher)
    {
        _gamesResearcher = gamesResearcher;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GameCardItem>>> Top10HighestRatedGamesOfAllTime()
    {
        return Ok(await _gamesResearcher.Get10HighestRatedGamesOfAllTime());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GameMainInfo>>> Games([FromQuery] GameFilterQuery filterQuery)
    {
        return Ok(await _gamesResearcher.GetGames(filterQuery));
    }

    [HttpGet("{gameId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GameAllInfo>> GetGameInfo([FromRoute] int gameId)
    {
        return Ok(await _gamesResearcher.GetGameInfo(gameId));
    }

    [HttpGet("{gameId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GameScreenshot>>> GetGamesScreenshots([FromRoute] int gameId)
    {
        return Ok(await _gamesResearcher.GetGamesScreenshots(gameId));
    }

    [HttpGet("{gameId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GameTrailer>>> GetGamesTrailers([FromRoute] int gameId)
    {
        return Ok(await _gamesResearcher.GetGamesTrailers(gameId));
    }
}