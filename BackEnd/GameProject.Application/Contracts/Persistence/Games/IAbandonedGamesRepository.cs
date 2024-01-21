using GameProject.Domain.Models.Business.Games;

namespace GameProject.Application.Contracts.Persistence;

public interface IAbandonedGamesRepository : IGenericRepository<AbandonedGame>
{
    
}