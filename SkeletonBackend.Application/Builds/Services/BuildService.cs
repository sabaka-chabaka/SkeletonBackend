using SkeletonBackend.Application.Builds.DTOs;
using SkeletonBackend.Application.Builds.Mappings;
using SkeletonBackend.Application.Builds.Requests;
using SkeletonBackend.Domain.Builds;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Domain.Services;

namespace SkeletonBackend.Application.Builds.Services;

public class BuildService(
    IBuildRepository buildRepository,
    IGameRepository gameRepository,
    IFileStorage fileStorage) : IBuildService
{
    public async Task<BuildDto> UploadAsync(UploadBuildRequest request, CancellationToken cancellationToken = default)
    {
        var game = await gameRepository.GetByIdAsync(request.GameId, cancellationToken);
        if (game == null)
        {
            throw new Exception("Game not found.");
        }

        var filePath = await fileStorage.SaveAsync(request.ArchiveStream, request.FileName, cancellationToken);

        // В реальном приложении здесь должен быть расчет хэша и размера.
        // Для MVP используем заглушки, если IFileStorage не возвращает эти данные.
        
        var build = new Build
        {
            Id = Guid.NewGuid(),
            GameId = request.GameId,
            Version = request.Version,
            ArchivePath = filePath,
            Hash = "placeholder_hash", 
            SizeBytes = request.ArchiveStream.Length,
            ExecutablePath = request.ExecutablePath,
            Changelog = request.Changelog,
            IsLatest = true,
            UploadedAt = DateTime.UtcNow
        };

        // Снимаем флаг IsLatest с предыдущего билда
        var latestBuild = await buildRepository.GetLatestByGameIdAsync(request.GameId, cancellationToken);
        if (latestBuild != null)
        {
            latestBuild.IsLatest = false;
            buildRepository.Update(latestBuild);
        }

        await buildRepository.AddAsync(build, cancellationToken);
        await buildRepository.SaveChangesAsync(cancellationToken);

        return build.ToDto();
    }

    public async Task<BuildDto?> GetLatestAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        var build = await buildRepository.GetLatestByGameIdAsync(gameId, cancellationToken);
        return build?.ToDto();
    }
}