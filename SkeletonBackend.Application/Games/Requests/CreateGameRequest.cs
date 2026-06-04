namespace SkeletonBackend.Application.Games.Requests;

public record CreateGameRequest(
    string Name,
    string Description,
    Guid DeveloperId,
    string? CoverImageUrl);