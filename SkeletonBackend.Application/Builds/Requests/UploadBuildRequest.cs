namespace SkeletonBackend.Application.Builds.Requests;

public record UploadBuildRequest(
    Guid GameId,
    string Version,
    Stream ArchiveStream,
    string FileName,
    string ExecutablePath,
    string Changelog);