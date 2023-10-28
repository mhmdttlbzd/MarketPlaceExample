using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MarketPlace.Infra.Db.SqlServer.Ef;

public class MarketPlaceDbContext : DbContext
{
    //private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    //public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
    //    : base(options)
    //{
    //    _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    //}

    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options) : base(options)
    {
        
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MarketPlace1;Trusted_Connection=True;TrustServerCertificate=True");

    //    //optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
