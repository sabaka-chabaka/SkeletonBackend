namespace SkeletonBackend.Application.Games.DTOs;

public record GameDto(
    Guid Id,
    string Name,
    string Description,
    Guid DeveloperId,
    string? CoverImageUrl,
    DateTime CreatedAt);