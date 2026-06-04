using SkeletonBackend.Domain.Services;

namespace SkeletonBackend.Infrastructure.Storage;

public class LocalFileStorage : IFileStorage
{
    private readonly string _storagePath;

    public LocalFileStorage()
    {
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "storage", "builds");
        
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<string> SaveAsync(Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        var filePath = Path.Combine(_storagePath, fileName);
        
        using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
        await stream.CopyToAsync(fileStream, cancellationToken);
        
        return filePath;
    }

    public Task DeleteAsync(string path, CancellationToken cancellationToken = default)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        
        return Task.CompletedTask;
    }

    public Stream GetStream(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }
        
        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
    }
}
