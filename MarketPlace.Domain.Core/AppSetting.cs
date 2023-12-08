using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core
{
    public class AppSetting
    {
       
        public AppSetting(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            CategoriesCacheKey = configuration["CacheKeys:Categories"].ToString();
            CategoriesCacheKey = configuration["CacheKeys:Cities"].ToString();
        }
        public string ConnectionString { get; private set; }
        public string CategoriesCacheKey { get; private set; }
        public string CitiesCacheKey { get; private set; }
    }
}
