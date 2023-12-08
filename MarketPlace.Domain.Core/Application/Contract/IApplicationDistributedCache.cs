

namespace MarketPlace.Domain.Core.Application.Contract
{
    public interface IApplicationDistributedCache
    {
        Task SetAsync<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration);
        void Set<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration);
        Task SetAsync<T>(string key, List<T> value, int expiratonDay);
        void Set<T>(string key, List<T> value, int expiratonDay);
        Task SetAsync<T>(string key, List<T> value, TimeSpan slidingExpiration);
        void Set<T>(string key, List<T> value, TimeSpan slidingExpiration);
        Task<List<T>?> GetAsync<T>(string key);
        List<T>? Get<T>(string key);
    }
}
    