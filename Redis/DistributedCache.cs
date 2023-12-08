
using MarketPlace.Domain.Core.Application.Contract;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Cache.Redis
{
    public class RedisDistributedCache : IApplicationDistributedCache
    {
        private readonly IDistributedCache _distributedCache;
        public RedisDistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        // General Set
        public async Task SetAsync<T>(string key, List<T> value,int expiratonDay,TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay),
                SlidingExpiration = slidingExpiration
            };
            await _distributedCache.SetStringAsync(key,JsonSerializer.Serialize(value),cacheOption);
        }

        public void Set<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay),
                SlidingExpiration = slidingExpiration
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOption);
        }


        // ExpireTime Set
        public async Task SetAsync<T>(string key, List<T> value,int expiratonDay)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay)
            };
            await _distributedCache.SetStringAsync(key,JsonSerializer.Serialize(value),cacheOption);
        }
        public  void Set<T>(string key, List<T> value,int expiratonDay)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay)
            };
            _distributedCache.SetString(key,JsonSerializer.Serialize(value),cacheOption);
        }
        



        // Sliding Set
        public async Task SetAsync<T>(string key, List<T> value,TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            };
            await _distributedCache.SetStringAsync(key,JsonSerializer.Serialize(value),cacheOption);
        }
        public void Set<T>(string key, List<T> value,TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOption);
        }


        // Get
        public async Task<List<T>?> GetAsync<T>(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);
            if (value != null)
            {
                return JsonSerializer.Deserialize<List<T>>(value);
            }
            return default;
        } 
        public List<T>? Get<T>(string key)
        {
            var value = _distributedCache.GetString(key);
            if (value != null)
            {
                return JsonSerializer.Deserialize<List<T>>(value);
            }
            return default;
        }

    }
}