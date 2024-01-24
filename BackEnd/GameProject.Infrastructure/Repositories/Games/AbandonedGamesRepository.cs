using GameProject.Application.Contracts.Persistence;
using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.DbContext;

namespace GameProject.Identity.Repositories.Games;

public class AbandonedGamesRepository : GenericRepository<AbandonedGame>, IAbandonedGamesRepository
{
    public AbandonedGamesRepository(ApplicationIdentityDbContext db) : base(db)
    { }
}