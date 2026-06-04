namespace SkeletonBackend.Domain.Builds;

public class Build
{
    public Guid Id { get; set; }

    public Guid GameId { get; set; }

    public string Version { get; set; } = null!;

    public string ArchivePath { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public long SizeBytes { get; set; }

    public string ExecutablePath { get; set; } = null!;
    
    public string Changelog { get; set; } = null!;

    public bool IsLatest { get; set; }

    public DateTime UploadedAt { get; set; }
}