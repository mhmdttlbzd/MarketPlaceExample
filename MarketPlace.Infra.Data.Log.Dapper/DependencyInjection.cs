using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Log.Dapper
{
    public static class DependencyInjection
    {
        public static void AddApplicationLogging(this IServiceCollection services)
        {
            services.AddSingleton<IViewLogRepository,ViewLogRepository>();
        }
    }
}
