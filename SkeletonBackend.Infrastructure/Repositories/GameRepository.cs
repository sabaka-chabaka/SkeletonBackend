using Microsoft.EntityFrameworkCore;
using SkeletonBackend.Domain.Games;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Infrastructure.Data;

namespace SkeletonBackend.Infrastructure.Repositories;

public class GameRepository(AppDbContext context) : IGameRepository
{
    public async Task<Game?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Include(g => g.Developer)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Games
            .Include(g => g.Developer)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Game game, CancellationToken cancellationToken = default)
    {
        await context.Games.AddAsync(game, cancellationToken);
    }

    public void Update(Game game)
    {
        context.Games.Update(game);
    }

    public void Remove(Game game)
    {
        context.Games.Remove(game);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
