
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;



namespace MarketPlace.Infra.Cache.Redis
{
    public static class DependencyInjection
    {
        public static void AddCachingRedis(this IServiceCollection services)
        {
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.ConfigurationOptions = new ConfigurationOptions
                {
                    Password = string.Empty,
                    DefaultDatabase = 0,
                    ConnectTimeout = 30000
                };
                options.ConfigurationOptions.EndPoints.Add("localhost:6379");
            });

            
        }
    }
}