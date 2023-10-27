using MarketPlace.Domain.Core.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class MarketPlaceDbContext : DbContext
{
    public MarketPlaceDbContext()
    {
    }

    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
        : base(options)
    {
    }

    public DbSet<AuctionProposal> AuctionProposals { get; set; }

    public DbSet<MainAddress> MainAddresses { get; set; }

    public DbSet<Booth> Booths { get; set; }

    public DbSet<Auction> BoothProductsAuctions { get; set; }

    public DbSet<BoothProductsPrice> BoothProductsPrices { get; set; }

    public DbSet<BoothProduct> BoothsProducts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<CustomAttributeTemplate> CustomAttributeTemplates { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<ProductCustomerPic> ProductsCustomersPices { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderLine> OrderLines { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Picture> Pictures { get; set; }

    public DbSet<AuctionPicture> AuctionPictures { get; set; }

    public DbSet<ProductsCustomAttribute> ProductsCustomAttributes { get; set; }

    public DbSet<Province> Provinces { get; set; }

    public DbSet<Saler> Salers { get; set; }

    public DbSet<SalerType> SalerTypes { get; set; }

    public DbSet<ProductSalerPic> ProductsSalerPics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MarketPlaceDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuctionProposal>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Auction).WithMany(p => p.AuctionProposals)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionProposals_BoothProductsAction");

            entity.HasOne(d => d.Customer).WithMany(p => p.ActionProposals)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionProposals_Customers");
        });

        modelBuilder.Entity<MainAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Address");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("Address");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_City");
        });

        modelBuilder.Entity<Booth>(entity =>
        {
            entity.HasKey(e => e.SalerId).HasName("PK_Booth");

            entity.Property(e => e.SalerId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.ShopAddress).WithMany(p => p.Booths)
                .HasForeignKey(d => d.ShopAddressId)
                .HasConstraintName("FK_Booth_Address");

            entity.HasOne(d => d.Saler).WithOne(p => p.Booth)
                .HasForeignKey<Booth>(d => d.SalerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Saler");
        });

        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BoothProductsAction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExpiredTime).HasColumnType("date");

            entity.HasOne(d => d.Product).WithMany(p => p.BoothProductsActions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProductsAction_Peoducts");
        });

        modelBuilder.Entity<BoothProductsPrice>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.BoothProduct).WithMany(p => p.BoothProductsPrices)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProductsPrices_BoothProducts");
        });

        modelBuilder.Entity<BoothProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BoothProducts");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Booth).WithMany(p => p.BoothsProducts)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProducts_Booth");

            entity.HasOne(d => d.Product).WithMany(p => p.BoothsProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProducts_Peoducts");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(25);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_City");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Provience");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Comment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.BoothProduct).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_BoothProducts");

            entity.HasOne(d => d.Customer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Comment_Customers");
            entity.HasCheckConstraint("0 to 5", "([Satisfaction]<=(5) AND [Satisfaction]>=(0))");
        });

        modelBuilder.Entity<CustomAttributeTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomAttributeTemlate");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.CustomAttributeTemlates)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomAttributeTemlate_Categories");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_Address");
        });

        modelBuilder.Entity<ProductCustomerPic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerProductPices");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.BoothProduct).WithMany(p => p.CustomersProductPices)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerProductPices_BoothProducts");

            entity.HasOne(d => d.Picture).WithMany(p => p.CustomersProductPices)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerProductPices_Pictures");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Order");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customers");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrderLine");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.BoothProduct).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLine_BoothProducts");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLine_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Peoducts_Categories");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Alt).HasMaxLength(50);
            entity.Property(e => e.Path)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuctionPicture>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Auction).WithMany(p => p.PicturesActions)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PicturesActions_BoothProductsAction");

            entity.HasOne(d => d.Picture).WithMany(p => p.PicturesActions)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PicturesActions_Pictures");
        });

        modelBuilder.Entity<ProductsCustomAttribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductCustomAttribute");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AttributeValue).HasMaxLength(100);

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductsCustomAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCustomAttribute_CustomAttributeTemlate");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsCustomAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCustomAttribute_Peoducts");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Provience");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<Saler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Saler");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.SalerType).WithMany(p => p.Salers)
                .HasForeignKey(d => d.SalerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saler_SalerTypes");
        });

        modelBuilder.Entity<SalerType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.HasCheckConstraint("0 to 100", "([TaskPercent]<=(100) AND [TaskPercent]>=(0))");
        });

        modelBuilder.Entity<ProductSalerPic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalerProductPic");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.BoothProduct).WithMany(p => p.SalersProductPics)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalerProductPic_BoothProducts");

            entity.HasOne(d => d.Picture).WithMany(p => p.SalersProductPics)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalerProductPic_Pictures");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
