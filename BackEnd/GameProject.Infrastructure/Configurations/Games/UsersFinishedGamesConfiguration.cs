using GameProject.Domain.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Persistence.Configurations.Games;

public class UsersFinishedGamesConfiguration : IEntityTypeConfiguration<UsersFinishedGames>
{
    public void Configure(EntityTypeBuilder<UsersFinishedGames> builder)
    {
        builder.ToTable("UsersFinishedGames");

        builder.HasKey(e => new { e.UserId, e.FinishedGameId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UsersFinishedGames)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);;

        builder.HasOne(e => e.FinishedGame)
            .WithMany(e => e.UsersFinishedGames)
            .HasForeignKey(e => e.FinishedGameId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
}