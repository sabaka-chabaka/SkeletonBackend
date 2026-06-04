namespace SkeletonBackend.Domain.Services;

public interface IFileStorage
{
    Task<string> SaveAsync(Stream stream, string fileName, CancellationToken cancellationToken = default);
    Task DeleteAsync(string path, CancellationToken cancellationToken = default);
    Stream GetStream(string path);
}
