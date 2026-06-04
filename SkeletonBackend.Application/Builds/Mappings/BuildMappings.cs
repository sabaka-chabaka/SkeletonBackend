using SkeletonBackend.Application.Builds.DTOs;
using SkeletonBackend.Domain.Builds;

namespace SkeletonBackend.Application.Builds.Mappings;

public static class BuildMappings
{
    public static BuildDto ToDto(this Build build)
    {
        return new BuildDto(
            build.Id,
            build.GameId,
            build.Version,
            build.ArchivePath,
            build.Hash,
            build.SizeBytes,
            build.ExecutablePath,
            build.Changelog,
            build.IsLatest,
            build.UploadedAt);
    }
}