
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Cache.Redis
{
    public class RedisDistributedCache
    {
        private readonly IDistributedCache _distributedCache;
        public RedisDistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public void Set<T>(T value,int expiratonDay,TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay),
                SlidingExpiration = slidingExpiration
            };
            _distributedCache.SetStringAsync(nameof(T),JsonSerializer.Serialize(value),cacheOption);
        }

        public void Set<T>(T value,int expiratonDay)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay)
            };
            _distributedCache.SetStringAsync(nameof(T),JsonSerializer.Serialize(value),cacheOption);
        }
        
        public void Set<T>(T value,TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            };
            _distributedCache.SetStringAsync(nameof(T),JsonSerializer.Serialize(value),cacheOption);
        }

        public async Task<T?> Get<T>()
        {
            var value = await _distributedCache.GetStringAsync(nameof(T));
            if (value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

    }
}