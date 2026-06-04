using SkeletonBackend.Application.Games.DTOs;
using SkeletonBackend.Application.Games.Mappings;
using SkeletonBackend.Application.Games.Requests;
using SkeletonBackend.Domain.Games;
using SkeletonBackend.Domain.Repositories;

namespace SkeletonBackend.Application.Games.Services;

public class GameService(IGameRepository gameRepository) : IGameService
{
    public async Task<GameDto> CreateAsync(CreateGameRequest request, CancellationToken cancellationToken = default)
    {
        var game = new Game
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            DeveloperId = request.DeveloperId,
            CoverImageUrl = request.CoverImageUrl,
            CreatedAt = DateTime.UtcNow
        };

        await gameRepository.AddAsync(game, cancellationToken);
        await gameRepository.SaveChangesAsync(cancellationToken);

        return game.ToDto();
    }

    public async Task<GameDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var game = await gameRepository.GetByIdAsync(id, cancellationToken);
        return game?.ToDto();
    }

    public async Task<IEnumerable<GameDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var games = await gameRepository.GetAllAsync(cancellationToken);
        return games.ToDto();
    }
}