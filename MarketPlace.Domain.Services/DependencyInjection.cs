using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Admin;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Services.Acount;
using MarketPlace.Domain.Services.Application._Address;
using MarketPlace.Domain.Services.Application._Admin;
using MarketPlace.Domain.Services.Application._Auction;
using MarketPlace.Domain.Services.Application._Booth;
using MarketPlace.Domain.Services.Application._CustomAttribute;
using MarketPlace.Domain.Services.Application._Customer;
using MarketPlace.Domain.Services.Application._Order;
using MarketPlace.Domain.Services.Application._Picture;
using MarketPlace.Domain.Services.Application._Product;
using MarketPlace.Domain.Services.Application._Saler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace MarketPlace.Domain.Services
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUserService, UserService>();
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
            #region Address
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IMainAddressService, MainAddressService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            #endregion

            #region Admin
            services.AddScoped<IAdminService, AdminService>();
            #endregion

            #region Auction
            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<IAuctionProposalService, AuctionProposalService>();
            #endregion

            #region Booth
            services.AddScoped<IBoothService, BoothService>();
            services.AddScoped<IBoothProductService, BoothProductService>();
            services.AddScoped<IBoothProductsPriceService, BoothProductsPriceService>();
            services.AddScoped<ICommentService, CommentService>();
            #endregion

            #region CustomAttribute
            services.AddScoped<IAttributeTemplateService, AttributeTemplateService>();
            services.AddScoped<IProductAttributeService, ProductAttributeService>();
            #endregion

            #region Customer
            services.AddScoped<ICustomerService, CustomerService>();
            #endregion

            #region Order
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderLineService, OrderLineService>();
            #endregion

            #region Picture
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IAuctionPictureService, AuctionPictureService>();
            services.AddScoped<IProductSalerPicService, ProductSalerPicService>();
            services.AddScoped<IProductCustomerPicService, ProductCustomerPicService>();
            #endregion

            #region
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            #endregion

            #region
            services.AddScoped<ISalerService, SellerService>();
            services.AddScoped<ISalerTypeService, SellerTypeService>();
            #endregion

        }
    }
}
