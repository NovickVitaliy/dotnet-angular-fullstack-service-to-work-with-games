using AutoMapper;
using GameProject.Application.Contracts.Bussiness;
using GameProject.Application.Contracts.Persistence;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Bussiness.DTOs;
using GameProject.Application.Models.Bussiness.Requests;
using GameProject.Application.Models.Bussiness.Requests.GameReview;
using GameProject.Application.Models.Shared;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.IdentityHelpers.AuthorizationAttributes.EmailConfirmed;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Identity.Services.Bussiness.GameReview;

public class GameReviewService : IGameReviewsService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GameReviewService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<PagedResult<GameReviewDto>> GetReviewsForGame(GetGameReviewsRequest getGameReviewsRequest)
    {
        var items =
            (await _repositoryManager.GameReviewsRepository.GetByPredicateAsync(
                review => review.GameRawgId == getGameReviewsRequest.GameRawgId, false));

        var itemsToReturn = items.Skip((getGameReviewsRequest.Page - 1) * getGameReviewsRequest.ItemsPerPage)
            .Take(getGameReviewsRequest.ItemsPerPage);

        return new PagedResult<GameReviewDto>()
        {
            ItemsPerPage = getGameReviewsRequest.ItemsPerPage,
            CurrentPage = getGameReviewsRequest.Page,
            TotalCount = await items.CountAsync(),
            Items = await _mapper.ProjectTo<GameReviewDto>(itemsToReturn).ToListAsync()
        };
    }

    [EmailConfirmed(true)]
    public async Task<GameReviewDto> CreateGameReviewReview(CreateGameReviewRequest createGameReviewRequest)
    {
        var currentUser = await GetUser(createGameReviewRequest.Email);
        Domain.Models.Business.GameReview gameReview = new Domain.Models.Business.GameReview()
        {
            GameRawgId = createGameReviewRequest.GameRawgId,
            Author = currentUser,
            Review = createGameReviewRequest.Review,
            Score = createGameReviewRequest.Score,
            AuthorId = currentUser.Id,
            DateWritten = DateTime.UtcNow,
            GameName = createGameReviewRequest.GameName
        };

        currentUser.GameReviews.Add(gameReview);
        await _repositoryManager.SaveChangesAsync();
        return _mapper.Map<GameReviewDto>(gameReview);
    }

    public async Task<GameReviewDto> UpdateGameReview(UpdateGameReviewRequest updateGameReviewRequest)
    {
        var currentUser = await GetUser(updateGameReviewRequest.Email);
        var gameReview = currentUser.GameReviews.SingleOrDefault(e => e.Id == updateGameReviewRequest.ReviewId);

        if (gameReview is null) throw new BadRequestException("Such review does not exist!");

        _mapper.Map(updateGameReviewRequest, gameReview);

        await _repositoryManager.SaveChangesAsync();

        return _mapper.Map<GameReviewDto>(gameReview);
    }

    public async Task DeleteGameReview(DeleteGameReviewRequest deleteGameReviewRequest)
    {
        var currentUser = await GetUser(deleteGameReviewRequest.Email!);

        var reviewToDelete = currentUser.GameReviews.FirstOrDefault(e => e.Id == deleteGameReviewRequest.ReviewId);
        if (reviewToDelete is null) throw new BadRequestException("Such review does not exist");
        currentUser.GameReviews.Remove(reviewToDelete);

        await _repositoryManager.SaveChangesAsync();
    }

    public async Task<bool> HasUserReviewedTheGame(string userEmail, int gameRawgId)
    {
        var user = await GetUser(userEmail);

        return user.GameReviews.Any(re => re.GameRawgId == gameRawgId);
    }

    public async Task<PagedResult<GameReviewDto>> GetUserGameReviews(GetUserGameReviewsRequest getUserGameReviewsRequest)
    {
        var user = await GetUser(getUserGameReviewsRequest.Email);

        return new PagedResult<GameReviewDto>()
        {
            TotalCount = user.GameReviews.Count,
            CurrentPage = getUserGameReviewsRequest.Page,
            ItemsPerPage = getUserGameReviewsRequest.ItemsPerPage,
            Items = _mapper.Map<List<GameReviewDto>>(user.GameReviews.Skip((getUserGameReviewsRequest.Page - 1)* getUserGameReviewsRequest.ItemsPerPage)
                .Take(getUserGameReviewsRequest.ItemsPerPage))
        };
    }

    private async Task<ApplicationUser> GetUser(string email)
    {
        return await (await
                _repositoryManager.UserRepository.GetByPredicateAsync(e => e.Email == email,
                    true))
            .SingleAsync();
    }
}