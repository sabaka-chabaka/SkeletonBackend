using SkeletonBackend.Domain.Games;
using SkeletonBackend.Domain.Library;

namespace SkeletonBackend.Domain.Identity;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
    public ICollection<Game> DevelopedGames { get; set; } = [];
    public ICollection<LibraryItem> LibraryItems { get; set; } = [];
}