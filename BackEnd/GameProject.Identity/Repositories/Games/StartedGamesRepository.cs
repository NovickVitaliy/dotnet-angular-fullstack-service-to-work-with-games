using GameProject.Application.Contracts.Persistence;
using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.DbContext;

namespace GameProject.Identity.Repositories.Games;

public class StartedGamesRepository : GenericRepository<StartedGame>, IStartedGamesRepository
{
    public StartedGamesRepository(ApplicationIdentityDbContext db) : base(db)
    { }
}