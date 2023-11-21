using Hangfire;
using Hangfire.SqlServer;
using MarketPlace.Domain.AppServices.Acount;
using MarketPlace.Domain.AppServices.AppLication._Address;
using MarketPlace.Domain.AppServices.AppLication._Admin;
using MarketPlace.Domain.AppServices.AppLication._Product;
using MarketPlace.Domain.AppServices.AppLication._Seller;
using MarketPlace.Domain.AppServices.Identity;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Address;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Seller;
using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Domain.AppServices
{
    public static class DependencyInjection
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IAdminPanelAppService, AdminPanelAppService>();
            services.AddScoped<IRequestsAppService, RequestsAppService>();
            services.AddScoped<ICommentAppService,CommentAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ISellerAppService, SellerAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IBoothAppService, BoothAppService>();
            services.AddScoped<IBoothProductAppService, BoothProductAppService>();
            services.AddScoped<IAuctionAppService, AuctionAppService>();


            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

        }
    }
}
