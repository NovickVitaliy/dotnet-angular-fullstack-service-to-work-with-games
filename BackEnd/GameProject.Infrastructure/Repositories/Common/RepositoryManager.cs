using GameProject.Application.Contracts.Persistence;
using GameProject.Application.Contracts.Persistence.Bussiness.GameReviews;
using GameProject.Identity.Contracts.Repositories;
using GameProject.Identity.DbContext;
using GameProject.Identity.Repositories.Bussiness.GameReviews;
using GameProject.Identity.Repositories.Games;

namespace GameProject.Identity.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationIdentityDbContext _db;
    private readonly Lazy<IUserRepository> _lazyUserRepo;
    private readonly Lazy<IPhotoRepository> _lazyPhotoRepo;
    private readonly Lazy<IStartedGamesRepository> _lazyStartedGamesRepo;
    private readonly Lazy<IInProgressGameRepository> _lazyInProgressGamesRepo;
    private readonly Lazy<IFinishedGamesRepository> _lazyFinishedGamesRepo;
    private readonly Lazy<IAbandonedGamesRepository> _lazyAbandonedGamesRepo;
    private readonly Lazy<IDesiredGamesRepository> _lazyDesiredGamesRepo;
    private readonly Lazy<IGameReviewsRepository> _lazyGameReviewsRepo;

    public RepositoryManager(ApplicationIdentityDbContext db)
    {
        _db = db;
        _lazyPhotoRepo = new Lazy<IPhotoRepository>(() => new PhotoRepository(db));
        _lazyUserRepo = new Lazy<IUserRepository>(() => new UserRepository(db));
        _lazyStartedGamesRepo = new Lazy<IStartedGamesRepository>(() => new StartedGamesRepository(db));
        _lazyInProgressGamesRepo = new Lazy<IInProgressGameRepository>(() => new InProgressGameRepository(db));
        _lazyFinishedGamesRepo = new Lazy<IFinishedGamesRepository>(() => new FinishedGamesRepository(db));
        _lazyAbandonedGamesRepo = new Lazy<IAbandonedGamesRepository>(() => new AbandonedGamesRepository(db));
        _lazyDesiredGamesRepo = new Lazy<IDesiredGamesRepository>(() => new DesiredGamesRepository(db));
        _lazyGameReviewsRepo = new Lazy<IGameReviewsRepository>(() => new GameReviewsRepository(db));
    }

    public IUserRepository UserRepository => _lazyUserRepo.Value;
    public IPhotoRepository PhotoRepository => _lazyPhotoRepo.Value;
    public IStartedGamesRepository StartedGamesRepository => _lazyStartedGamesRepo.Value;
    public IInProgressGameRepository InProgressGameRepository => _lazyInProgressGamesRepo.Value;
    public IFinishedGamesRepository FinishedGamesRepository => _lazyFinishedGamesRepo.Value;
    public IAbandonedGamesRepository AbandonedGamesRepository => _lazyAbandonedGamesRepo.Value;
    public IDesiredGamesRepository DesiredGamesRepository => _lazyDesiredGamesRepo.Value;
    public IGameReviewsRepository GameReviewsRepository => _lazyGameReviewsRepo.Value;
    
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}