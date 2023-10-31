using MarketPlace.Domain.Core.Application.Entities._Admin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            },new Admin
            {
                Id = 2,
                PersonalCode = "4343"
            });
        }
    }
}
