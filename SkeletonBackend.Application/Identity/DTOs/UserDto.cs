namespace SkeletonBackend.Application.Identity.DTOs;

public record UserDto(
    Guid Id,
    string Username,
    string Email,
    DateTime CreatedAt,
    DateTime? LastLoginAt);
