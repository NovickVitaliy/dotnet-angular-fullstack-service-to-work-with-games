using System.Linq.Expressions;
using GameProject.Application.Contracts.Persistence;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Contracts.Repositories;
using GameProject.Identity.DbContext;
using GameProject.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Identity.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationIdentityDbContext _db;

    public UserRepository(ApplicationIdentityDbContext db)
    {
        _db = db;
    }

    public async Task<IQueryable<ApplicationUser>> GetByPredicateAsync(Expression<Func<ApplicationUser, bool>> predicate, bool trackChanges)
    {
        return trackChanges
            ? _db.Users.Where(predicate)
            : _db.Users.Where(predicate)
                .AsNoTracking();
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}