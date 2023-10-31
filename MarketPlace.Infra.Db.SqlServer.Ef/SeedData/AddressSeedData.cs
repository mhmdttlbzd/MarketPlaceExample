﻿using MarketPlace.Domain.Core.Application.Entities._Admin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Domain.Core.Application.Entities._Address;

namespace MarketPlace.Infra.Db.SqlServer.Ef.SeedData
{
    public class CitySeedData : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City {Id = 1,Name = "شیراز",ProvinceId = 1 },
                new City {Id = 2,Name = "سروستان",ProvinceId = 1 },
                new City {Id = 3,Name = "تهران",ProvinceId = 2 },
                new City {Id = 4,Name = "کرج",ProvinceId = 2 },
                new City {Id = 4,Name = "رشت",ProvinceId = 3 },
                new City {Id = 4,Name = "ماسوله",ProvinceId = 3 },
                new City {Id = 4,Name = "کرمان",ProvinceId = 4 },
                new City {Id = 4,Name = "بردسیر",ProvinceId = 4 },
                new City {Id = 4,Name = "تبریز",ProvinceId = 5 },
                new City {Id = 4,Name = "مراغه",ProvinceId = 5 }
                );
        }
    }
    public class ProvinceSeedData : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasData(
                new Province { Id = 1,Name = "فارس"},
                new Province { Id = 2,Name = "تهران"},
                new Province { Id = 3,Name = "گیلان"},
                new Province { Id = 4,Name = "کرمان"},
                new Province { Id = 5,Name = "آذربایجان شرقی"}
                );
        }
    }
}