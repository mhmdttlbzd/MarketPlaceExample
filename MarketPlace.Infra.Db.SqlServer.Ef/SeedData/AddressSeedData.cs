using MarketPlace.Domain.Core.Application.Entities._Admin;
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
                new City {Id = 5,Name = "رشت",ProvinceId = 3 },
                new City {Id = 6,Name = "ماسوله",ProvinceId = 3 },
                new City {Id = 7,Name = "کرمان",ProvinceId = 4 },
                new City {Id = 8,Name = "بردسیر",ProvinceId = 4 },
                new City {Id = 9,Name = "تبریز",ProvinceId = 5 },
                new City {Id = 10,Name = "مراغه",ProvinceId = 5 }
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
    public class MainAddressSeedData : IEntityTypeConfiguration<MainAddress>
    {
        public void Configure(EntityTypeBuilder<MainAddress> builder)
        {
            builder.HasData(
                new MainAddress { Id = 1,CityId=1, PostalCode= 1626627277,CreatedAt = DateTime.Now,Address = "خیابان رحمت جنب کوچه 2"},
                new MainAddress { Id = 2,CityId=1, PostalCode= 1234567890,CreatedAt = DateTime.Now,Address = "خیابان ملاصدرا جنب کوچه 2"},
                new MainAddress { Id = 3,CityId=1, PostalCode= 1634567611,CreatedAt = DateTime.Now,Address = "خیابان شهناز جنب کوچه 2"},
                new MainAddress { Id = 4,CityId=1, PostalCode= 1213435657,CreatedAt = DateTime.Now,Address = "خیابان داریوش جنب کوچه 2"}
                );
        }
    }
}
