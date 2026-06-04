using SkeletonBackend.Domain.Library;

namespace SkeletonBackend.Domain.Repositories;

public interface ILibraryRepository
{
    Task<LibraryItem?> GetAsync(Guid userId, Guid gameId, CancellationToken cancellationToken = default);
    Task<IEnumerable<LibraryItem>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddAsync(LibraryItem item, CancellationToken cancellationToken = default);
    void Remove(LibraryItem item);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
