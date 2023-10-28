using MarketPlace.Domain.Core.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MarketPlace.Infra.Db.SqlServer.Ef;

public partial class MarketPlaceDbContext : DbContext
{
    public MarketPlaceDbContext()
    {
    }

    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
        : base(options)
    {
    }

    //public DbSet<AuctionProposal> AuctionProposals { get; set; }

    //public DbSet<MainAddress> MainAddresses { get; set; }

    //public DbSet<Booth> Booths { get; set; }

    //public DbSet<Auction> BoothProductsAuctions { get; set; }

    //public DbSet<BoothProductsPrice> BoothProductsPrices { get; set; }

    //public DbSet<BoothProduct> BoothsProducts { get; set; }

    //public DbSet<Category> Categories { get; set; }

    //public DbSet<City> Cities { get; set; }

    //public DbSet<Comment> Comments { get; set; }

    //public DbSet<CustomAttributeTemplate> CustomAttributeTemplates { get; set; }

    //public DbSet<Customer> Customers { get; set; }

    //public DbSet<ProductCustomerPic> ProductsCustomersPices { get; set; }

    //public DbSet<Order> Orders { get; set; }

    //public DbSet<OrderLine> OrderLines { get; set; }

    //public DbSet<Product> Products { get; set; }

    //public DbSet<Picture> Pictures { get; set; }

    //public DbSet<AuctionPicture> AuctionPictures { get; set; }

    //public DbSet<ProductsCustomAttribute> ProductsCustomAttributes { get; set; }

    //public DbSet<Province> Provinces { get; set; }

    //public DbSet<Saler> Salers { get; set; }

    //public DbSet<SalerType> SalerTypes { get; set; }

    //public DbSet<ProductSalerPic> ProductsSalerPics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
