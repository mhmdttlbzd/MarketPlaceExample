using MarketPlace.Domain.Core;
using MarketPlace.Domain.Core.Application.Entities._Admin;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Identity.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MarketPlace.Infra.Db.SqlServer.Ef;

public class MarketPlaceDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);


        builder.Entity<ApplicationUser>(entity => { entity.ToTable("Accounts"); });
        builder.Entity<Customer>(entity => { entity.ToTable("Customers"); });
        builder.Entity<Seller>(entity => { entity.ToTable("Salers"); });
        builder.Entity<Admin>(entity => { entity.ToTable("Admins"); });
        builder.Entity<IdentityRole<int>>(entity => { entity.ToTable("Roles"); });
        builder.Entity<IdentityUserRole<int>>(entity => { entity.ToTable("AccountRoles"); });
        builder.Entity<IdentityUserClaim<int>>(entity => { entity.ToTable("AccountClaims"); });
        builder.Entity<IdentityUserLogin<int>>(entity => { entity.ToTable("AccountLogins"); });
        builder.Entity<IdentityUserToken<int>>(entity => { entity.ToTable("AccountTokens"); });
        builder.Entity<IdentityRoleClaim<int>>(entity => { entity.ToTable("RoleClaims"); });


        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
