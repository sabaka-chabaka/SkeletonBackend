using SkeletonBackend.Domain.Games;
using SkeletonBackend.Domain.Identity;

namespace SkeletonBackend.Domain.Library;

public class LibraryItem
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid GameId { get; set; }
    public Game Game { get; set; } = null!;

    public DateTime AddedAt { get; set; }
}