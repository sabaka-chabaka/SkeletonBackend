using SkeletonBackend.Application.Identity.DTOs;
using SkeletonBackend.Application.Identity.Requests;
using SkeletonBackend.Application.Identity.Responses;

namespace SkeletonBackend.Application.Identity.Services;

public interface IIdentityService
{
    Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}