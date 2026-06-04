using SkeletonBackend.Application.Games.DTOs;
using SkeletonBackend.Application.Games.Requests;

namespace SkeletonBackend.Application.Games.Services;

public interface IGameService
{
    Task<GameDto> CreateAsync(CreateGameRequest request, CancellationToken cancellationToken = default);
    Task<GameDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GameDto>> GetAllAsync(CancellationToken cancellationToken = default);
}