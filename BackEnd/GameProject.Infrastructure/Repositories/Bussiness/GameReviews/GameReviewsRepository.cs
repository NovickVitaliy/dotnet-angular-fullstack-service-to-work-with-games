using GameProject.Application.Contracts.Persistence.Bussiness.GameReviews;
using GameProject.Domain.Models.Business;
using GameProject.Identity.DbContext;

namespace GameProject.Identity.Repositories.Bussiness.GameReviews;

public class GameReviewsRepository : GenericRepository<GameReview>, IGameReviewsRepository
{
    public GameReviewsRepository(ApplicationIdentityDbContext db) : base(db)
    { }
}