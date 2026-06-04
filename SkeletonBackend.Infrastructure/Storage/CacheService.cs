using Microsoft.Extensions.Caching.Distributed;
using SkeletonBackend.Domain.Services;
using System.Text.Json;

namespace SkeletonBackend.Infrastructure.Storage;

public class CacheService(IDistributedCache cache) : ICacheService
{
    private readonly DistributedCacheEntryOptions _defaultOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
    };

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var cachedValue = await cache.GetStringAsync(key, cancellationToken);
        if (cachedValue is null)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(cachedValue);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        var options = expiration.HasValue 
            ? new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration } 
            : _defaultOptions;

        var serializedValue = JsonSerializer.Serialize(value);
        await cache.SetStringAsync(key, serializedValue, options, cancellationToken);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(key, cancellationToken);
    }
}
