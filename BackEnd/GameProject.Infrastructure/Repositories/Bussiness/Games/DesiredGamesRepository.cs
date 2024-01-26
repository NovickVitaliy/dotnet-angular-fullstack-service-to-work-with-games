using GameProject.Application.Contracts.Persistence;
using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.DbContext;

namespace GameProject.Identity.Repositories.Games;

public class DesiredGamesRepository : GenericRepository<DesiredGame>, IDesiredGamesRepository
{
    public DesiredGamesRepository(ApplicationIdentityDbContext db) : base(db)
    { }
}