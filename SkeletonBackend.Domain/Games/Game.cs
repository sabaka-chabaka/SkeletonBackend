using SkeletonBackend.Domain.Builds;
using SkeletonBackend.Domain.Identity;
using SkeletonBackend.Domain.Library;

namespace SkeletonBackend.Domain.Games;

public class Game
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid DeveloperId { get; set; }
    public User Developer { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Build> Builds { get; set; } = [];
    public ICollection<LibraryItem> LibraryItems { get; set; } = [];
}