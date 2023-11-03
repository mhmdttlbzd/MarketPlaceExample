using MarketPlace.Domain.Core.Application.Entities._Admin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using MarketPlace.Domain.Core.Application.Enums;

namespace MarketPlace.Infra.Db.SqlServer.Ef.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Title = "خانه و آشپز خانه" },
                new Category { Id = 2, Title = "مد و پوشاک" },
                new Category { Id = 3, Title = "مواد غذایی" },
                new Category { Id = 4, Title = "لوازم آشپزخانه", ParentId = 1 },
                new Category { Id = 5, Title = "لوازم برقی", ParentId = 1 },
                new Category { Id = 6, Title = "مبلمان، میز و صندلی", ParentId = 1 },
                new Category { Id = 7, Title = "زنانه", ParentId = 2 },
                new Category { Id = 8, Title = "مردانه", ParentId = 2 },
                new Category { Id = 9, Title = "خوار و بار", ParentId = 3 },
                new Category { Id = 10, Title = "نوشیدنی", ParentId = 3 },
                new Category { Id = 11, Title = "لبنیات", ParentId = 3 },
                new Category { Id = 12, Title = "ترشی و شور", ParentId = 3 },
                new Category { Id = 13, Title = "لوازم پخت و پز", ParentId = 4 },
                new Category { Id = 14, Title = "ظروف آشپزخانه", ParentId = 4 },
                new Category { Id = 15, Title = "فلاسک، کلمن و ماگ", ParentId = 4 },
                new Category { Id = 16, Title = "ظروف یکبار مصرف", ParentId = 4 },
                new Category { Id = 18, Title = "یخچال و فریزر", ParentId = 5 },
                new Category { Id = 19, Title = "چای ساز و قهوه ساز", ParentId = 5 },
                new Category { Id = 20, Title = "جارو برقی، جارو شارژی و بخار شوی", ParentId = 5 },
                new Category { Id = 21, Title = "مبل", ParentId = 6 },
                new Category { Id = 22, Title = "میز", ParentId = 6 },
                new Category { Id = 23, Title = "صندلی", ParentId = 6 },
                new Category { Id = 24, Title = "کمد، کتابخانه و بوفه", ParentId = 6 },
                new Category { Id = 25, Title = "بلوز، پیراهن و شومیز زنانه", ParentId = 7 },
                new Category { Id = 26, Title = "کیف زنانه", ParentId = 7 },
                new Category { Id = 27, Title = "ساعت زنانه", ParentId = 7 },
                new Category { Id = 28, Title = "اکسسوری زنانه", ParentId = 7 },
                new Category { Id = 29, Title = "بلوز و پیراهن مردانه", ParentId = 8 },
                new Category { Id = 30, Title = "لباس راحتی مردانه", ParentId = 8 },
                new Category { Id = 31, Title = "کت شلوار و جلیقه مردانه", ParentId = 8 },
                new Category { Id = 32, Title = "عینک مردانه", ParentId = 8 },
                new Category { Id = 33, Title = "ساعت مردانه", ParentId = 8 },
                new Category { Id = 34, Title = "برنج", ParentId = 9 },
                new Category { Id = 35, Title = "حبوبات و سویا", ParentId = 9 },
                new Category { Id = 36, Title = "غلات", ParentId = 9 },
                new Category { Id = 37, Title = "نان", ParentId = 9 },
                new Category { Id = 38, Title = "آرد", ParentId = 9 },
                new Category { Id = 39, Title = "چای", ParentId = 10 },
                new Category { Id = 40, Title = "دمنوش", ParentId = 10 },
                new Category { Id = 41, Title = "عرقیات", ParentId = 10 },
                new Category { Id = 42, Title = "قهوه", ParentId = 10 },
                new Category { Id = 43, Title = "آب معدنی", ParentId = 10 },
                new Category { Id = 44, Title = "پنیر", ParentId = 11 },
                new Category { Id = 45, Title = "کره", ParentId = 11 },
                new Category { Id = 46, Title = "شیر", ParentId = 11 },
                new Category { Id = 47, Title = "ماست", ParentId = 11 },
                new Category { Id = 48, Title = "دوغ", ParentId = 11 },
                new Category { Id = 49, Title = "ترشی", ParentId = 12 },
                new Category { Id = 50, Title = "زیتون", ParentId = 12 },
                new Category { Id = 51, Title = "خیار شور", ParentId = 12 }
                );
        }
    }
    public class CustomAttributeTemplateSeedData : IEntityTypeConfiguration<CustomAttributeTemplate>
    {
        public void Configure(EntityTypeBuilder<CustomAttributeTemplate> builder)
        {
            builder.HasData(
                new CustomAttributeTemplate { Id = 1, Title = "وزن" },
                new CustomAttributeTemplate { Id = 2, Title = "ابعاد" },
                new CustomAttributeTemplate { Id = 3, Title = "سایز" }
                );
        }
    }
    public class CategoryCustomAttributeSeedData : IEntityTypeConfiguration<CategoryCustomAttribute>
    {
        public void Configure(EntityTypeBuilder<CategoryCustomAttribute> builder)
        {
            builder.HasData(
                new CategoryCustomAttribute { Id = 1, CategoryId = 1, CustomAttributeTemplateId = 1 },
                new CategoryCustomAttribute { Id = 2, CategoryId = 2, CustomAttributeTemplateId = 1 },
                new CategoryCustomAttribute { Id = 3, CategoryId = 3, CustomAttributeTemplateId = 1 },
                new CategoryCustomAttribute { Id = 4, CategoryId = 1, CustomAttributeTemplateId = 2 },
                new CategoryCustomAttribute { Id = 5, CategoryId = 2, CustomAttributeTemplateId = 3 }
                );
        }
    }
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 13, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "سرویس قابلمه 8 پارچه گرانیت" },
                new Product { Id = 2, CategoryId = 13, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "کباب زن آرکا" },
                new Product { Id = 3, CategoryId = 13, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "کباب روگازی کیوبی" },
                new Product { Id = 4, CategoryId = 16, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "ظرف پلاستیکی یکبار مصرف" },
                new Product { Id = 5, CategoryId = 16, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, Name = "لیوان کاغذی 50 عددی cc220" },
                new Product { Id = 6, CategoryId = 18, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, Name = "دستگیره درب یخچال پارس" },
                new Product { Id = 7, CategoryId = 19, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, Name = "فانل گتر قهوه سایز 51 مگنتیفانل گتر قهوه سایز 51 مگنتی" },
                new Product { Id = 8, CategoryId = 19, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "قهوه جوش مسی دسته چوبی سیمین مس سایز یک" },
                new Product { Id = 9, CategoryId = 20, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, Name = "جاروبرقی سطلی بوش" },
                new Product { Id = 10, CategoryId = 20, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "جارو شارژی ماشین مدل HQ-01" },
                new Product { Id = 11, CategoryId = 21, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, Name = "کاور مبل هفت نفره ماشال" },
                new Product { Id = 12, CategoryId = 21, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "مبل راحتی اسکارلت 7 نفره پایه فلزی" },
                new Product { Id = 13, CategoryId = 22, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "میز تحریر تاشو پنل دار وایت بردی (سایز 70)" },
                new Product { Id = 14, CategoryId = 23, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "صندلی نماز حرمی قهوه ای کد 10(پایه استیل)" },
                new Product { Id = 15, CategoryId = 23, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "صندلی گیمینگ ،صندلی گیم اریا " },
                new Product { Id = 16, CategoryId = 29, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "پیراهن مردانه پشمی تک جیب" },
                new Product { Id = 17, CategoryId = 29, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "پیراهن مردانه بنگال کشی" },
                new Product { Id = 18, CategoryId = 29, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "پیراهن مردانه تترون درجه یک" },
                new Product { Id = 19, CategoryId = 31, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "جلیقه مردانه" },
                new Product { Id = 20, CategoryId = 31, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "کت و شلوار فاستونی" },
                new Product { Id = 21, CategoryId = 31, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, Name = "کت وشلوار سوپر کش" },
                new Product { Id = 22, CategoryId = 32, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "عینک آفتابی مردانه شیشه سنگ امریکن اپتیک AO" },
                new Product { Id = 23, CategoryId = 32, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "عینک آفتابی مارک جنتل مانستر دارای یووی 400" },
                new Product { Id = 24, CategoryId = 32, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "عینک آفتابی مارک پلیس و دیتیا دارای یووی 400 " },
                new Product { Id = 25, CategoryId = 32, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "عینک ریبن خلبانی شیشه سنگ با پک کامل اورجینال" },
                new Product { Id = 26, CategoryId = 32, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, Name = "عینک آفتابی رندلف AO صاایران" }

            );
        }
    }
    public class ProductAttributeSeedData : IEntityTypeConfiguration<ProductsCustomAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductsCustomAttribute> builder)
        {
            builder.HasData(
                new ProductsCustomAttribute { Id = 1 , CreatedAt = DateTime.Now, ProductId = 1 ,AttributeId =1 ,AttributeValue = "2kg"},
                new ProductsCustomAttribute { Id = 2 , CreatedAt = DateTime.Now, ProductId = 2 ,AttributeId =1 ,AttributeValue = "300g"},
                new ProductsCustomAttribute { Id = 3 , CreatedAt = DateTime.Now, ProductId = 3 ,AttributeId =1 ,AttributeValue = "500g" },
                new ProductsCustomAttribute { Id = 4 , CreatedAt = DateTime.Now, ProductId = 4 ,AttributeId =1 ,AttributeValue = "100g" },
                new ProductsCustomAttribute { Id = 5 , CreatedAt = DateTime.Now, ProductId = 5 ,AttributeId =1 ,AttributeValue = "50g" },
                new ProductsCustomAttribute { Id = 6 , CreatedAt = DateTime.Now, ProductId = 6 ,AttributeId =1 ,AttributeValue = "150g" },
                new ProductsCustomAttribute { Id = 7 , CreatedAt = DateTime.Now, ProductId = 7 ,AttributeId =1 ,AttributeValue = "500g" },
                new ProductsCustomAttribute { Id = 8 , CreatedAt = DateTime.Now, ProductId = 8 ,AttributeId =1 ,AttributeValue = "300g" },
                new ProductsCustomAttribute { Id = 9 , CreatedAt = DateTime.Now, ProductId = 9 ,AttributeId =1 ,AttributeValue = "3kg" },
                new ProductsCustomAttribute { Id = 10 , CreatedAt = DateTime.Now, ProductId = 10 ,AttributeId =1 ,AttributeValue = "400g" },
                new ProductsCustomAttribute { Id = 11 , CreatedAt = DateTime.Now, ProductId = 11 ,AttributeId =1 ,AttributeValue = "200g" },
                new ProductsCustomAttribute { Id = 12 , CreatedAt = DateTime.Now, ProductId = 12 ,AttributeId =1 ,AttributeValue = "5kg" },
                new ProductsCustomAttribute { Id = 13 , CreatedAt = DateTime.Now, ProductId = 13 ,AttributeId =1 ,AttributeValue = "500g" },
                new ProductsCustomAttribute { Id = 14 , CreatedAt = DateTime.Now, ProductId = 14 ,AttributeId =1 ,AttributeValue = "500g" },
                new ProductsCustomAttribute { Id = 15 , CreatedAt = DateTime.Now, ProductId = 15 ,AttributeId =1 ,AttributeValue = "900g" },
                new ProductsCustomAttribute { Id = 16 , CreatedAt = DateTime.Now, ProductId = 17 ,AttributeId =1 ,AttributeValue = "100g" },
                new ProductsCustomAttribute { Id = 17 , CreatedAt = DateTime.Now, ProductId = 18 ,AttributeId =1 ,AttributeValue = "100g" },
                new ProductsCustomAttribute { Id = 18 , CreatedAt = DateTime.Now, ProductId = 19 ,AttributeId =1 ,AttributeValue = "100g" },
                new ProductsCustomAttribute { Id = 19 , CreatedAt = DateTime.Now, ProductId = 20 ,AttributeId =1 ,AttributeValue = "50g" },
                new ProductsCustomAttribute { Id = 20 , CreatedAt = DateTime.Now, ProductId = 21 ,AttributeId =1 ,AttributeValue = "400g" },
                new ProductsCustomAttribute { Id = 21 , CreatedAt = DateTime.Now, ProductId = 22 ,AttributeId =1 ,AttributeValue = "300g" },
                new ProductsCustomAttribute { Id = 22 , CreatedAt = DateTime.Now, ProductId = 23 ,AttributeId =1 ,AttributeValue = "50g" },
                new ProductsCustomAttribute { Id = 23 , CreatedAt = DateTime.Now, ProductId = 24 ,AttributeId =1 ,AttributeValue = "50g" },
                new ProductsCustomAttribute { Id = 24 , CreatedAt = DateTime.Now, ProductId = 25 ,AttributeId =1 ,AttributeValue = "50g" },
                new ProductsCustomAttribute { Id = 25 , CreatedAt = DateTime.Now, ProductId = 16 ,AttributeId =1 ,AttributeValue = "50g" },
                new ProductsCustomAttribute { Id = 26 , CreatedAt = DateTime.Now, ProductId = 26 ,AttributeId =1 ,AttributeValue = "50g" }
                );
        }
    }
}

