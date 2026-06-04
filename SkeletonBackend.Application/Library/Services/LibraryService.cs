using SkeletonBackend.Application.Library.DTOs;
using SkeletonBackend.Application.Library.Mappings;
using SkeletonBackend.Domain.Library;
using SkeletonBackend.Domain.Repositories;

namespace SkeletonBackend.Application.Library.Services;

public class LibraryService(
    ILibraryRepository libraryRepository,
    IGameRepository gameRepository) : ILibraryService
{
    public async Task AddGameAsync(Guid userId, Guid gameId, CancellationToken cancellationToken = default)
    {
        var game = await gameRepository.GetByIdAsync(gameId, cancellationToken);
        if (game == null)
        {
            throw new Exception("Game not found.");
        }

        var existingItem = await libraryRepository.GetAsync(userId, gameId, cancellationToken);
        if (existingItem != null)
        {
            throw new Exception("Game is already in library.");
        }

        var item = new LibraryItem
        {
            UserId = userId,
            GameId = gameId,
            AddedAt = DateTime.UtcNow
        };

        await libraryRepository.AddAsync(item, cancellationToken);
        await libraryRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<LibraryGameDto>> GetLibraryAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var items = await libraryRepository.GetByUserIdAsync(userId, cancellationToken);
        return items.ToDto();
    }
}