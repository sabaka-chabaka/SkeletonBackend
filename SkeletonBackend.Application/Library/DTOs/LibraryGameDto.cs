namespace SkeletonBackend.Application.Library.DTOs;

public record LibraryGameDto(
    Guid GameId,
    string GameName,
    string? CoverImageUrl,
    DateTime AddedAt);