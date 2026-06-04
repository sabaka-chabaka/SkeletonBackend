using SkeletonBackend.Application.Builds.DTOs;
using SkeletonBackend.Application.Builds.Requests;

namespace SkeletonBackend.Application.Builds.Services;

public interface IBuildService
{
    Task<BuildDto> UploadAsync(UploadBuildRequest request, CancellationToken cancellationToken = default);
    Task<BuildDto?> GetLatestAsync(Guid gameId, CancellationToken cancellationToken = default);
}