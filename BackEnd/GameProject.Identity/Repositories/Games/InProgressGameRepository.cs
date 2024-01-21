using GameProject.Application.Contracts.Persistence;
using GameProject.Domain.Models.Business.Games;
using GameProject.Identity.DbContext;

namespace GameProject.Identity.Repositories.Games;

public class InProgressGameRepository : GenericRepository<InProgressGame>, IInProgressGameRepository
{
    public InProgressGameRepository(ApplicationIdentityDbContext db) : base(db)
    { }
}