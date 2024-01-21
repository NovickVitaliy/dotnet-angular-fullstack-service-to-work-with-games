using System.Reflection;
using GameProject.Domain.Models.Business.Games;
using GameProject.Domain.Models.Business.Games.Common;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Persistence.Context;

public class ApplicationDatabase : DbContext
{

    public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}