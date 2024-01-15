using GameProject.Application.Contracts.RawgApi.Platforms;
using GameProject.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ResearchPlatformsController : ControllerBase
{
    private readonly IPlatformsResearcher _platformsResearcher;

    public ResearchPlatformsController(IPlatformsResearcher platformsResearcher)
    {
        _platformsResearcher = platformsResearcher;
    }

    [HttpGet] 
    [ProducesResponseType(StatusCodes.Status200OK)] [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GamingPlatform>>> AllGamingPlatforms()
    {
        return(await _platformsResearcher.GetAllPlatforms());
    }
}