using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Caching.Distributed;

namespace EshopWebService.Intrastructure.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task<T> GetAsync<T>(this IDistributedCache distributedCache, string cachedKey, CancellationToken token = default)
        {
            Guard.Against.Null(distributedCache, nameof(distributedCache));
            Guard.Against.NullOrWhiteSpace(cachedKey, nameof(cachedKey));

            var utf8Bytes = await distributedCache.GetAsync(cachedKey, token);
            return utf8Bytes != null ? JsonSerializer.Deserialize<T>(utf8Bytes) : default;
        }

        public static Task RemoveAsync(this IDistributedCache distributedCache, string cachedKey, CancellationToken token = default)
        {
            Guard.Against.Null(distributedCache, nameof(distributedCache));
            Guard.Against.NullOrWhiteSpace(cachedKey, nameof(cachedKey));

            return distributedCache.RemoveAsync(cachedKey, token);
        }

        public static Task SetAsync<T>(this IDistributedCache distributedCache, string cachedKey, T data, int cacheExpirationInMinutes = 10, CancellationToken token = default)
        {
            Guard.Against.Null(distributedCache, nameof(distributedCache));
            Guard.Against.NullOrWhiteSpace(cachedKey, nameof(cachedKey));
            Guard.Against.Null(data, nameof(data));

            var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(cacheExpirationInMinutes));
            var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(data);
            return distributedCache.SetAsync(cachedKey, utf8Bytes, options, token);
        }
    }
}