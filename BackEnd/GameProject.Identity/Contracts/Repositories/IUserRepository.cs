using System.Linq.Expressions;
using GameProject.Application.Contracts.Persistence;
using GameProject.Identity.Models;

namespace GameProject.Identity.Contracts.Repositories;

public interface IUserRepository
{
    Task<IQueryable<ApplicationUser>> GetByPredicateAsync(Expression<Func<ApplicationUser, bool>> predicate,
        bool trackChanges);

    Task SaveChangesAsync();

}