using GameProject.Application.Contracts.Persistence.Bussiness.GameReviews;
using GameProject.Identity.Contracts.Repositories;

namespace GameProject.Application.Contracts.Persistence;

public interface IRepositoryManager
{
    IUserRepository UserRepository { get; }
    IPhotoRepository PhotoRepository { get; }
    IStartedGamesRepository StartedGamesRepository { get; }
    IInProgressGameRepository InProgressGameRepository { get; }
    IFinishedGamesRepository FinishedGamesRepository { get; }
    IAbandonedGamesRepository AbandonedGamesRepository { get; }
    IDesiredGamesRepository DesiredGamesRepository { get; }
    IGameReviewsRepository GameReviewsRepository { get; }
    Task SaveChangesAsync();
}