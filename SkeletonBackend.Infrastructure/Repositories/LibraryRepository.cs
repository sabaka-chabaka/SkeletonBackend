using Microsoft.EntityFrameworkCore;
using SkeletonBackend.Domain.Library;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Infrastructure.Data;

namespace SkeletonBackend.Infrastructure.Repositories;

public class LibraryRepository(AppDbContext context) : ILibraryRepository
{
    public async Task<LibraryItem?> GetAsync(Guid userId, Guid gameId, CancellationToken cancellationToken = default)
    {
        return await context.LibraryItems
            .FirstOrDefaultAsync(li => li.UserId == userId && li.GameId == gameId, cancellationToken);
    }

    public async Task<IEnumerable<LibraryItem>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await context.LibraryItems
            .Include(li => li.Game)
            .Where(li => li.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(LibraryItem item, CancellationToken cancellationToken = default)
    {
        await context.LibraryItems.AddAsync(item, cancellationToken);
    }

    public void Remove(LibraryItem item)
    {
        context.LibraryItems.Remove(item);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
