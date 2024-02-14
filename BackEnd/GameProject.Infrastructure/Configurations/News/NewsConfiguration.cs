using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Identity.Configurations.News;

public class NewsConfiguration : IEntityTypeConfiguration<Domain.Models.News.News>
{
    public void Configure(EntityTypeBuilder<Domain.Models.News.News> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Author)
            .WithMany(e => e.PublishedNews)
            .HasForeignKey(e => e.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}