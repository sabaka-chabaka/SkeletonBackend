using SkeletonBackend.Domain.Identity;

namespace SkeletonBackend.Domain.Repositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default);
    Task AddAsync(RefreshToken token, CancellationToken cancellationToken = default);
    void Remove(RefreshToken token);
    void RemoveRange(IEnumerable<RefreshToken> tokens);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
