using GameProject.Domain.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Persistence.Configurations.Games;

public class UsersStartedGameConfiguration : IEntityTypeConfiguration<UsersStartedGames>
{
    public void Configure(EntityTypeBuilder<UsersStartedGames> builder)
    {
        builder.ToTable("UsersStartedGames");

        builder.HasKey(e => new { e.UserId, e.StartedGameId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UsersStartedGames)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);;

        builder.HasOne(e => e.StartedGame)
            .WithMany(e => e.UsersStartedGames)
            .HasForeignKey(e => e.StartedGameId)
            .OnDelete(DeleteBehavior.Cascade);;
    }
}