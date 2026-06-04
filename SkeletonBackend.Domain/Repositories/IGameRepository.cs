using SkeletonBackend.Domain.Games;

namespace SkeletonBackend.Domain.Repositories;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Game game, CancellationToken cancellationToken = default);
    void Update(Game game);
    void Remove(Game game);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
