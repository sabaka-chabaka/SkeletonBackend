using SkeletonBackend.Domain.Builds;

namespace SkeletonBackend.Domain.Repositories;

public interface IBuildRepository
{
    Task<Build?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Build>> GetByGameIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task<Build?> GetLatestByGameIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task AddAsync(Build build, CancellationToken cancellationToken = default);
    void Update(Build build);
    void Remove(Build build);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
