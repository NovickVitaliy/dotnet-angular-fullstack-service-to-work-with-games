using GameProject.Application.Contracts.Persistence;
using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.DbContext;

namespace GameProject.Identity.Repositories.Games;

public class FinishedGamesRepository : GenericRepository<FinishedGame>, IFinishedGamesRepository
{
    public FinishedGamesRepository(ApplicationIdentityDbContext db) : base(db)
    { }
}