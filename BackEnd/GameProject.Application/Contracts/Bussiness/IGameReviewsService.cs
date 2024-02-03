using GameProject.Application.Models.Bussiness.DTOs;
using GameProject.Application.Models.Bussiness.Requests;
using GameProject.Application.Models.Bussiness.Requests.GameReview;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Contracts.Bussiness;

public interface IGameReviewsService
{
    Task<PagedResult<GameReviewDto>> GetReviewsForGame(GetGameReviewsRequest getGameReviewsRequest);
    Task<GameReviewDto> CreateGameReviewReview(CreateGameReviewRequest createGameReviewRequest);
    Task<GameReviewDto> UpdateGameReview(UpdateGameReviewRequest updateGameReviewRequest);
    Task DeleteGameReview(DeleteGameReviewRequest deleteGameReviewRequest);
    Task<bool> HasUserReviewedTheGame(string userEmail, int gameRawgId);
    Task<PagedResult<GameReviewDto>> GetUserGameReviews(GetUserGameReviewsRequest getUserGameReviewsRequest);
}