namespace SkeletonBackend.Application.Builds.DTOs;

public record BuildDto(
    Guid Id,
    Guid GameId,
    string Version,
    string ArchivePath,
    string Hash,
    long SizeBytes,
    string ExecutablePath,
    string Changelog,
    bool IsLatest,
    DateTime UploadedAt);