using System.Reflection;
using GameProject.Domain.Models.Business;
using GameProject.Domain.Models.Business.Games;
using GameProject.Domain.Models.Business.Games.Common;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Identity.DbContext;

public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<StartedGame> StartedGames { get; set; }
    public DbSet<InProgressGame> InProgressGames { get; set; }
    public DbSet<FinishedGame> FinishedGames { get; set; }
    public DbSet<AbandonedGame> AbandonedGames { get; set; }
    public DbSet<DesiredGame> DesiredGames { get; set; }
    public DbSet<GameReview> GameReviews { get; set; }
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<BaseGame>().UseTpcMappingStrategy();
    }
}