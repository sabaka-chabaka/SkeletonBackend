using SkeletonBackend.Application.Identity.DTOs;
using SkeletonBackend.Application.Identity.Requests;
using SkeletonBackend.Application.Identity.Responses;
using SkeletonBackend.Application.Identity.Services;
using SkeletonBackend.Domain.Identity;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Domain.Services;

namespace SkeletonBackend.Application.Identity.Services;

public class IdentityService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider,
    ICacheService cacheService) : IIdentityService
{
    private static string GetUserCacheKey(Guid id) => $"user_{id}";

    public async Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var existingUser = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHasher.Hash(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        await userRepository.AddAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null || !passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            throw new Exception("Invalid email or password.");
        }

        var token = jwtProvider.GenerateToken(user);
        
        user.LastLoginAt = DateTime.UtcNow;
        userRepository.Update(user);
        await userRepository.SaveChangesAsync(cancellationToken);

        await cacheService.RemoveAsync(GetUserCacheKey(user.Id), cancellationToken);

        return new LoginResponse(token);
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cacheKey = GetUserCacheKey(id);
        var cachedUser = await cacheService.GetAsync<UserDto>(cacheKey, cancellationToken);
        if (cachedUser is not null)
        {
            return cachedUser;
        }

        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        if (user is null)
        {
            return null;
        }

        var dto = new UserDto(user.Id, user.Username, user.Email, user.CreatedAt, user.LastLoginAt);
        await cacheService.SetAsync(cacheKey, dto, TimeSpan.FromMinutes(30), cancellationToken);

        return dto;
    }
}