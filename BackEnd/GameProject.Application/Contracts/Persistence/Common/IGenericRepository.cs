using System.Linq.Expressions;
using CloudinaryDotNet;

namespace GameProject.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<IQueryable<T>> GetByPredicateAsync(Expression<Func<T, bool>> predicate, bool trackChanges);
    Task DeleteAsync(T entity);
}