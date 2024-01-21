using GameProject.Application.Contracts.Bussiness;
using GameProject.Application.Models.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountGameListController : ControllerBase
{
    private readonly IUserGameListService _userGameListService;

    public AccountGameListController(IUserGameListService userGameListService)
    {
        _userGameListService = userGameListService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> AddGameToUserList(AddGameToListRequest addGameToListRequest)
    {
        await _userGameListService.AddToUserGameList(addGameToListRequest);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> RemoveGameFromUserList(RemoveGameFromListRequest removeGameFromListRequest)
    {
        await _userGameListService.RemoveFromUserGameList(removeGameFromListRequest);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ChangeGameStatusInUserList(ChangeGameStatusRequest changeGameStatusRequest)
    {
        await _userGameListService.ChangeStatusOfGameInUserList(changeGameStatusRequest);
        return Ok();
    }
}