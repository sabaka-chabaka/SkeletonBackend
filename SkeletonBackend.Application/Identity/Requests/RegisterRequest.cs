namespace SkeletonBackend.Application.Identity.Requests;

public record RegisterRequest(string Username, string Email, string Password);