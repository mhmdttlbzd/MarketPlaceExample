using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Address;
using MarketPlace.Domain.Core.Application.Entities._Admin;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Infra.Db.SqlServer.Ef.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MarketPlace.Infra.Db.SqlServer.Ef;

public class MarketPlaceDbContext : DbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    //public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options) : base(options)
    //{

    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }


 



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }



    #region DbSets

    //public DbSet<City> Cities { get; set; }
    //public DbSet<MainAddress> MainAddresses { get; set; }
    //public DbSet<Province> Provinces { get; set; }


    //public DbSet<Admin> Admins { get; set; }


    //public DbSet<AuctionProposal> AuctionProposals { get; set; }
    //public DbSet<Auction> Auctions { get; set; }


    //public DbSet<Booth> Booths { get; set; }
    //public DbSet<BoothProduct> BoothProducts { get; set; }
    //public DbSet<BoothProductsPrice> BoothProductsPrices { get; set; }
    //public DbSet<Comment> Comments { get; set; }


    //public DbSet<CustomAttributeTemplate> CustomAttributeTemplates { get; set; }
    //public DbSet<ProductsCustomAttribute> ProductsCustomAttributes { get; set; }


    //public DbSet<Customer> Customers { get; set; }


    //public DbSet<Order> Orders { get; set; }
    //public DbSet<OrderLine> OrdersLines { get; set; }


    //public DbSet<AuctionPicture> AuctionPictures { get; set; }
    //public DbSet<Picture> Pictures { get; set; }
    //public DbSet<ProductCustomerPic> ProductCustomerPics { get; set; }
    //public DbSet<ProductSalerPic> ProductSalerPics { get; set; }


    //public DbSet<Category> Categories { get; set; }
    //public DbSet<Product> Products { get; set; }


    //public DbSet<Saler> Salers { get; set; }
    #endregion
}
