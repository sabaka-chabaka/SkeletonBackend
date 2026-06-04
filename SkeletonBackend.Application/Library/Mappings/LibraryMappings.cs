using SkeletonBackend.Application.Library.DTOs;
using SkeletonBackend.Domain.Library;

namespace SkeletonBackend.Application.Library.Mappings;

public static class LibraryMappings
{
    public static LibraryGameDto ToDto(this LibraryItem item)
    {
        return new LibraryGameDto(
            item.GameId,
            item.Game?.Name ?? string.Empty,
            item.Game?.CoverImageUrl,
            item.AddedAt);
    }

    public static IEnumerable<LibraryGameDto> ToDto(this IEnumerable<LibraryItem> items)
    {
        return items.Select(ToDto);
    }
}