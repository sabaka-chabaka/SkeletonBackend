using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkeletonBackend.Domain.Builds;

namespace SkeletonBackend.Infrastructure.Data.Configurations;

public class BuildConfiguration : IEntityTypeConfiguration<Build>
{
    public void Configure(EntityTypeBuilder<Build> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Version)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.ArchivePath)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(b => b.Hash)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.ExecutablePath)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(b => b.Changelog)
            .HasMaxLength(5000);
    }
}
