using System;
using System.Collections.Generic;
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

    public virtual DbSet<ActionProposal> ActionProposals { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<BoothProductsAction> BoothProductsActions { get; set; }

    public virtual DbSet<BoothProductsPrice> BoothProductsPrices { get; set; }

    public virtual DbSet<BoothsProduct> BoothsProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CustomAttributeTemlate> CustomAttributeTemlates { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomersProductPice> CustomersProductPices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderStetuse> OrderStetuses { get; set; }

    public virtual DbSet<Peoduct> Peoducts { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<PicturesAction> PicturesActions { get; set; }

    public virtual DbSet<ProductsCustomAttribute> ProductsCustomAttributes { get; set; }

    public virtual DbSet<Provience> Proviences { get; set; }

    public virtual DbSet<Saler> Salers { get; set; }

    public virtual DbSet<SalerType> SalerTypes { get; set; }

    public virtual DbSet<SalersProductPic> SalersProductPics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MarketPlaceDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionProposal>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Action).WithMany(p => p.ActionProposals)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionProposals_BoothProductsAction");

            entity.HasOne(d => d.Customer).WithMany(p => p.ActionProposals)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionProposals_Customers");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Address");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address1)
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

            entity.HasOne(d => d.Address).WithMany(p => p.Booths)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Booth_Address");

            entity.HasOne(d => d.Saler).WithOne(p => p.Booth)
                .HasForeignKey<Booth>(d => d.SalerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Saler");
        });

        modelBuilder.Entity<BoothProductsAction>(entity =>
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

        modelBuilder.Entity<BoothsProduct>(entity =>
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

            entity.HasOne(d => d.Provience).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvienceId)
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
        });

        modelBuilder.Entity<CustomAttributeTemlate>(entity =>
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

        modelBuilder.Entity<CustomersProductPice>(entity =>
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

            entity.HasOne(d => d.Statuse).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatuseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_OrderStetuses");
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

        modelBuilder.Entity<OrderStetuse>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(10);
        });

        modelBuilder.Entity<Peoduct>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Peoducts)
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

        modelBuilder.Entity<PicturesAction>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Action).WithMany(p => p.PicturesActions)
                .HasForeignKey(d => d.ActionId)
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

        modelBuilder.Entity<Provience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Provience");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<Saler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Saler");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.SalerTipe).WithMany(p => p.Salers)
                .HasForeignKey(d => d.SalerTipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saler_SalerTypes");
        });

        modelBuilder.Entity<SalerType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<SalersProductPic>(entity =>
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
