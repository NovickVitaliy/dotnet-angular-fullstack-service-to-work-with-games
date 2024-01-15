using GameProject.Application.Contracts.Games;
using GameProject.Domain.Models;
using GameProject.Identity.Extensions;
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
}