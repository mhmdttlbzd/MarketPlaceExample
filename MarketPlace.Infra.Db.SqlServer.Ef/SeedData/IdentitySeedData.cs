﻿using MarketPlace.Domain.Core.Application.Entities._Admin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Domain.Core.Identity.Entities;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Saler;

namespace MarketPlace.Infra.Db.SqlServer.Ef.SeedData
{
    public class AdminSeedData : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(new Admin
            {
                Id = 1,
                PersonalCode = "2682"
            });
        }
    }
    public class CustomerSeedData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer{Id = 2,AddressId = 1},
                new Customer{Id = 3,AddressId = 2 }
            );
        }
    }
    public class SalerSeedData : IEntityTypeConfiguration<Saler>
    {
        public void Configure(EntityTypeBuilder<Saler> builder)
        {
            builder.HasData(
                new Saler{Id = 4,SalerTypeId = 1},
                new Saler{Id = 5,SalerTypeId = 1 }
            );
        }
    }

    public class SalerTypeSeedData : IEntityTypeConfiguration<SalerType>
    {
        public void Configure(EntityTypeBuilder<SalerType> builder)
        {
            builder.HasData(
                new SalerType { Id = 1,Title = "normal",WagePercent = 5 },
                new SalerType { Id = 2,Title = "golden",WagePercent = 3 }
            );
        }
    }




    //Identity
    public class RoleSeedData : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                new ApplicationRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN".ToUpper() },
                new ApplicationRole { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER".ToUpper() },
                new ApplicationRole { Id = 3, Name = "Saler", NormalizedName = "SALER".ToUpper() }
                );

        }
    }
    public class UserSeedData : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            var hasher = new PasswordHasher<ApplicationUser>();

            var user1 = new ApplicationUser
            {
                Id = 1,
                UserName = "mhmdttlbzd@gmail.com",
                NormalizedUserName = "MHMDTTLBZD@GMAIL.COM".ToUpper(),
                Email = "mhmdttlbzd@gmail.com",
                NormalizedEmail = "MHMDTTLBZD@GMAIL.COM".ToUpper(),
                Name = "محمد",
                Family = "طالب زاده",
                SecurityStamp = Guid.NewGuid().ToString("D")
            }; var user2 = new ApplicationUser
            {
                Id = 2,
                UserName = "example@gmail.com",
                NormalizedUserName = "EXAMPLE@GMAIL.COM".ToUpper(),
                Email = "example@gmail.com",
                Name = "محمد",
                Family = "علی زاده",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var user3 = new ApplicationUser
            {
                Id = 3,
                UserName = "ali@gmail.com",
                NormalizedUserName = "ALI@GMAIL.COM".ToUpper(),
                Email = "ali@gmail.com",
                NormalizedEmail = "ALI@GMAIL.COM".ToUpper(),
                Name = "علی",
                Family = "سعیدی",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var user4 = new ApplicationUser
            {
                Id = 4,
                UserName = "reza@gmail.com",
                NormalizedUserName = "REZA@GMAIL.COM".ToUpper(),
                Email = "reza@gmail.com",
                NormalizedEmail = "REZA@GMAIL.COM".ToUpper(),
                Name = "رضا",
                Family = "شریفی",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var user5 = new ApplicationUser
            {
                Id = 5,
                UserName = "saeed@gmail.com",
                NormalizedUserName = "SAEED@GMAIL.COM".ToUpper(),
                Email = "saeed@gmail.com",
                NormalizedEmail = "SAEED@GMAIL.COM".ToUpper(),
                Name = "سعید",
                Family = "افشار",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user1.PasswordHash = hasher.HashPassword(user1, "2682");
            user2.PasswordHash = hasher.HashPassword(user2, "2682");
            user3.PasswordHash = hasher.HashPassword(user3, "2682");
            user4.PasswordHash = hasher.HashPassword(user4, "2682");
            user5.PasswordHash = hasher.HashPassword(user5, "2682");
            builder.HasData(user1,user2,user3,user4,user5);
        }
    }
    public class UserRoleSeedData : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(
                new IdentityUserRole<int>{RoleId = 1,UserId = 1},
                new IdentityUserRole<int>{RoleId = 2,UserId = 2},
                new IdentityUserRole<int>{RoleId = 2,UserId = 3},
                new IdentityUserRole<int>{RoleId = 3,UserId = 4},
                new IdentityUserRole<int>{RoleId = 3,UserId = 5}
                );
        }
    }
}
