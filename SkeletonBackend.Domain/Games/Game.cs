namespace SkeletonBackend.Domain.Games;

public class Game
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid DeveloperId { get; set; }

    public string? CoverImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }
}