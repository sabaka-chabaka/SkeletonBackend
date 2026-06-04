using SkeletonBackend.Application.Games.DTOs;
using SkeletonBackend.Domain.Games;

namespace SkeletonBackend.Application.Games.Mappings;

public static class GameMappings
{
    public static GameDto ToDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Description,
            game.DeveloperId,
            game.CoverImageUrl,
            game.CreatedAt);
    }

    public static IEnumerable<GameDto> ToDto(this IEnumerable<Game> games)
    {
        return games.Select(ToDto);
    }
}