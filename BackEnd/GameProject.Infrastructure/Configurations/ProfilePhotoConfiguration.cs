using GameProject.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameProject.Identity.Configurations;

public class ProfilePhotoConfiguration : IEntityTypeConfiguration<ProfilePhoto>
{
    public void Configure(EntityTypeBuilder<ProfilePhoto> builder)
    {
        builder.ToTable("ProfilePhotos");

        builder.HasOne(p => p.User)
            .WithOne(u => u.ProfilePhoto)
            .HasForeignKey<ProfilePhoto>(p => p.UserId);
    }
}