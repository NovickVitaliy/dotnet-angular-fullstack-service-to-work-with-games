using GameProject.Domain.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Persistence.Configurations.Games;

public class UsersDesiredGamesConfiguration : IEntityTypeConfiguration<UsersDesiredGames>
{
    public void Configure(EntityTypeBuilder<UsersDesiredGames> builder)
    {
        builder.ToTable("UsersDesiredGames");

        builder.HasKey(e => new { e.UserId, e.DesiredGameId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UsersDesiredGames)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DesiredGame)
            .WithMany(e => e.UsersDesiredGames)
            .HasForeignKey(e => e.DesiredGameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}