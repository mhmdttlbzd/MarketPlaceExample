
using MarketPlace.Domain.Core.Application.Contract;

using Microsoft.Extensions.DependencyInjection;




namespace MarketPlace.Infra.Cache.Redis
{
    public static class DependencyInjection
    {
        public static void AddCachingRedis(this IServiceCollection services)
        {
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                

                options.ConfigurationOptions = new ()
                {
                    Password = string.Empty,
                    DefaultDatabase = 0,
                    ConnectTimeout = 30000
                };
                options.ConfigurationOptions.EndPoints.Add("localhost:6379");
            });
            services.AddScoped<IApplicationDistributedCache, RedisDistributedCache>();
            
        }
    }
}