using Microsoft.EntityFrameworkCore;
using SkeletonBackend.Domain.Builds;
using SkeletonBackend.Domain.Games;
using SkeletonBackend.Domain.Identity;
using SkeletonBackend.Domain.Library;

namespace SkeletonBackend.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Build> Builds => Set<Build>();
    public DbSet<LibraryItem> LibraryItems => Set<LibraryItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
