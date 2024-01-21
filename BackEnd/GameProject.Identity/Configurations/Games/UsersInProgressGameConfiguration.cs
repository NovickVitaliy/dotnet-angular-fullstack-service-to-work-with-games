using GameProject.Domain.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Persistence.Configurations.Games;

public class UsersInProgressGameConfiguration : IEntityTypeConfiguration<UsersInProgressGames>
{
    public void Configure(EntityTypeBuilder<UsersInProgressGames> builder)
    {
        builder.ToTable("UsersInProgressGames");

        builder.HasKey(e => new { e.UserId, e.InProgressGameId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UsersInProgressGames)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);;

        builder.HasOne(e => e.InProgressGame)
            .WithMany(e => e.UsersInProgressGames)
            .HasForeignKey(e => e.InProgressGameId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
}