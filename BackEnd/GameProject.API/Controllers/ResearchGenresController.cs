using GameProject.Application.Contracts.RawgApi.Genres;
using GameProject.Domain.Models.RawgApi.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ResearchGenresController : ControllerBase
{
    private readonly IGenresResearcher _genresResearcher;

    public ResearchGenresController(IGenresResearcher genresResearcher)
    {
        _genresResearcher = genresResearcher;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GenreMainInfo>>> GetGenres()
    {
        return Ok(await _genresResearcher.GetGenres());
    }
}