using GameProject.Application.Contracts.Bussiness;
using GameProject.Application.Models.Bussiness;
using GameProject.Identity.Extensions;
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
        addGameToListRequest.Email = User.GetUserEmail();
        await _userGameListService.AddToUserGameList(addGameToListRequest);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> RemoveGameFromUserList(RemoveGameFromListRequest removeGameFromListRequest)
    {
        removeGameFromListRequest.Email = User.GetUserEmail();
        await _userGameListService.RemoveFromUserGameList(removeGameFromListRequest);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ChangeGameStatusInUserList(ChangeGameStatusRequest changeGameStatusRequest)
    {
        changeGameStatusRequest.Email = User.GetUserEmail();
        await _userGameListService.ChangeStatusOfGameInUserList(changeGameStatusRequest);
        return Ok();
    }
}