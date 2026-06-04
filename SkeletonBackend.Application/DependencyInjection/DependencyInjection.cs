using Microsoft.Extensions.DependencyInjection;
using SkeletonBackend.Application.Builds.Services;
using SkeletonBackend.Application.Games.Services;
using SkeletonBackend.Application.Identity.Services;
using SkeletonBackend.Application.Library.Services;

namespace SkeletonBackend.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IBuildService, BuildService>();
        services.AddScoped<ILibraryService, LibraryService>();

        return services;
    }
}