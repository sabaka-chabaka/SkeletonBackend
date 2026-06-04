using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Domain.Services;
using SkeletonBackend.Infrastructure.Authentication;
using SkeletonBackend.Infrastructure.Data;
using SkeletonBackend.Infrastructure.Repositories;
using SkeletonBackend.Infrastructure.Storage;

namespace SkeletonBackend.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IBuildRepository, BuildRepository>();
        services.AddScoped<ILibraryRepository, LibraryRepository>();

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IFileStorage, LocalFileStorage>();

        return services;
    }
}
