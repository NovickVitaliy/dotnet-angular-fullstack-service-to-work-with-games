using GameProject.Application.Contracts.Bussiness;
using GameProject.Application.Models.Bussiness.DTOs;
using GameProject.Application.Models.Bussiness.Requests;
using GameProject.Application.Models.Bussiness.Requests.GameReview;
using GameProject.Application.Models.Shared;
using GameProject.Domain.Models.Business;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GameReviewsController : ControllerBase
{
    private readonly IGameReviewsService _gameReviewsService;

    public GameReviewsController(IGameReviewsService gameReviewsService)
    {
        _gameReviewsService = gameReviewsService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PagedResult<GameReview>>> GetReviewsForGame(
        [FromQuery] GetGameReviewsRequest getGameReviewsRequest)
    {
        return Ok(await _gameReviewsService.GetReviewsForGame(getGameReviewsRequest));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GameReviewDto>> CreateGameReview(CreateGameReviewRequest createGameReviewRequest)
    {
        return Ok(await _gameReviewsService.CreateGameReviewReview(createGameReviewRequest));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GameReviewDto>> UpdateGameReview(UpdateGameReviewRequest updateGameReviewRequest)
    {
        return Ok(await _gameReviewsService.UpdateGameReview(updateGameReviewRequest));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteGameReview([FromQuery]DeleteGameReviewRequest deleteGameReviewRequest)
    {
        await _gameReviewsService.DeleteGameReview(deleteGameReviewRequest);
        return Ok();
    }
}