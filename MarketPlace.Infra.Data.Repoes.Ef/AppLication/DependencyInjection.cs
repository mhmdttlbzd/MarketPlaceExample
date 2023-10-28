using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auction;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Address;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Auction;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._CustomAttribute;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Customer;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Order;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Picture;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Product;
using MarketPlace.Infra.Data.Repoes.Ef.AppLication._Saler;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<MarketPlaceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(MarketPlaceDbContext).Assembly.FullName)));
            #endregion

            #region Address
            services.AddScoped<ICityRepo,CityRepo>();
            services.AddScoped<IMainAddressRepo, MainAddressRepo>();
            services.AddScoped<IProvinceRepo, ProvinceRepo>();
            #endregion

            #region Auction
            services.AddScoped<IAuctionRepo, AuctionRepo>();
            services.AddScoped<IAuctionProposalRepo, AuctionProposalRepo>();
            #endregion

            #region Booth
            services.AddScoped<IBoothRepo, BoothRepo>();
            services.AddScoped<IBoothProductRepo, BoothProductRepo>();
            services.AddScoped<IBoothProductsPriceRepo, BoothProductsPriceRepo>();
            services.AddScoped<ICommentRepo, CommentRepo>();
            #endregion

            #region CustomAttribute
            services.AddScoped<IAttributeTemplateRepo, AttributeTemplateRepo>();
            services.AddScoped<IProductAttributeRepo, ProductAttributeRepo>();
            #endregion

            #region Customer
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            #endregion

            #region Order
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderLineRepo, OrderLineRepo>();
            #endregion

            #region Picture
            services.AddScoped<IAuctionPictureRepo, AuctionPictureRepo>();
            services.AddScoped<IPictureRepo, PictureRepo>();
            services.AddScoped<IProductCustomerPicRepo, ProductCustomerPicRepo>();
            services.AddScoped<IProductSalerPicRepo, ProductSalerPicRepo>();
            #endregion

            #region Product
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            #endregion

            #region Saler
            services.AddScoped<ISalerRepo, SalerRepo>();
            #endregion
        }
    }
}
