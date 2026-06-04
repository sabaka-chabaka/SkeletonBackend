using SkeletonBackend.Application.Library.DTOs;

namespace SkeletonBackend.Application.Library.Services;

public interface ILibraryService
{
    Task AddGameAsync(Guid userId, Guid gameId, CancellationToken cancellationToken = default);
    Task<IEnumerable<LibraryGameDto>> GetLibraryAsync(Guid userId, CancellationToken cancellationToken = default);
}