using SkeletonBackend.Domain.Identity;

namespace SkeletonBackend.Domain.Services;

public interface IJwtProvider
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
}
