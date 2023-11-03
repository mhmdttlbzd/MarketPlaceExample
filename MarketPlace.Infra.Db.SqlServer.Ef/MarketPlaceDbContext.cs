using MarketPlace.Domain.Core;
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

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seeding a  'Administrator' role to AspNetRoles table
        //modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN".ToUpper() });


        ////a hasher to hash the password before seeding the user to the db
        //var hasher = new PasswordHasher<ApplicationUser>();


        ////Seeding the User to AspNetUsers table
        //var user = new ApplicationUser
        //{
        //    Id = 1, // primary key
        //    UserName = "mhmdt",
        //    NormalizedUserName = "MHMDT",
        //    Email = "mhmdttlbzd@gmail.com",
        //    Name = "محمد",
        //    Family = "طالب زاده"

        //};
        //user.PasswordHash = hasher.HashPassword(user, "2682");
        //modelBuilder.Entity<ApplicationUser>().HasData(user);


        ////Seeding the relation between our user and role to AspNetUserRoles table
        //modelBuilder.Entity<IdentityUserRole<int>>().HasData(
        //    new IdentityUserRole<int>
        //    {
        //        RoleId = 1,
        //        UserId = 1
        //    });


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }



}
