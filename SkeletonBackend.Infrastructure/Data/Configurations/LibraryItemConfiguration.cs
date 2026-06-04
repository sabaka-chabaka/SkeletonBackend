using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkeletonBackend.Domain.Library;

namespace SkeletonBackend.Infrastructure.Data.Configurations;

public class LibraryItemConfiguration : IEntityTypeConfiguration<LibraryItem>
{
    public void Configure(EntityTypeBuilder<LibraryItem> builder)
    {
        builder.HasKey(li => new { li.UserId, li.GameId });

        builder.HasOne(li => li.User)
            .WithMany(u => u.LibraryItems)
            .HasForeignKey(li => li.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(li => li.Game)
            .WithMany(g => g.LibraryItems)
            .HasForeignKey(li => li.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
