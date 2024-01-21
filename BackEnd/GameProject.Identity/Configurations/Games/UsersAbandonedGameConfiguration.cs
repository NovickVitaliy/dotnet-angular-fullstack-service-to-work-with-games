using GameProject.Domain.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Persistence.Configurations.Games;

public class UsersAbandonedGameConfiguration : IEntityTypeConfiguration<UsersAbandonedGames>
{
    public void Configure(EntityTypeBuilder<UsersAbandonedGames> builder)
    {
        builder.ToTable("UsersAbandonedGames");

        builder.HasKey(e => new { e.UserId, e.AbandonedGameId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UsersAbandonedGames)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AbandonedGame)
            .WithMany(e => e.UsersAbandonedGames)
            .HasForeignKey(e => e.AbandonedGameId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
}