using GameProject.Application.Contracts.Bussiness;
using GameProject.Application.Contracts.Persistence;
using GameProject.Application.Exceptions;
using GameProject.Application.Models;
using GameProject.Application.Models.Bussiness;
using GameProject.Domain.Models.Business.Games;
using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Identity;
using GameProject.Domain.Models.Shared;
using GameProject.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Application.Services;

public class UserGameListService : IUserGameListService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserGameListService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }


    public async Task AddToUserGameList(AddGameToListRequest addGameToListRequest)
    {
        var currentUser = (await _repositoryManager.UserRepository
                .GetByPredicateAsync(u => u.Email == addGameToListRequest.Email, true)
            ).Include(e => e.UsersStartedGames)
            .First();

        switch (addGameToListRequest.Status)
        {
            case GameStatus.Started:
                currentUser.UsersStartedGames.Add(new UsersStartedGames()
                {
                    StartedGame = new StartedGame()
                    {
                        RawgId = addGameToListRequest.Game.Id,
                        Name = addGameToListRequest.Game.Name,
                        BackgroundImage = addGameToListRequest.Game.Background_image,
                        Platform = addGameToListRequest.Platform
                    },
                    User = currentUser
                });
                break;
            case GameStatus.InProgress:
                currentUser.UsersInProgressGames.Add(new UsersInProgressGames()
                {
                    InProgressGame = new InProgressGame()
                    {
                        RawgId = addGameToListRequest.Game.Id,
                        Name = addGameToListRequest.Game.Name,
                        BackgroundImage = addGameToListRequest.Game.Background_image,
                        Platform = addGameToListRequest.Platform
                    },
                    User = currentUser
                });
                break;
            case GameStatus.Finished:
                currentUser.UsersFinishedGames.Add(new UsersFinishedGames()
                {
                    FinishedGame = new FinishedGame()
                    {
                        RawgId = addGameToListRequest.Game.Id,
                        Name = addGameToListRequest.Game.Name,
                        BackgroundImage = addGameToListRequest.Game.Background_image,
                        Platform = addGameToListRequest.Platform
                    },
                    User = currentUser
                });
                break;
            case GameStatus.Abandoned:
                currentUser.UsersAbandonedGames.Add(new UsersAbandonedGames()
                {
                    AbandonedGame = new AbandonedGame()
                    {
                        RawgId = addGameToListRequest.Game.Id,
                        Name = addGameToListRequest.Game.Name,
                        BackgroundImage = addGameToListRequest.Game.Background_image,
                        Platform = addGameToListRequest.Platform
                    },
                    User = currentUser
                });
                break;
            case GameStatus.Desired:
                currentUser.UsersDesiredGames.Add(new UsersDesiredGames()
                {
                    DesiredGame = new DesiredGame()
                    {
                        RawgId = addGameToListRequest.Game.Id,
                        Name = addGameToListRequest.Game.Name,
                        BackgroundImage = addGameToListRequest.Game.Background_image,
                        Platform = addGameToListRequest.Platform
                    },
                    User = currentUser
                });
                break;
            default:
                throw new BadRequestException("Error adding the gamme to the list");
        }

        await _repositoryManager.SaveChangesAsync();
    }

    public async Task RemoveFromUserGameList(RemoveGameFromListRequest removeGameFromListRequest)
    {
        var currentUserQuery = await _repositoryManager.UserRepository
            .GetByPredicateAsync(u => u.Email == removeGameFromListRequest.Email, true);
        ApplicationUser user;
        switch (removeGameFromListRequest.Status)
        {
            case GameStatus.Started:
                currentUserQuery.Include(e => e.UsersStartedGames)
                    .ThenInclude(e => e.StartedGame);
                user = currentUserQuery.First();
                var startedGameToDelete = user.UsersStartedGames
                    .First(e => e.StartedGame.RawgId == removeGameFromListRequest.GameToRemoveRawgId);
                user.UsersStartedGames.Remove(startedGameToDelete);

                break;
            case GameStatus.InProgress:
                currentUserQuery.Include(e => e.UsersInProgressGames)
                    .ThenInclude(e => e.InProgressGame);
                user = currentUserQuery.First();
                var inProgressGameToDelete = user.UsersInProgressGames
                    .First(e => e.InProgressGame.RawgId == removeGameFromListRequest.GameToRemoveRawgId);
                user.UsersInProgressGames.Remove(inProgressGameToDelete);

                break;
            case GameStatus.Finished:
                currentUserQuery.Include(e => e.UsersFinishedGames)
                    .ThenInclude(e => e.FinishedGame);

                user = currentUserQuery.First();
                var finished = user.UsersFinishedGames.First(e =>
                    e.FinishedGame.RawgId == removeGameFromListRequest.GameToRemoveRawgId);
                user.UsersFinishedGames.Remove(finished);
                break;
            case GameStatus.Abandoned:
                currentUserQuery.Include(e => e.UsersAbandonedGames)
                    .ThenInclude(e => e.AbandonedGame);
                user = currentUserQuery.First();
                var abandonedGameToDelete = user.UsersAbandonedGames.First(e =>
                    e.AbandonedGame.RawgId == removeGameFromListRequest.GameToRemoveRawgId);
                user.UsersAbandonedGames.Remove(abandonedGameToDelete);
                break;
            case GameStatus.Desired:
                currentUserQuery.Include(e => e.UsersDesiredGames)
                    .ThenInclude(e => e.DesiredGame);
                user = currentUserQuery.First();
                var desiredGameToDelete = user.UsersDesiredGames.First(e =>
                    e.DesiredGame.RawgId == removeGameFromListRequest.GameToRemoveRawgId);
                user.UsersDesiredGames.Remove(desiredGameToDelete);
                break;
            default:
                throw new BadRequestException("Error removing the game from the list");
        }

        await _repositoryManager.SaveChangesAsync();
    }

    public async Task ChangeStatusOfGameInUserList(ChangeGameStatusRequest changeGameStatusRequest)
    {
        await RemoveFromUserGameList(new RemoveGameFromListRequest()
        {
            Email = changeGameStatusRequest.Email,
            GameToRemoveRawgId = changeGameStatusRequest.GameRawgId,
            Status = changeGameStatusRequest.OldStatus
        });

        await AddToUserGameList(new AddGameToListRequest()
        {
            Email = changeGameStatusRequest.Email,
            Game = changeGameStatusRequest.Game,
            Status = changeGameStatusRequest.NewStatus,
            Platform = changeGameStatusRequest.Platform,
        });
    }
}