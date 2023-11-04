using MarketPlace.Domain.AppServices.AppLication._Admin;
using MarketPlace.Domain.AppServices.Identity;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices
{
    public static class DependencyInjection
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IAdminPanelAppService, AdminPanelAppService>();
        }
    }
}
