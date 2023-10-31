using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPlace.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCustomAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributeTemlate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    TaskPercent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalerTypes", x => x.Id);
                    table.CheckConstraint("0 to 100", "([TaskPercent]<=(100) AND [TaskPercent]>=(0))");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoducts_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomAttributeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomAttributeTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributeTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryCustomAttribute_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryCustomAttribute_CustomAttributeTemplate",
                        column: x => x.CustomAttributeTemplateId,
                        principalTable: "CategoryCustomAttribute",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Provience",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Salers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saler_SalerTypes",
                        column: x => x.SalerTypeId,
                        principalTable: "SalerTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: " ProductsCustomAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomAttribute_CustomAttributeTemlate",
                        column: x => x.AttributeId,
                        principalTable: "CategoryCustomAttribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCustomAttribute_Peoducts",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BootId = table.Column<int>(type: "int", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoothProductsAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoothProductsAction_Peoducts",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuctionPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PicturesActions_BoothProductsAction",
                        column: x => x.AuctionId,
                        principalTable: "Actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PicturesActions_Pictures",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Booths",
                columns: table => new
                {
                    SalerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShopAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.SalerId);
                    table.ForeignKey(
                        name: "FK_Booth_Address",
                        column: x => x.ShopAddressId,
                        principalTable: "MainAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booth_Saler",
                        column: x => x.SalerId,
                        principalTable: "Salers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Address",
                        column: x => x.AddressId,
                        principalTable: "MainAddresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BoothProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoothProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoothProducts_Booth",
                        column: x => x.BoothId,
                        principalTable: "Booths",
                        principalColumn: "SalerId");
                    table.ForeignKey(
                        name: "FK_BoothProducts_Peoducts",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuctionProposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    IsTopProposal = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionProposals_BoothProductsAction",
                        column: x => x.AuctionId,
                        principalTable: "Actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActionProposals_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BuyedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BoothProductsPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoothProductId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoothProductsPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoothProductsPrices_BoothProducts",
                        column: x => x.BoothProductId,
                        principalTable: "BoothProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Satisfaction = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BoothProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.CheckConstraint("0 to 5", "([Satisfaction]<=(5) AND [Satisfaction]>=(0))");
                    table.ForeignKey(
                        name: "FK_Comment_BoothProducts",
                        column: x => x.BoothProductId,
                        principalTable: "BoothProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomerPics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    BoothProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductPices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProductPices_BoothProducts",
                        column: x => x.BoothProductId,
                        principalTable: "BoothProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerProductPices_Pictures",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCustomerPics_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSalerPics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    BoothProductId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalerProductPic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalerProductPic_BoothProducts",
                        column: x => x.BoothProductId,
                        principalTable: "BoothProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalerProductPic_Pictures",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BoothProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_BoothProducts",
                        column: x => x.BoothProductId,
                        principalTable: "BoothProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLine_Order",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "PersonalCode" },
                values: new object[,]
                {
                    { 1, "2682" },
                    { 2, "4343" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, null, "خانه و آشپز خانه" },
                    { 2, null, "مد و پوشاک" },
                    { 3, null, "مواد غذایی" },
                    { 4, 1, "لوازم آشپزخانه" },
                    { 5, 1, "لوازم برقی" },
                    { 6, 1, "مبلمان، میز و صندلی" },
                    { 7, 2, "زنانه" },
                    { 8, 2, "مردانه" },
                    { 9, 3, "خوار و بار" },
                    { 10, 3, "نوشیدنی" },
                    { 11, 3, "لبنیات" },
                    { 12, 3, "ترشی و شور" },
                    { 13, 4, "لوازم پخت و پز" },
                    { 14, 4, "ظروف آشپزخانه" },
                    { 15, 4, "فلاسک، کلمن و ماگ" },
                    { 16, 4, "ظروف یکبار مصرف" },
                    { 18, 5, "یخچال و فریزر" },
                    { 19, 5, "چای ساز و قهوه ساز" },
                    { 20, 5, "جارو برقی، جارو شارژی و بخار شوی" },
                    { 21, 6, "مبل" },
                    { 22, 6, "میز" },
                    { 23, 6, "صندلی" },
                    { 24, 6, "کمد، کتابخانه و بوفه" },
                    { 25, 7, "بلوز، پیراهن و شومیز زنانه" },
                    { 26, 7, "کیف زنانه" },
                    { 27, 7, "ساعت زنانه" },
                    { 28, 7, "اکسسوری زنانه" },
                    { 29, 8, "بلوز و پیراهن مردانه" },
                    { 30, 8, "لباس راحتی مردانه" },
                    { 31, 8, "کت شلوار و جلیقه مردانه" },
                    { 32, 8, "عینک مردانه" },
                    { 33, 8, "ساعت مردانه" },
                    { 34, 9, "برنج" },
                    { 35, 9, "حبوبات و سویا" },
                    { 36, 9, "غلات" },
                    { 37, 9, "نان" },
                    { 38, 9, "آرد" },
                    { 39, 10, "چای" },
                    { 40, 10, "دمنوش" },
                    { 41, 10, "عرقیات" },
                    { 42, 10, "قهوه" },
                    { 43, 10, "آب معدنی" },
                    { 44, 11, "پنیر" },
                    { 45, 11, "کره" },
                    { 46, 11, "شیر" },
                    { 47, 11, "ماست" },
                    { 48, 11, "دوغ" },
                    { 49, 12, "ترشی" },
                    { 50, 12, "زیتون" },
                    { 51, 12, "خیار شور" }
                });

            migrationBuilder.InsertData(
                table: "CategoryCustomAttribute",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "وزن" },
                    { 2, "ابعاد" },
                    { 3, "سایز" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "فارس" },
                    { 2, "تهران" },
                    { 3, "گیلان" },
                    { 4, "کرمان" },
                    { 5, "آذربایجان شرقی" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "شیراز", 1 },
                    { 2, "سروستان", 1 },
                    { 3, "تهران", 2 },
                    { 4, "کرج", 2 },
                    { 5, "رشت", 3 },
                    { 6, "ماسوله", 3 },
                    { 7, "کرمان", 4 },
                    { 8, "بردسیر", 4 },
                    { 9, "تبریز", 5 },
                    { 10, "مراغه", 5 }
                });

            migrationBuilder.InsertData(
                table: "CustomAttributeTemplates",
                columns: new[] { "Id", "CategoryId", "CustomAttributeTemplateId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 13, new DateTime(2023, 10, 31, 19, 13, 35, 896, DateTimeKind.Local).AddTicks(1001), null, null, null, "سرویس قابلمه 8 پارچه گرانیت", 2 },
                    { 2, 13, new DateTime(2023, 10, 31, 19, 13, 35, 896, DateTimeKind.Local).AddTicks(1005), null, null, null, "کباب زن آرکا", 2 },
                    { 3, 13, new DateTime(2023, 10, 31, 19, 13, 35, 896, DateTimeKind.Local).AddTicks(1008), null, null, null, "کباب روگازی کیوبی", 2 }
                });

            migrationBuilder.InsertData(
                table: " ProductsCustomAttributes",
                columns: new[] { "Id", "AttributeId", "AttributeValue", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "2kg", new DateTime(2023, 10, 31, 19, 13, 35, 896, DateTimeKind.Local).AddTicks(645), null, null, null, 1 },
                    { 2, 1, "300g", new DateTime(2023, 10, 31, 19, 13, 35, 896, DateTimeKind.Local).AddTicks(666), null, null, null, 2 },
                    { 3, 1, "500g", new DateTime(2023, 10, 31, 19, 13, 35, 896, DateTimeKind.Local).AddTicks(668), null, null, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ ProductsCustomAttributes_AttributeId",
                table: " ProductsCustomAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ ProductsCustomAttributes_ProductId",
                table: " ProductsCustomAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ProductId",
                table: "Actions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionPictures_AuctionId",
                table: "AuctionPictures",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionPictures_PictureId",
                table: "AuctionPictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProposals_AuctionId",
                table: "AuctionProposals",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProposals_CustomerId",
                table: "AuctionProposals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BoothProducts_BoothId",
                table: "BoothProducts",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_BoothProducts_ProductId",
                table: "BoothProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BoothProductsPrices_BoothProductId",
                table: "BoothProductsPrices",
                column: "BoothProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Booths_ShopAddressId",
                table: "Booths",
                column: "ShopAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BoothProductId",
                table: "Comments",
                column: "BoothProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributeTemplates_CategoryId",
                table: "CustomAttributeTemplates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributeTemplates_CustomAttributeTemplateId",
                table: "CustomAttributeTemplates",
                column: "CustomAttributeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAddresses_CityId",
                table: "MainAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_BoothProductId",
                table: "OrderLines",
                column: "BoothProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerPics_BoothProductId",
                table: "ProductCustomerPics",
                column: "BoothProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerPics_CustomerId",
                table: "ProductCustomerPics",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerPics_PictureId",
                table: "ProductCustomerPics",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSalerPics_BoothProductId",
                table: "ProductSalerPics",
                column: "BoothProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSalerPics_PictureId",
                table: "ProductSalerPics",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Salers_SalerTypeId",
                table: "Salers",
                column: "SalerTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " ProductsCustomAttributes");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AuctionPictures");

            migrationBuilder.DropTable(
                name: "AuctionProposals");

            migrationBuilder.DropTable(
                name: "BoothProductsPrices");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CustomAttributeTemplates");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "ProductCustomerPics");

            migrationBuilder.DropTable(
                name: "ProductSalerPics");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "CategoryCustomAttribute");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BoothProducts");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Booths");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MainAddresses");

            migrationBuilder.DropTable(
                name: "Salers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "SalerTypes");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
