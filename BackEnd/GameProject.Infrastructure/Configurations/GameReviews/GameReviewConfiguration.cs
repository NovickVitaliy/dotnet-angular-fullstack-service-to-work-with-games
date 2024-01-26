using GameProject.Domain.Models.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Identity.Configurations.GameReviews;

public class GameReviewConfiguration : IEntityTypeConfiguration<GameReview>
{
    public void Configure(EntityTypeBuilder<GameReview> builder)
    {
        builder.ToTable("GameReviews");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Author)
            .WithMany(e => e.GameReviews)
            .HasForeignKey(e => e.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}