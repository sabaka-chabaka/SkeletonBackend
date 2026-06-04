using Microsoft.EntityFrameworkCore;
using SkeletonBackend.Domain.Builds;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Infrastructure.Data;

namespace SkeletonBackend.Infrastructure.Repositories;

public class BuildRepository(AppDbContext context) : IBuildRepository
{
    public async Task<Build?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Builds
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Build>> GetByGameIdAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        return await context.Builds
            .Where(b => b.GameId == gameId)
            .OrderByDescending(b => b.UploadedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Build?> GetLatestByGameIdAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        return await context.Builds
            .Where(b => b.GameId == gameId && b.IsLatest)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Build build, CancellationToken cancellationToken = default)
    {
        await context.Builds.AddAsync(build, cancellationToken);
    }

    public void Update(Build build)
    {
        context.Builds.Update(build);
    }

    public void Remove(Build build)
    {
        context.Builds.Remove(build);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
