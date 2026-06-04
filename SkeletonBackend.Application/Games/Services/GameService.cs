using SkeletonBackend.Application.Games.DTOs;
using SkeletonBackend.Application.Games.Mappings;
using SkeletonBackend.Application.Games.Requests;
using SkeletonBackend.Domain.Games;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Domain.Services;

namespace SkeletonBackend.Application.Games.Services;

public class GameService(IGameRepository gameRepository, ICacheService cacheService) : IGameService
{
    private const string AllGamesCacheKey = "all_games";
    private static string GetGameCacheKey(Guid id) => $"game_{id}";

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

        await cacheService.RemoveAsync(AllGamesCacheKey, cancellationToken);

        return game.ToDto();
    }

    public async Task<GameDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cacheKey = GetGameCacheKey(id);
        var cachedGame = await cacheService.GetAsync<GameDto>(cacheKey, cancellationToken);
        if (cachedGame is not null)
        {
            return cachedGame;
        }

        var game = await gameRepository.GetByIdAsync(id, cancellationToken);
        if (game is null)
        {
            return null;
        }

        var dto = game.ToDto();
        await cacheService.SetAsync(cacheKey, dto, cancellationToken: cancellationToken);
        
        return dto;
    }

    public async Task<IEnumerable<GameDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cachedGames = await cacheService.GetAsync<IEnumerable<GameDto>>(AllGamesCacheKey, cancellationToken);
        if (cachedGames is not null)
        {
            return cachedGames;
        }

        var games = await gameRepository.GetAllAsync(cancellationToken);
        var dtos = games.ToDto().ToList();

        await cacheService.SetAsync(AllGamesCacheKey, dtos, cancellationToken: cancellationToken);

        return dtos;
    }
}