using System.Linq.Expressions;
using GameProject.Application.Contracts.Persistence;
using GameProject.Identity.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Identity.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationIdentityDbContext _db;

    public GenericRepository(ApplicationIdentityDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Set<T>().Update(entity);
    }

    public async Task<IQueryable<T>> GetByPredicateAsync(Expression<Func<T, bool>> predicate, bool trackChanges)
    {
        return trackChanges
            ? _db.Set<T>().Where(predicate)
            : _db.Set<T>().Where(predicate).AsNoTracking();
    }

    public async Task DeleteAsync(T entity)
    {
        _db.Set<T>().Remove(entity);
    }
}