using MarketPlace.Domain.AppServices.Acount;
using MarketPlace.Domain.AppServices.AppLication._Address;
using MarketPlace.Domain.AppServices.AppLication._Admin;
using MarketPlace.Domain.AppServices.AppLication._Product;
using MarketPlace.Domain.AppServices.Identity;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Address;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Domain.AppServices
{
    public static class DependencyInjection
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IAdminPanelAppService, AdminPanelAppService>();
            services.AddScoped<IRequestsAppService, RequestsAppService>();
            services.AddScoped<ICommentAppService,CommentAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ISalerAppService, SalerAppService>();
        }
    }
}
