using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkeletonBackend.Domain.Games;

namespace SkeletonBackend.Infrastructure.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(g => g.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(g => g.CoverImageUrl)
            .HasMaxLength(500);

        builder.HasMany(g => g.Builds)
            .WithOne(b => b.Game)
            .HasForeignKey(b => b.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
