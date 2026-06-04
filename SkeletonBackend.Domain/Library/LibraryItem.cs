namespace SkeletonBackend.Domain.Library;

public class LibraryItem
{
    public Guid UserId { get; set; }

    public Guid GameId { get; set; }

    public DateTime AddedAt { get; set; }
}