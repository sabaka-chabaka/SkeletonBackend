using Microsoft.EntityFrameworkCore;
using SkeletonBackend.Domain.Identity;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Infrastructure.Data;

namespace SkeletonBackend.Infrastructure.Repositories;

public class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == token, cancellationToken);
    }

    public async Task AddAsync(RefreshToken token, CancellationToken cancellationToken = default)
    {
        await context.RefreshTokens.AddAsync(token, cancellationToken);
    }

    public void Remove(RefreshToken token)
    {
        context.RefreshTokens.Remove(token);
    }

    public void RemoveRange(IEnumerable<RefreshToken> tokens)
    {
        context.RefreshTokens.RemoveRange(tokens);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
