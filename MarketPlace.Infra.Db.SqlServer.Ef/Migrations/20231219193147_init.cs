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
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
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
                name: "CustomAttributeTemplates",
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    WagePercent = table.Column<byte>(type: "tinyint", nullable: false),
                    BaseSalesMoney = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerTypes", x => x.Id);
                    table.CheckConstraint("0 to 100", "([WagePercent]<=(100) AND [WagePercent]>=(0))");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wage = table.Column<int>(type: "int", nullable: false),
                    PaidPrice = table.Column<long>(type: "bigint", nullable: false),
                    FromWalletId = table.Column<int>(type: "int", nullable: false),
                    ToWalletId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountClaims_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AccountLogins_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AccountTokens_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PersonalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountRoles_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryCustomAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomAttributeTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCustomAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryCustomAttribute_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryCustomAttribute_CustomAttributeTemplate",
                        column: x => x.CustomAttributeTemplateId,
                        principalTable: "CustomAttributeTemplates",
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    SellerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salers_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seller_SellerTypes",
                        column: x => x.SellerTypeId,
                        principalTable: "SellerTypes",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                        principalTable: "CustomAttributeTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCustomAttribute_Peoducts",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Booths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShopAddressId = table.Column<int>(type: "int", nullable: true),
                    SalesMoney = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booth_Seller",
                        column: x => x.Id,
                        principalTable: "Salers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booths_MainAddresses_ShopAddressId",
                        column: x => x.ShopAddressId,
                        principalTable: "MainAddresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_MainAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "MainAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "date", nullable: false),
                    BasePrice = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoothProductsAuction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Booths_BoothId",
                        column: x => x.BoothId,
                        principalTable: "Booths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoothProductsAuction_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BoothProducts_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                name: "AuctionPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                        principalTable: "Auctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PicturesActions_Pictures",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                        principalTable: "Auctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActionProposals_Customers",
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
                    Price = table.Column<long>(type: "bigint", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                table: "Accounts",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Family", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "ec4839dd-f73c-4132-86d3-b195bbb21684", "mhmdttlbzd@gmail.com", false, "طالب زاده", false, null, "محمد", "MHMDTTLBZD@GMAIL.COM", "MHMDTTLBZD@GMAIL.COM", "AQAAAAIAAYagAAAAEKedMjf6SSmeLoIACHgfTreEolWtaUcVSXCXIdWJ+IHz724+5YwCCcKQnCGiQHMflQ==", null, false, "1f6acb14-67f4-437f-bbd6-3393db4964df", 1, false, "mhmdttlbzd@gmail.com" },
                    { 2, 0, "e541171f-f276-434b-9d95-d7a572045710", "example@gmail.com", false, "علی زاده", false, null, "محمد", null, "EXAMPLE@GMAIL.COM", "AQAAAAIAAYagAAAAEP8egLO9syxS/zU7n+Fu7M4CeZ/5nX/8W9a3Qnw1h6ATCtKOLAzzLy2Nql4y0UwmTw==", null, false, "edcaa621-2856-4057-b08c-4945745ff378", 1, false, "example@gmail.com" },
                    { 3, 0, "3f0ecb5b-1c7e-4b0a-b727-800f9b821193", "ali@gmail.com", false, "سعیدی", false, null, "علی", "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEC3Ps79X1rN77/vEtdHTpJ/UYpX2u4P8J/q6XA2lRSX+Ij2ks9emZ13hME+Evbq6eA==", null, false, "2fd09693-2fd0-4cd7-bc72-986afed16055", 1, false, "ali@gmail.com" },
                    { 4, 0, "518f36a1-be3a-4fea-b70d-64fdd7ae8cce", "reza@gmail.com", false, "شریفی", false, null, "رضا", "REZA@GMAIL.COM", "REZA@GMAIL.COM", "AQAAAAIAAYagAAAAELChhXk/u28Xo/K9C92PeWA4xzOFGhwOMrdxqh+N0/tv0VUZxWZ3QyKyAY+IJgMW+w==", null, false, "08ba8b1d-3b5d-45ba-bd32-fc3a3935b0c6", 1, false, "reza@gmail.com" },
                    { 5, 0, "ddaeecb9-5bd3-402e-b1b5-9fef979309a3", "saeed@gmail.com", false, "افشار", false, null, "سعید", "SAEED@GMAIL.COM", "SAEED@GMAIL.COM", "AQAAAAIAAYagAAAAELD+KmEU4Bonjbyf8neWWXt6co+0VCDjdKTtMAiNdXWbAY16rsY8D78AEcWOFbTViA==", null, false, "d85aa840-f2fc-4fa7-b66f-af9a8f3aa075", 1, false, "saeed@gmail.com" },
                    { 6, 0, "f0e3cd82-6d81-47f3-b602-258900c97a9a", "kazem@gmail.com", false, "کاظمی", false, null, "کاظم", "KAZEM@GMAIL.COM", "KAZEM@GMAIL.COM", "AQAAAAIAAYagAAAAEAdCLwaCgRmpGB+OByYH2neCr6gIS5uW76gqdyOxAWZQ3Ng3ei8DXc0P6m8zOG0nyg==", null, false, "1f2f4759-6c3e-4729-9124-21621b790533", 1, false, "kazem@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Customer", "CUSTOMER" },
                    { 3, null, "Seller", "SELLER" }
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
                table: "CustomAttributeTemplates",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "وزن" },
                    { 2, "ابعاد" },
                    { 3, "سایز" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Alt", "Path" },
                values: new object[,]
                {
                    { 1, null, "product/1.jpg" },
                    { 2, null, "product/2.jpg" },
                    { 3, null, "product/3.jpg" },
                    { 4, null, "product/4.jpg" },
                    { 5, null, "product/5.jpg" },
                    { 6, null, "product/6.jpg" },
                    { 7, null, "product/7.jpg" },
                    { 8, null, "product/8.jpg" },
                    { 9, null, "product/9.jpg" },
                    { 10, null, "product/Auction_american_1.jpeg" },
                    { 11, null, "product/Auction_american_2.jpeg" },
                    { 12, null, "product/Auction_monster_1.jpeg" },
                    { 13, null, "product/Auction_monster_2.jpeg" },
                    { 14, null, "product/Auction_police_1.jpeg" },
                    { 15, null, "product/Auction_police_2.jpeg" },
                    { 16, null, "product/Auction_pilot_1.jpeg" },
                    { 17, null, "product/Auction_randolph_1.jpeg" },
                    { 18, null, "product/Auction_randolph_2.jpeg" },
                    { 19, null, "product/Sbooth_american_1.jpeg" },
                    { 20, null, "product/Sbooth_american_2.jpeg" },
                    { 21, null, "product/Sbooth_monster_1.jpeg" },
                    { 22, null, "product/Sbooth_monster_2.jpeg" },
                    { 23, null, "product/Sbooth_police_1.jpeg" },
                    { 24, null, "product/Sbooth_police_2.jpeg" },
                    { 25, null, "product/Sbooth_pilot_1.jpeg" },
                    { 26, null, "product/Sbooth_vest_1.jpeg" },
                    { 27, null, "product/Sbooth_vest_2.jpeg" },
                    { 28, null, "product/Sbooth_vest_3.jpeg" },
                    { 29, null, "product/Sbooth_vest_4.jpeg" },
                    { 30, null, "product/Sbooth_suit_1.jpeg" },
                    { 31, null, "product/Sbooth_suit_2.jpeg" },
                    { 32, null, "product/Sbooth_suit_3.jpeg" },
                    { 33, null, "product/Sbooth_suit_4.jpeg" },
                    { 34, null, "product/Sbooth_bengalShirt_1.jpeg" },
                    { 35, null, "product/Sbooth_bengalShirt_2.jpeg" },
                    { 36, null, "product/Sbooth_bengalShirt_3.jpeg" },
                    { 37, null, "product/Sbooth_bengalShirt_4.jpeg" },
                    { 38, null, "product/Sbooth_arka_1.jpg" },
                    { 39, null, "product/Sbooth_arka_2.webp" },
                    { 40, null, "product/Sbooth_arka_3.webp" },
                    { 41, null, "product/Sbooth_kiubi_1.webp" },
                    { 42, null, "product/Sbooth_kiubi_2.webp" },
                    { 43, null, "product/Sbooth_kiubi_3.webp" },
                    { 44, null, "product/Sbooth_kiubi_4.webp" },
                    { 45, null, "product/Sbooth_kiubi_5.webp" },
                    { 46, null, "product/Sbooth_kiubi_6.webp" },
                    { 47, null, "product/Sbooth_kiubi_7.webp" },
                    { 48, null, "product/Sbooth_coffeepot_1.webp" },
                    { 49, null, "product/Sbooth_coffeepot_2.webp" },
                    { 50, null, "product/Sbooth_coffeepot_3.jpg" },
                    { 51, null, "product/Sbooth_pot_1.webp" },
                    { 52, null, "product/Sbooth_pot_2.webp" },
                    { 53, null, "product/Sbooth_pot_3.webp" },
                    { 54, null, "product/Sbooth_pot_4.webp" },
                    { 55, null, "product/Sbooth_pot_5.webp" },
                    { 56, null, "product/Sbooth_shirt_1.webp" },
                    { 57, null, "product/Sbooth_shirt_2.webp" },
                    { 58, null, "product/Sbooth_shirt_3.webp" },
                    { 59, null, "product/Sbooth_shirt_4.webp" },
                    { 60, null, "product/Sbooth_shirt_5.webp" },
                    { 61, null, "product/Sbooth_shirt_6.webp" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "آذربایجان شرقی" },
                    { 2, "آذربایجان غربی" },
                    { 3, "اردبیل" },
                    { 4, "اصفهان" },
                    { 5, "البرز" },
                    { 6, "ایلام" },
                    { 7, "بوشهر" },
                    { 8, "تهران" },
                    { 9, "چهارمحال بختیاری" },
                    { 10, "خراسان جنوبی" },
                    { 11, "خراسان رضوی" },
                    { 12, "خراسان شمالی" },
                    { 13, "خوزستان" },
                    { 14, "زنجان" },
                    { 15, "سمنان" },
                    { 16, "سیستان و بلوچستان" },
                    { 17, "فارس" },
                    { 18, "قزوین" },
                    { 19, "قم" },
                    { 20, "کردستان" },
                    { 21, "کرمان" },
                    { 22, "کرمانشاه" },
                    { 23, "کهکیلویه و بویراحمد" },
                    { 24, "گلستان" },
                    { 25, "گیلان" },
                    { 26, "لرستان" },
                    { 27, "مازندران" },
                    { 28, "مرکزی" },
                    { 29, "هرمزگان" },
                    { 30, "همدان" },
                    { 31, "یزد" }
                });

            migrationBuilder.InsertData(
                table: "SellerTypes",
                columns: new[] { "Id", "BaseSalesMoney", "Title", "WagePercent" },
                values: new object[,]
                {
                    { 1, 0L, "normal", (byte)5 },
                    { 2, 20000000L, "golden", (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "FromWalletId", "PaidPrice", "SaleType", "Time", "ToWalletId", "Wage" },
                values: new object[,]
                {
                    { 1, 2, 1000000L, 2, new DateTime(2023, 12, 19, 11, 31, 46, 37, DateTimeKind.Local).AddTicks(362), 5, 50000 },
                    { 2, 2, 500000L, 2, new DateTime(2023, 12, 19, 11, 31, 46, 37, DateTimeKind.Local).AddTicks(408), 5, 25000 },
                    { 3, 2, 100000L, 2, new DateTime(2023, 12, 19, 11, 31, 46, 37, DateTimeKind.Local).AddTicks(412), 5, 5000 },
                    { 4, 2, 1400000L, 2, new DateTime(2023, 12, 19, 11, 31, 46, 37, DateTimeKind.Local).AddTicks(415), 4, 75000 },
                    { 5, 3, 1300000L, 2, new DateTime(2023, 12, 19, 11, 31, 46, 37, DateTimeKind.Local).AddTicks(418), 4, 65000 }
                });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "PersonalCode" },
                values: new object[] { 1, "2682" });

            migrationBuilder.InsertData(
                table: "CategoryCustomAttribute",
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
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "کشکساری", 1 },
                    { 2, "سهند", 1 },
                    { 3, "سیس", 1 },
                    { 4, "دوزدوزان", 1 },
                    { 5, "تیمورلو", 1 },
                    { 6, "صوفیان", 1 },
                    { 7, "سردرود", 1 },
                    { 8, "هادیشهر", 1 },
                    { 9, "هشترود", 1 },
                    { 10, "زرنق", 1 },
                    { 11, "ترکمانچای", 1 },
                    { 12, "ورزقان", 1 },
                    { 13, "تسوج", 1 },
                    { 14, "زنوز", 1 },
                    { 15, "ایلخچی", 1 },
                    { 16, "شرفانه", 1 },
                    { 17, "مهربان", 1 },
                    { 18, "مبارک شهر", 1 },
                    { 19, "تیکمه داش", 1 },
                    { 20, "باسمنج", 1 },
                    { 21, "سیه رود", 1 },
                    { 22, "میانه", 1 },
                    { 23, "خمارلو", 1 },
                    { 24, "خواجه", 1 },
                    { 25, "بناب مرند", 1 },
                    { 26, "قره آغاج", 1 },
                    { 27, "وایقان", 1 },
                    { 28, "مراغه", 1 },
                    { 29, "ممقان", 1 },
                    { 30, "خامنه", 1 },
                    { 31, "خسروشاه", 1 },
                    { 32, "لیلان", 1 },
                    { 33, "نظرکهریزی", 1 },
                    { 34, "اهر", 1 },
                    { 35, "بخشایش", 1 },
                    { 36, "آقکند", 1 },
                    { 37, "جوان قلعه", 1 },
                    { 38, "کلیبر", 1 },
                    { 39, "مرند", 1 },
                    { 40, "اسکو", 1 },
                    { 41, "شندآباد", 1 },
                    { 42, "شربیان", 1 },
                    { 43, "گوگان", 1 },
                    { 44, "بستان آباد", 1 },
                    { 45, "تبریز", 1 },
                    { 46, "جلفا", 1 },
                    { 47, "اچاچی", 1 },
                    { 48, "هریس", 1 },
                    { 49, "یامچی", 1 },
                    { 50, "خاروانا", 1 },
                    { 51, "کوزه کنان", 1 },
                    { 52, "خداجو", 1 },
                    { 53, "آذرشهر", 1 },
                    { 54, "شبستر", 1 },
                    { 55, "سراب", 1 },
                    { 56, "ملکان", 1 },
                    { 57, "بناب", 1 },
                    { 58, "هوراند", 1 },
                    { 59, "کلوانق", 1 },
                    { 60, "ترک", 1 },
                    { 61, "عجب شیر", 1 },
                    { 62, "آبش احمد", 1 },
                    { 63, "تازه شهر", 2 },
                    { 64, "نالوس", 2 },
                    { 65, "ایواوغلی", 2 },
                    { 66, "شاهین دژ", 2 },
                    { 67, "گرد کشانه", 2 },
                    { 68, "باروق", 2 },
                    { 69, "سیلوانه", 2 },
                    { 70, "بازرگان", 2 },
                    { 71, "نازک علیا", 2 },
                    { 72, "ربط", 2 },
                    { 73, "تکاب", 2 },
                    { 74, "دیزج دیز", 2 },
                    { 75, "سیمینه", 2 },
                    { 76, "نوشین", 2 },
                    { 77, "میاندوآب", 2 },
                    { 78, "مرگنلر", 2 },
                    { 79, "سلماس", 2 },
                    { 80, "آواجیق", 2 },
                    { 81, "قطور", 2 },
                    { 82, "محمود آباد", 2 },
                    { 83, "خوی", 2 },
                    { 84, "نقده", 2 },
                    { 85, "سرو", 2 },
                    { 86, "خلیفان", 2 },
                    { 87, "پلدشت", 2 },
                    { 88, "میر آباد", 2 },
                    { 89, "اشنویه", 2 },
                    { 90, "زرآباد", 2 },
                    { 91, "بوکان", 2 },
                    { 92, "پیرانشهر", 2 },
                    { 93, "چهاربرج", 2 },
                    { 94, "قوشچی", 2 },
                    { 95, "شوط", 2 },
                    { 96, "ماکو", 2 },
                    { 97, "سیه چشمه", 2 },
                    { 98, "سردشت", 2 },
                    { 99, "کشاورز", 2 },
                    { 100, "فیروق", 2 },
                    { 101, "محمدیار", 2 },
                    { 102, "ارومیه", 2 },
                    { 103, "مهاباد", 2 },
                    { 104, "قره ضیاءالدین", 2 },
                    { 105, "پارس آباد", 3 },
                    { 106, "فخر آباد", 3 },
                    { 107, "کلور", 3 },
                    { 108, "نیر", 3 },
                    { 109, "اردبیل", 3 },
                    { 110, "اسلام آباد", 3 },
                    { 111, "تازه کندانگوت", 3 },
                    { 112, "مشکین شهر", 3 },
                    { 113, "جعفر اباد", 3 },
                    { 114, "مرادلو", 3 },
                    { 115, "خلخال", 3 },
                    { 116, "نمین", 3 },
                    { 117, "اصلاندوز", 3 },
                    { 118, "کوراییم", 3 },
                    { 119, "هیر", 3 },
                    { 120, "گیوی", 3 },
                    { 121, "گرمی", 3 },
                    { 122, "لاهرود", 3 },
                    { 123, "هشتجین", 3 },
                    { 124, "عنبران", 3 },
                    { 125, "تازهکند", 3 },
                    { 126, "قصابه", 3 },
                    { 127, "رضی", 3 },
                    { 128, "سرعین", 3 },
                    { 129, "بیله سوار", 3 },
                    { 130, "آبی بیگلو", 3 },
                    { 131, "گزبر خوار", 4 },
                    { 132, "زیار", 4 },
                    { 133, "زرین شهر", 4 },
                    { 134, "گلشن", 4 },
                    { 135, "پیربکران", 4 },
                    { 136, "خالدآباد", 4 },
                    { 137, "سجزی", 4 },
                    { 138, "گوگد", 4 },
                    { 139, "تیران", 4 },
                    { 140, "ونک", 4 },
                    { 141, "دهق", 4 },
                    { 142, "زواره", 4 },
                    { 143, "کاشان", 4 },
                    { 144, "ابوزیدآباد", 4 },
                    { 145, "اصغرآباد", 4 },
                    { 146, "بافران", 4 },
                    { 147, "شهرضا", 4 },
                    { 148, "خور", 4 },
                    { 149, "مجلسی", 4 },
                    { 150, "هرند", 4 },
                    { 151, "فولادشهر", 4 },
                    { 152, "کمشچه", 4 },
                    { 153, "کلیشادوسودرجان", 4 },
                    { 154, "لای بید", 4 },
                    { 155, "قهجاورستان", 4 },
                    { 156, "چرمهین", 4 },
                    { 157, "رزوه", 4 },
                    { 158, "فریدونشهر", 4 },
                    { 159, "طرقق رود", 4 },
                    { 160, "نصرآباد", 4 },
                    { 161, "برزک", 4 },
                    { 162, "سفید شهر", 4 },
                    { 163, "سمیرم", 4 },
                    { 164, "گلدشت", 4 },
                    { 165, "اردستان", 4 },
                    { 166, "جوشقان قالی", 4 },
                    { 167, "بویین و میاندشت", 4 },
                    { 168, "کرکوند", 4 },
                    { 169, "درچه", 4 },
                    { 170, "انارک", 4 },
                    { 171, "دولت اباد", 4 },
                    { 172, "ایمانشهر", 4 },
                    { 173, "گرگاب", 4 },
                    { 174, "حسن آباد", 4 },
                    { 175, "ده لنجان", 4 },
                    { 176, "حبیب آباد", 4 },
                    { 177, "بهاران شهر", 4 },
                    { 178, "میمه", 4 },
                    { 179, "تو دشت", 4 },
                    { 180, "گلشهر", 4 },
                    { 181, "رضوانشهر", 4 },
                    { 182, "داران", 4 },
                    { 183, "علویجه", 4 },
                    { 184, "نیک آباد", 4 },
                    { 185, "مشکات", 4 },
                    { 186, "آران و بیدگل", 4 },
                    { 187, "خوانسار", 4 },
                    { 188, "نجف آباد", 4 },
                    { 189, "منظریه", 4 },
                    { 190, "فرخی", 4 },
                    { 191, "دیزیچه", 4 },
                    { 192, "اژیه", 4 },
                    { 193, "زاینده رود", 4 },
                    { 194, "خورزوق", 4 },
                    { 195, "قهدریجان", 4 },
                    { 196, "شاهین شهر", 4 },
                    { 197, "بهارستان", 4 },
                    { 198, "چمگردان", 4 },
                    { 199, "دهاقان", 4 },
                    { 200, "برف انبار", 4 },
                    { 201, "بادرود", 4 },
                    { 202, "کوهپایه", 4 },
                    { 203, "گلپایگان", 4 },
                    { 204, "عسگران", 4 },
                    { 205, "حنا", 4 },
                    { 206, "کهریزک", 4 },
                    { 207, "مهاباد", 4 },
                    { 208, "کامو چوگان", 4 },
                    { 209, "افوس", 4 },
                    { 210, "زیبا شهر", 4 },
                    { 211, "کوشک", 4 },
                    { 212, "نایین", 4 },
                    { 213, "سین", 4 },
                    { 214, "زازران", 4 },
                    { 215, "مبارکه", 4 },
                    { 216, "ورزنه", 4 },
                    { 217, "ورنامخواست", 4 },
                    { 218, "شاپور آباد", 4 },
                    { 219, "فلاورجان", 4 },
                    { 220, "وزوان", 4 },
                    { 221, "اصفهان", 4 },
                    { 222, "باغ بهادران", 4 },
                    { 223, "چادگان", 4 },
                    { 224, "دامنه", 4 },
                    { 225, "نطنز", 4 },
                    { 226, "محمد آباد", 4 },
                    { 227, "نیاسر", 4 },
                    { 228, "نوش آباد", 4 },
                    { 229, "کمه", 4 },
                    { 230, "جوزدان", 4 },
                    { 231, "قمصر", 4 },
                    { 232, "جندق", 4 },
                    { 233, "طالخونچه", 4 },
                    { 234, "خمینی شهر", 4 },
                    { 235, "باغشاد", 4 },
                    { 236, "دستگرد", 4 },
                    { 237, "ابریشم", 4 },
                    { 238, "چهارباغ", 5 },
                    { 239, "آسارا", 5 },
                    { 240, "کرج", 5 },
                    { 241, "طالقان", 5 },
                    { 242, "شهرجدیدهشتگرد", 5 },
                    { 243, "محمدشهر", 5 },
                    { 244, "مشکین دشت", 5 },
                    { 245, "نظرآباد", 5 },
                    { 246, "هشتگرد", 5 },
                    { 247, "ماهدشت", 5 },
                    { 248, "اشتهارد", 5 },
                    { 249, "کوهسار", 5 },
                    { 250, "گرمدره", 5 },
                    { 251, "تنکمان", 5 },
                    { 252, "گلسار", 5 },
                    { 253, "کمالشهر", 5 },
                    { 254, "فردیس", 5 },
                    { 255, "آبدانان", 6 },
                    { 256, "شباب", 6 },
                    { 257, "موسیان", 6 },
                    { 258, "بدره", 6 },
                    { 259, "ایلام", 6 },
                    { 260, "ایوان", 6 },
                    { 261, "مهران", 6 },
                    { 262, "آسمان آباد", 6 },
                    { 263, "پهله", 6 },
                    { 264, "مهر", 6 },
                    { 265, "سراب باغ", 6 },
                    { 266, "بلاوه", 6 },
                    { 267, "میمه", 6 },
                    { 268, "دره شهر", 6 },
                    { 269, "ارکواز", 6 },
                    { 270, "مورموری", 6 },
                    { 271, "توحید", 6 },
                    { 272, "دهلران", 6 },
                    { 273, "لومار", 6 },
                    { 274, "چوار", 6 },
                    { 275, "زرنه", 6 },
                    { 276, "صالح آباد", 6 },
                    { 277, "سرابله", 6 },
                    { 278, "ماژین", 6 },
                    { 279, "دلگشا", 6 },
                    { 280, "ریز", 7 },
                    { 281, "برازجان", 7 },
                    { 282, "بندریگ", 7 },
                    { 283, "اهرم", 7 },
                    { 284, "دوراهک", 7 },
                    { 285, "خورموج", 7 },
                    { 286, "نخل تقی", 7 },
                    { 287, "کلمه", 7 },
                    { 288, "بندر دیلم", 7 },
                    { 289, "وحدتیه", 7 },
                    { 290, "بنک", 7 },
                    { 291, "چغادک", 7 },
                    { 292, "بندر دیر", 7 },
                    { 293, "کاکی", 7 },
                    { 294, "جم", 7 },
                    { 295, "دالکی", 7 },
                    { 296, "بندرگناوه", 7 },
                    { 297, "آبدان", 7 },
                    { 298, "خارک", 7 },
                    { 299, "شنبه", 7 },
                    { 300, "بوشکان", 7 },
                    { 301, "انارستان", 7 },
                    { 302, "شبانکاره", 7 },
                    { 303, "سیراف", 7 },
                    { 304, "دلوار", 7 },
                    { 305, "بردستان", 7 },
                    { 306, "بادوله", 7 },
                    { 307, "عسلویه", 7 },
                    { 308, "تنگ ارم", 7 },
                    { 309, "امام حسن", 7 },
                    { 310, "سعد آباد", 7 },
                    { 311, "بندرکنگان", 7 },
                    { 312, "بوشهر", 7 },
                    { 313, "بردخون", 7 },
                    { 314, "آب پخش", 7 },
                    { 315, "شاهدشهر", 8 },
                    { 316, "پیشوا", 8 },
                    { 317, "جواد آباد", 8 },
                    { 318, "ارجمند", 8 },
                    { 319, "ری", 8 },
                    { 320, "نصیرشهر", 8 },
                    { 321, "رودهن", 8 },
                    { 322, "اندیشه", 8 },
                    { 323, "نسیم شهر", 8 },
                    { 324, "صباشهر", 8 },
                    { 325, "ملارد", 8 },
                    { 326, "شمشک", 8 },
                    { 327, "پاکدشت", 8 },
                    { 328, "باقر شهر", 8 },
                    { 329, "احمد آباد مستوفی", 8 },
                    { 330, "کیلان", 8 },
                    { 331, "قرچک", 8 },
                    { 332, "فردوسیه", 8 },
                    { 333, "گلستان", 8 },
                    { 334, "ورامین", 8 },
                    { 335, "فیروزکوه", 8 },
                    { 336, "فشم", 8 },
                    { 337, "پرند", 8 },
                    { 338, "آبعلی", 8 },
                    { 339, "چهاردانگه", 8 },
                    { 340, "تهران", 8 },
                    { 341, "بومهن", 8 },
                    { 342, "وحیدیه", 8 },
                    { 343, "صفادشت", 8 },
                    { 344, "لواسان", 8 },
                    { 345, "فرون اباد", 8 },
                    { 346, "کهریزک", 8 },
                    { 347, "رباطکریم", 8 },
                    { 348, "آبسرد", 8 },
                    { 349, "باغستان", 8 },
                    { 350, "صالحیه", 8 },
                    { 351, "شهریار", 8 },
                    { 352, "قدس", 8 },
                    { 353, "تجریش", 8 },
                    { 354, "شریف آباد", 8 },
                    { 355, "حسن آباد", 8 },
                    { 356, "اسلامشهر", 8 },
                    { 357, "دماوند", 8 },
                    { 358, "پردیس", 8 },
                    { 359, "وردنجان", 9 },
                    { 360, "گوجان", 9 },
                    { 361, "گهرو", 9 },
                    { 362, "سورشجان", 9 },
                    { 363, "سرخون", 9 },
                    { 364, "شهرکرد", 9 },
                    { 365, "منج", 9 },
                    { 366, "بروجن", 9 },
                    { 367, "پردنجان", 9 },
                    { 368, "سامان", 9 },
                    { 369, "فرخشهر", 9 },
                    { 370, "صمصامی", 9 },
                    { 371, "طاقانک", 9 },
                    { 372, "کاج", 9 },
                    { 373, "نقنه", 9 },
                    { 374, "لردگان", 9 },
                    { 375, "باباحیدر", 9 },
                    { 376, "دستنا", 9 },
                    { 377, "سودجان", 9 },
                    { 378, "بازفت", 9 },
                    { 379, "هفشجان", 9 },
                    { 380, "سردشت", 9 },
                    { 381, "فرادبنه", 9 },
                    { 382, "چلیچه", 9 },
                    { 383, "بن", 9 },
                    { 384, "فارسان", 9 },
                    { 385, "شلمزار", 9 },
                    { 386, "نافچ", 9 },
                    { 387, "دشتک", 9 },
                    { 388, "بلداجی", 9 },
                    { 389, "آلونی", 9 },
                    { 390, "گندمان", 9 },
                    { 391, "جونقان", 9 },
                    { 392, "ناغان", 9 },
                    { 393, "هارونی", 9 },
                    { 394, "چلگرد", 9 },
                    { 395, "کیان", 9 },
                    { 396, "اردل", 9 },
                    { 397, "سفید دشت", 9 },
                    { 398, "مال خلیفه", 9 },
                    { 399, "اسلامیه", 10 },
                    { 400, "شوسف", 10 },
                    { 401, "قاین", 10 },
                    { 402, "عشقآباد", 10 },
                    { 403, "طبس مسینا", 10 },
                    { 404, "ارسک", 10 },
                    { 405, "ایسک", 10 },
                    { 406, "نیمبلوک", 10 },
                    { 407, "دهوک", 10 },
                    { 408, "سربیشه", 10 },
                    { 409, "محمد شهر", 10 },
                    { 410, "بیرجند", 10 },
                    { 411, "فردوس", 10 },
                    { 412, "نهبندان", 10 },
                    { 413, "اسفدن", 10 },
                    { 414, "گریزک", 10 },
                    { 415, "حاجی آباد", 10 },
                    { 416, "سه قلعه", 10 },
                    { 417, "آرین شهر", 10 },
                    { 418, "مود", 10 },
                    { 419, "خوسف", 10 },
                    { 420, "قهستان", 10 },
                    { 421, "بشرویه", 10 },
                    { 422, "سرایان", 10 },
                    { 423, "خضری دشت بیاض", 10 },
                    { 424, "طبس", 10 },
                    { 425, "اسدیه", 10 },
                    { 426, "زهان", 10 },
                    { 427, "بار", 11 },
                    { 428, "نیل شهر", 11 },
                    { 429, "جنگل", 11 },
                    { 430, "درود", 11 },
                    { 431, "رباط سنگ", 11 },
                    { 432, "سلطان آباد", 11 },
                    { 433, "فریمان", 11 },
                    { 434, "گناباد", 11 },
                    { 435, "کاریز", 11 },
                    { 436, "همت آباد", 11 },
                    { 437, "سلامی", 11 },
                    { 438, "باجگیران", 11 },
                    { 439, "بجستان", 11 },
                    { 440, "چناران", 11 },
                    { 441, "درگز", 11 },
                    { 442, "کلات", 11 },
                    { 443, "چکنه", 11 },
                    { 444, "نصرآباد", 11 },
                    { 445, "بردسکن", 11 },
                    { 446, "مشهد", 11 },
                    { 447, "کدکن", 11 },
                    { 448, "نقاب", 11 },
                    { 449, "قلندر آباد", 11 },
                    { 450, "کاشمر", 11 },
                    { 451, "شاندیز", 11 },
                    { 452, "نشتیفان", 11 },
                    { 453, "ششتمد", 11 },
                    { 454, "شادمهر", 11 },
                    { 455, "عشق آباد", 11 },
                    { 456, "چاپشلو", 11 },
                    { 457, "رشتخوار", 11 },
                    { 458, "قدمگاه", 11 },
                    { 459, "صالح آباد", 11 },
                    { 460, "داورزن", 11 },
                    { 461, "فرهادگرد", 11 },
                    { 462, "کاخک", 11 },
                    { 463, "مشهدریزه", 11 },
                    { 464, "جغتای", 11 },
                    { 465, "مزدآوند", 11 },
                    { 466, "قوچان", 11 },
                    { 467, "یونسی", 11 },
                    { 468, "سنگان", 11 },
                    { 469, "نوخندان", 11 },
                    { 470, "کندر", 11 },
                    { 471, "نیشابور", 11 },
                    { 472, "احمد آباد صولت", 11 },
                    { 473, "شهر آباد", 11 },
                    { 474, "رضویه", 11 },
                    { 475, "تربت حیدریه", 11 },
                    { 476, "باخرز", 11 },
                    { 477, "سفیدسنگ", 11 },
                    { 478, "بیدخت", 11 },
                    { 479, "تایباد", 11 },
                    { 480, "فیروزه", 11 },
                    { 481, "قاسم آباد", 11 },
                    { 482, "سبزوار", 11 },
                    { 483, "فیض آباد", 11 },
                    { 484, "گلمکان", 11 },
                    { 485, "لطف آباد", 11 },
                    { 486, "شهروز", 11 },
                    { 487, "خرو", 11 },
                    { 488, "تربت جام", 11 },
                    { 489, "انابد", 11 },
                    { 490, "ملک آباد", 11 },
                    { 491, "بایک", 11 },
                    { 492, "دولت آباد", 11 },
                    { 493, "سرخس", 11 },
                    { 494, "ریوش", 11 },
                    { 495, "طرقبه", 11 },
                    { 496, "خواف", 11 },
                    { 497, "روداب", 11 },
                    { 498, "خلیل آباد", 11 },
                    { 499, "چناران شهر", 11 },
                    { 500, "راز", 12 },
                    { 501, "پیش قلعه", 12 },
                    { 502, "قوشخانه", 12 },
                    { 503, "شوقان", 12 },
                    { 504, "اسفراین", 12 },
                    { 505, "گرمه", 12 },
                    { 506, "قاضی", 12 },
                    { 507, "شیروان", 12 },
                    { 508, "حسار گرمخان", 12 },
                    { 509, "آشخانه", 12 },
                    { 510, "تیتکانلو", 12 },
                    { 511, "جاجرم", 12 },
                    { 512, "بجنورد", 12 },
                    { 513, "درق", 12 },
                    { 514, "آوا", 12 },
                    { 515, "زیارت", 12 },
                    { 516, "سنخواست", 12 },
                    { 517, "صفی آباد", 12 },
                    { 518, "ایور", 12 },
                    { 519, "فاروج", 12 },
                    { 520, "لوجلی", 12 },
                    { 521, "هفتگل", 13 },
                    { 522, "بیدروبه", 13 },
                    { 523, "شاوور", 13 },
                    { 524, "حمزه", 13 },
                    { 525, "گتوند", 13 },
                    { 526, "شرافت", 13 },
                    { 527, "منصوریه", 13 },
                    { 528, "زهره", 13 },
                    { 529, "رامهرمز", 13 },
                    { 530, "بندرامام خمینی", 13 },
                    { 531, "کوت عبدالله", 13 },
                    { 532, "میداود", 13 },
                    { 533, "چغامیش", 13 },
                    { 534, "ملاثانی", 13 },
                    { 535, "چم گلک", 13 },
                    { 536, "حر", 13 },
                    { 537, "شمس آباد", 13 },
                    { 538, "آبژدان", 13 },
                    { 539, "چویبده", 13 },
                    { 540, "مسجد سلیمان", 13 },
                    { 541, "مقاومت", 13 },
                    { 542, "ترکالکی", 13 },
                    { 543, "دارخوین", 13 },
                    { 544, "سردشت", 13 },
                    { 545, "لالی", 13 },
                    { 546, "کوت سیدنعیم", 13 },
                    { 547, "حمیدیه", 13 },
                    { 548, "دهدز", 13 },
                    { 549, "قلعه تل", 13 },
                    { 550, "میانرود", 13 },
                    { 551, "رفیع", 13 },
                    { 552, "اندیمشک", 13 },
                    { 553, "الوان", 13 },
                    { 554, "سالند", 13 },
                    { 555, "صالح شهر", 13 },
                    { 556, "اروندکنار", 13 },
                    { 557, "سرداران", 13 },
                    { 558, "تشان", 13 },
                    { 559, "رامشیر", 13 },
                    { 560, "شادگان", 13 },
                    { 561, "بندر ماهشهر", 13 },
                    { 562, "جایزان", 13 },
                    { 563, "بستان", 13 },
                    { 564, "ویس", 13 },
                    { 565, "اهواز", 13 },
                    { 566, "فتح المبین", 13 },
                    { 567, "شهر امام", 13 },
                    { 568, "قلعه خاجو", 13 },
                    { 569, "حسینیه", 13 },
                    { 570, "گلگیر", 13 },
                    { 571, "مینوشهر", 13 },
                    { 572, "سماله", 13 },
                    { 573, "شوشتر", 13 },
                    { 574, "بهبهان", 13 },
                    { 575, "هندیجان", 13 },
                    { 576, "ابوحمیظه", 13 },
                    { 577, "آغاجاری", 13 },
                    { 578, "ایذه", 13 },
                    { 579, "صیدون", 13 },
                    { 580, "سیاه منصور", 13 },
                    { 581, "هویزه", 13 },
                    { 582, "آزادی", 13 },
                    { 583, "شوش", 13 },
                    { 584, "دزفول", 13 },
                    { 585, "جنت مکان", 13 },
                    { 586, "آبادان", 13 },
                    { 587, "گوریه", 13 },
                    { 588, "خرمشهر", 13 },
                    { 589, "مشراگه", 13 },
                    { 590, "خنافره", 13 },
                    { 591, "چمران", 13 },
                    { 592, "امیدیه", 13 },
                    { 593, "سوسنگرد", 13 },
                    { 594, "شیبان", 13 },
                    { 595, "الهایی", 13 },
                    { 596, "باغ الملک", 13 },
                    { 597, "صفی آباد", 13 },
                    { 598, "سجاس", 14 },
                    { 599, "زرین رود", 14 },
                    { 600, "آب بر", 14 },
                    { 601, "ارمغانخانه", 14 },
                    { 602, "کرسف", 14 },
                    { 603, "هیدج", 14 },
                    { 604, "سلطانیه", 14 },
                    { 605, "خرمدره", 14 },
                    { 606, "نیک پی", 14 },
                    { 607, "قیدار", 14 },
                    { 608, "ابهر", 14 },
                    { 609, "دندی", 14 },
                    { 610, "حلب", 14 },
                    { 611, "نوربهار", 14 },
                    { 612, "گرماب", 14 },
                    { 613, "چورزق", 14 },
                    { 614, "زنجان", 14 },
                    { 615, "سهرود", 14 },
                    { 616, "صایین قلعه", 14 },
                    { 617, "ماه نشان", 14 },
                    { 618, "زرین آباد", 14 },
                    { 619, "ایوانکی", 15 },
                    { 620, "مجن", 15 },
                    { 621, "دامغان", 15 },
                    { 622, "سرخه", 15 },
                    { 623, "مهدیشهر", 15 },
                    { 624, "شاهرود", 15 },
                    { 625, "سمنان", 15 },
                    { 626, "کهن آباد", 15 },
                    { 627, "گرمسار", 15 },
                    { 628, "کلاته خیج", 15 },
                    { 629, "دیباج", 15 },
                    { 630, "درجزین", 15 },
                    { 631, "رودیان", 15 },
                    { 632, "بسطام", 15 },
                    { 633, "امیریه", 15 },
                    { 634, "میامی", 15 },
                    { 635, "شهمیزاد", 15 },
                    { 636, "بیارجمند", 15 },
                    { 637, "کلاته", 15 },
                    { 638, "آردان", 15 },
                    { 639, "محمدی", 16 },
                    { 640, "شهرک غلی اکبر", 16 },
                    { 641, "بنجار", 16 },
                    { 642, "گلمورتی", 16 },
                    { 643, "نگور", 16 },
                    { 644, "راسک", 16 },
                    { 645, "بنت", 16 },
                    { 646, "قصرقند", 16 },
                    { 647, "جالق", 16 },
                    { 648, "هیدوچ", 16 },
                    { 649, "نوک آباد", 16 },
                    { 650, "زهک", 16 },
                    { 651, "بمپور", 16 },
                    { 652, "پیشین", 16 },
                    { 653, "گشت", 16 },
                    { 654, "محمد آباد", 16 },
                    { 655, "زاهدان", 16 },
                    { 656, "", 16 },
                    { 657, "زابلی", 16 },
                    { 658, "چابهار", 16 },
                    { 659, "زراباد", 16 },
                    { 660, "بزمان", 16 },
                    { 661, "اسپکه", 16 },
                    { 662, "فنوچ", 16 },
                    { 663, "سراوان", 16 },
                    { 664, "ادیمی", 16 },
                    { 665, "زابل", 16 },
                    { 666, "دوشت محمد", 16 },
                    { 667, "ایرانشهر", 16 },
                    { 668, "سرباز", 16 },
                    { 669, "سیرکان", 16 },
                    { 670, "میرجاوه", 16 },
                    { 671, "نصرت آباد", 16 },
                    { 672, "سوران", 16 },
                    { 673, "خاش", 16 },
                    { 674, "کنارک", 16 },
                    { 675, "محمدان", 16 },
                    { 676, "نیک شهر", 16 },
                    { 677, "کازرون", 17 },
                    { 678, "کارزین(فتح اباد)", 17 },
                    { 679, "فدامی", 17 },
                    { 680, "خومه زار", 17 },
                    { 681, "سلطان شهر", 17 },
                    { 682, "فیروز آباد", 17 },
                    { 683, "دبیران", 17 },
                    { 684, "باب انار", 17 },
                    { 685, "رامجرد", 17 },
                    { 686, "سروستان", 17 },
                    { 687, "قره بلاغ", 17 },
                    { 688, "ارسنجان", 17 },
                    { 689, "دژکرد", 17 },
                    { 690, "بیرم", 17 },
                    { 691, "دهرم", 17 },
                    { 692, "شیراز", 17 },
                    { 693, "ایزدخواست", 17 },
                    { 694, "علامرودشت", 17 },
                    { 695, "اوز", 17 },
                    { 696, "وراوی", 17 },
                    { 697, "بیضا", 17 },
                    { 698, "نیریز", 17 },
                    { 699, "کنار تخته", 17 },
                    { 700, "امام شهر", 17 },
                    { 701, "جهرم", 17 },
                    { 702, "بابا منیر", 17 },
                    { 703, "گراش", 17 },
                    { 704, "فسا", 17 },
                    { 705, "شهر پیر", 17 },
                    { 706, "حسن آباد", 17 },
                    { 707, "کامفیروز", 17 },
                    { 708, "خنج", 17 },
                    { 709, "خانه زنیان", 17 },
                    { 710, "استهبان", 17 },
                    { 711, "بوانات", 17 },
                    { 712, "لطیفی", 17 },
                    { 713, "فراشبند", 17 },
                    { 714, "زرقان", 17 },
                    { 715, "صغاد", 17 },
                    { 716, "اشکنان", 17 },
                    { 717, "قایمیه", 17 },
                    { 718, "گله دار", 17 },
                    { 719, "دوبرجی", 17 },
                    { 720, "آباده طشک", 17 },
                    { 721, "خرامه", 17 },
                    { 722, "میمند", 17 },
                    { 723, "افزر", 17 },
                    { 724, "دوزه", 17 },
                    { 725, "سیدان", 17 },
                    { 726, "کوپن", 17 },
                    { 727, "زاهدشهر", 17 },
                    { 728, "قادر آباد", 17 },
                    { 729, "سده", 17 },
                    { 730, "بنارویه", 17 },
                    { 731, "سعادت شهر", 17 },
                    { 732, "شهر صدرا", 17 },
                    { 733, "سورمق", 17 },
                    { 734, "حسامی", 17 },
                    { 735, "جویم", 17 },
                    { 736, "خوزی", 17 },
                    { 737, "اردکان", 17 },
                    { 738, "قطرویه", 17 },
                    { 739, "نودان", 17 },
                    { 740, "مبارک آباد دیز", 17 },
                    { 741, "داراب", 17 },
                    { 742, "نور آباد", 17 },
                    { 743, "کوار", 17 },
                    { 744, "نوبندگان", 17 },
                    { 745, "حاجی آباد", 17 },
                    { 746, "خاوران", 17 },
                    { 747, "مرودشت", 17 },
                    { 748, "کوهنجان", 17 },
                    { 749, "ششده", 17 },
                    { 750, "مزایجان", 17 },
                    { 751, "ایج", 17 },
                    { 752, "خور", 17 },
                    { 753, "نوجین", 17 },
                    { 754, "لپویی", 17 },
                    { 755, "بهمن", 17 },
                    { 756, "اهل", 17 },
                    { 757, "خشت", 17 },
                    { 758, "مهر", 17 },
                    { 759, "جنت شهر", 17 },
                    { 760, "مشکان", 17 },
                    { 761, "بالاده", 17 },
                    { 762, "قیر", 17 },
                    { 763, "قطب آباد", 17 },
                    { 764, "خانیمن", 17 },
                    { 765, "مصیری", 17 },
                    { 766, "میانشهر", 17 },
                    { 767, "صفاشهر", 17 },
                    { 768, "اقلید", 17 },
                    { 769, "عمادده", 17 },
                    { 770, "مادر سلیمان", 17 },
                    { 771, "داریان", 17 },
                    { 772, "رونیز", 17 },
                    { 773, "کره ای", 17 },
                    { 774, "لار", 17 },
                    { 775, "اسیر", 17 },
                    { 776, "هماشهر", 17 },
                    { 777, "آباده", 17 },
                    { 778, "لامرد", 17 },
                    { 779, "سگز آباد", 18 },
                    { 780, "بیدستان", 18 },
                    { 781, "کوهین", 18 },
                    { 782, "رازمیان", 18 },
                    { 783, "خرمدشت", 18 },
                    { 784, "آبگرم", 18 },
                    { 785, "شال", 18 },
                    { 786, "شریفیه", 18 },
                    { 787, "اقبالیه", 18 },
                    { 788, "نرجه", 18 },
                    { 789, "ارداق", 18 },
                    { 790, "الوند", 18 },
                    { 791, "خاکعلی", 18 },
                    { 792, "سیردان", 18 },
                    { 793, "ضیاد آباد", 18 },
                    { 794, "بویین زهرا", 18 },
                    { 795, "محمدیه", 18 },
                    { 796, "محمود آباد نمونه", 18 },
                    { 797, "معلم کلایه", 18 },
                    { 798, "اسفرورین", 18 },
                    { 799, "آوج", 18 },
                    { 800, "دانسفهان", 18 },
                    { 801, "آبیک", 18 },
                    { 802, "قزوین", 18 },
                    { 803, "تاکستان", 18 },
                    { 804, "کهک", 19 },
                    { 805, "قم", 19 },
                    { 806, "سلفچگان", 19 },
                    { 807, "جعفریه", 19 },
                    { 808, "قنوات", 19 },
                    { 809, "دستجرد", 19 },
                    { 810, "توپ آغاج", 20 },
                    { 811, "سرو آباد", 20 },
                    { 812, "بویین سفلی", 20 },
                    { 813, "زرینه", 20 },
                    { 814, "دلبران", 20 },
                    { 815, "سنندج", 20 },
                    { 816, "یاسوکند", 20 },
                    { 817, "موچش", 20 },
                    { 818, "بانه", 20 },
                    { 819, "مریوان", 20 },
                    { 820, "سریش آباد", 20 },
                    { 821, "صاحب", 20 },
                    { 822, "دهگلان", 20 },
                    { 823, "بابارشانی", 20 },
                    { 824, "دیواندره", 20 },
                    { 825, "برده رشه", 20 },
                    { 826, "شویشه", 20 },
                    { 827, "بیجار", 20 },
                    { 828, "اورامان تخت", 20 },
                    { 829, "کانی سور", 20 },
                    { 830, "کانی دینار", 20 },
                    { 831, "دزج", 20 },
                    { 832, "سقز", 20 },
                    { 833, "بلبان آباد", 20 },
                    { 834, "پیرتاج", 20 },
                    { 835, "کامیاران", 20 },
                    { 836, "آرمرده", 20 },
                    { 837, "چناره", 20 },
                    { 838, "کهنوج", 21 },
                    { 839, "بلوک", 21 },
                    { 840, "پاریز", 21 },
                    { 841, "گنبکی", 21 },
                    { 842, "زنگی آباد", 21 },
                    { 843, "بم", 21 },
                    { 844, "خانوک", 21 },
                    { 845, "کیانشهر", 21 },
                    { 846, "جوپار", 21 },
                    { 847, "عنبرآباد", 21 },
                    { 848, "جوزم", 21 },
                    { 849, "نظام شهر", 21 },
                    { 850, "لاله زار", 21 },
                    { 851, "کشکوییه", 21 },
                    { 852, "زید آباد", 21 },
                    { 853, "هنزا", 21 },
                    { 854, "چترود", 21 },
                    { 855, "جبالبارز", 21 },
                    { 856, "سیرجان", 21 },
                    { 857, "رودبار", 21 },
                    { 858, "کرمان", 21 },
                    { 859, "بافت", 21 },
                    { 860, "صفاییه", 21 },
                    { 861, "منوجان", 21 },
                    { 862, "اندوهجرد", 21 },
                    { 863, "هجدک", 21 },
                    { 864, "خورسند", 21 },
                    { 865, "امین شهر", 21 },
                    { 866, "بردسیر", 21 },
                    { 867, "رفسنجان", 21 },
                    { 868, "هما شهر", 21 },
                    { 869, "محمد آباد", 21 },
                    { 870, "اختیار آباد", 21 },
                    { 871, "بروات", 21 },
                    { 872, "ریحان", 21 },
                    { 873, "کوهبنان", 21 },
                    { 874, "ماهان", 21 },
                    { 875, "دوساری", 21 },
                    { 876, "دهج", 21 },
                    { 877, "فاریاب", 21 },
                    { 878, "گلزار", 21 },
                    { 879, "بهرمان", 21 },
                    { 880, "بلورد", 21 },
                    { 881, "فهرج", 21 },
                    { 882, "کاظم آباد", 21 },
                    { 883, "جیرفت", 21 },
                    { 884, "نجف شهر", 21 },
                    { 885, "قلعه گنج", 21 },
                    { 886, "باغین", 21 },
                    { 887, "بزنجان", 21 },
                    { 888, "زرند", 21 },
                    { 889, "نودژ", 21 },
                    { 890, "گلباف", 21 },
                    { 891, "راور", 21 },
                    { 892, "خاتون آباد", 21 },
                    { 893, "نرماشیر", 21 },
                    { 894, "دشتکار", 21 },
                    { 895, "مس سرچشمه", 21 },
                    { 896, "خواجو شهر", 21 },
                    { 897, "رابر", 21 },
                    { 898, "راین", 21 },
                    { 899, "درب بهشت", 21 },
                    { 900, "یزدان شهر", 21 },
                    { 901, "زهکلوت", 21 },
                    { 902, "محی آباد", 21 },
                    { 903, "مردهک", 21 },
                    { 904, "شهداد", 21 },
                    { 905, "ارزوییه", 21 },
                    { 906, "نگار", 21 },
                    { 907, "شهر بابک", 21 },
                    { 908, "انار", 21 },
                    { 909, "سنقر", 22 },
                    { 910, "شاهو", 22 },
                    { 911, "بانوره", 22 },
                    { 912, "تازه آباد", 22 },
                    { 913, "هلشی", 22 },
                    { 914, "جوانرود", 22 },
                    { 915, "قصرشیرین", 22 },
                    { 916, "نوسود", 22 },
                    { 917, "کرند", 22 },
                    { 918, "کوزران", 22 },
                    { 919, "بیستون", 22 },
                    { 920, "حمیل", 22 },
                    { 921, "گیلانغرب", 22 },
                    { 922, "سطر", 22 },
                    { 923, "روانسر", 22 },
                    { 924, "پاوه", 22 },
                    { 925, "ازگله", 22 },
                    { 926, "کرمانشاه", 22 },
                    { 927, "میان راهان", 22 },
                    { 928, "کنگاور", 22 },
                    { 929, "سرپل ذهاب", 22 },
                    { 930, "ریجاب", 22 },
                    { 931, "باینگان", 22 },
                    { 932, "هرسین", 22 },
                    { 933, "اسلام آباد غرب", 22 },
                    { 934, "سرمست", 22 },
                    { 935, "سومار", 22 },
                    { 936, "نودشه", 22 },
                    { 937, "گهواره", 22 },
                    { 938, "رباط", 22 },
                    { 939, "صحنه", 22 },
                    { 940, "گودین", 22 },
                    { 941, "گراب سفلی", 23 },
                    { 942, "لنده", 23 },
                    { 943, "سی سخت", 23 },
                    { 944, "دهدشت", 23 },
                    { 945, "یاسوج", 23 },
                    { 946, "سرفاریاب", 23 },
                    { 947, "دوگنبدان", 23 },
                    { 948, "چیتاب", 23 },
                    { 949, "لیکک", 23 },
                    { 950, "دیشموک", 23 },
                    { 951, "مادوان", 23 },
                    { 952, "باشت", 23 },
                    { 953, "پاتاوه", 23 },
                    { 954, "قلعه رییسی", 23 },
                    { 955, "مارگون", 23 },
                    { 956, "چرام", 23 },
                    { 957, "سوق", 23 },
                    { 958, "سیمین شهر", 24 },
                    { 959, "مزرعه", 24 },
                    { 960, "رامیان", 24 },
                    { 961, "فراغی", 24 },
                    { 962, "گنبد کاووس", 24 },
                    { 963, "کردکوی", 24 },
                    { 964, "مراوه", 24 },
                    { 965, "بندر ترکمن", 24 },
                    { 966, "نگین شهر", 24 },
                    { 967, "آق قلا", 24 },
                    { 968, "سرخنکلاته", 24 },
                    { 969, "گلیکش", 24 },
                    { 970, "سنگدوین", 24 },
                    { 971, "دلند", 24 },
                    { 972, "بندر گز", 24 },
                    { 973, "نوده خاندوز", 24 },
                    { 974, "مینودشت", 24 },
                    { 975, "گرگان", 24 },
                    { 976, "گمیش تپه", 24 },
                    { 977, "علی آباد", 24 },
                    { 978, "خان ببین", 24 },
                    { 979, "کلاله", 24 },
                    { 980, "اینچه برون", 24 },
                    { 981, "فاضل آباد", 24 },
                    { 982, "تاتار علیا", 24 },
                    { 983, "نو کنده", 24 },
                    { 984, "آزادشهر", 24 },
                    { 985, "انبار آلوم", 24 },
                    { 986, "جلین", 24 },
                    { 987, "منجیل", 25 },
                    { 988, "شلمان", 25 },
                    { 989, "خشکبیجار", 25 },
                    { 990, "ماکلوان", 25 },
                    { 991, "سنگر", 25 },
                    { 992, "مرجقل", 25 },
                    { 993, "لیسار", 25 },
                    { 994, "رضوانشهر", 25 },
                    { 995, "رحیم آباد", 25 },
                    { 996, "لوندویل", 25 },
                    { 997, "احمد سرگوراب", 25 },
                    { 998, "لوشان", 25 },
                    { 999, "اطاقور", 25 },
                    { 1001, "لشت نشاء", 25 },
                    { 1002, "فومن", 25 },
                    { 1003, "چوبر", 25 },
                    { 1004, "بازار جمعه", 25 },
                    { 1005, "کلاچای", 25 },
                    { 1006, "بندر انزلی", 25 },
                    { 1007, "املش", 25 },
                    { 1008, "رستم آباد", 25 },
                    { 1009, "لاهیجان", 25 },
                    { 1010, "توتکابن", 25 },
                    { 1011, "لنگرود", 25 },
                    { 1012, "کوچصفهان", 25 },
                    { 1013, "صومعه سرا", 25 },
                    { 1014, "اسالم", 25 },
                    { 1015, "دیلمان", 25 },
                    { 1016, "رودسر", 25 },
                    { 1017, "کیاشهر", 25 },
                    { 1018, "شفت", 25 },
                    { 1019, "رودبار", 25 },
                    { 1020, "کومله", 25 },
                    { 1021, "رشت", 25 },
                    { 1022, "ماسوله", 25 },
                    { 1023, "خمام", 25 },
                    { 1024, "ماسال", 25 },
                    { 1025, "واجارگاه", 25 },
                    { 1026, "هشتپر (تالش)", 25 },
                    { 1027, "پره سر", 25 },
                    { 1028, "بره سر", 25 },
                    { 1029, "آستارا", 25 },
                    { 1030, "رودبنه", 25 },
                    { 1031, "جیرنده", 25 },
                    { 1032, "چاف و چمخاله", 25 },
                    { 1033, "لولمان", 25 },
                    { 1034, "گوراب زرمیخ", 25 },
                    { 1035, "حویق", 25 },
                    { 1036, "سیاهکل", 25 },
                    { 1037, "چابکسر", 25 },
                    { 1038, "آستانه اشرفیه", 25 },
                    { 1039, "رانکوه", 25 },
                    { 1040, "چلانچولان", 26 },
                    { 1041, "بیران شهر", 26 },
                    { 1042, "ویسیان", 26 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 13, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5166), null, false, null, "سرویس قابلمه 8 پارچه گرانیت", 2 },
                    { 2, 13, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5176), null, false, null, "کباب زن آرکا", 2 },
                    { 3, 13, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5180), null, false, null, "کباب روگازی کیوبی", 2 },
                    { 4, 16, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5184), null, false, null, "ظرف پلاستیکی یکبار مصرف", 2 },
                    { 5, 16, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5189), null, false, null, "لیوان کاغذی 50 عددی cc220", 1 },
                    { 6, 18, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5193), null, false, null, "دستگیره درب یخچال پارس", 1 },
                    { 7, 19, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5197), null, false, null, "فانل گتر قهوه سایز 51 مگنتیفانل گتر قهوه سایز 51 مگنتی", 1 },
                    { 8, 19, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5201), null, false, null, "قهوه جوش مسی دسته چوبی سیمین مس سایز یک", 2 },
                    { 9, 20, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5205), null, false, null, "جاروبرقی سطلی بوش", 1 },
                    { 10, 20, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5209), null, false, null, "جارو شارژی ماشین مدل HQ-01", 2 },
                    { 11, 21, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5214), null, false, null, "کاور مبل هفت نفره ماشال", 1 },
                    { 12, 21, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5218), null, false, null, "مبل راحتی اسکارلت 7 نفره پایه فلزی", 2 },
                    { 13, 22, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5222), null, false, null, "میز تحریر تاشو پنل دار وایت بردی (سایز 70)", 2 },
                    { 14, 23, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5226), null, false, null, "صندلی نماز حرمی قهوه ای کد 10(پایه استیل)", 2 },
                    { 15, 23, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5231), null, false, null, "صندلی گیمینگ ،صندلی گیم اریا ", 2 },
                    { 16, 29, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5235), null, false, null, "پیراهن مردانه پشمی تک جیب", 2 },
                    { 17, 29, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5239), null, false, null, "پیراهن مردانه بنگال کشی", 2 },
                    { 18, 29, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5243), null, false, null, "پیراهن مردانه تترون درجه یک", 2 },
                    { 19, 31, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5247), null, false, null, "جلیقه مردانه", 2 },
                    { 20, 31, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5251), null, false, null, "کت و شلوار فاستونی", 2 },
                    { 21, 31, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5255), null, false, null, "کت وشلوار سوپر کش", 1 },
                    { 22, 32, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5260), null, false, null, "عینک آفتابی مردانه شیشه سنگ امریکن اپتیک AO", 2 },
                    { 23, 32, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5264), null, false, null, "عینک آفتابی مارک جنتل مانستر دارای یووی 400", 2 },
                    { 24, 32, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5268), null, false, null, "عینک آفتابی مارک پلیس و دیتیا دارای یووی 400 ", 2 },
                    { 25, 32, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5272), null, false, null, "عینک ریبن خلبانی شیشه سنگ با پک کامل اورجینال", 2 },
                    { 26, 32, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(5276), null, false, null, "عینک آفتابی رندلف AO صاایران", 2 }
                });

            migrationBuilder.InsertData(
                table: "Salers",
                columns: new[] { "Id", "SellerTypeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Money" },
                values: new object[,]
                {
                    { 1, 1000000L },
                    { 2, 10000L },
                    { 3, 100000L },
                    { 4, 50000000L },
                    { 5, 21000000L },
                    { 6, 21000000L }
                });

            migrationBuilder.InsertData(
                table: " ProductsCustomAttributes",
                columns: new[] { "Id", "AttributeId", "AttributeValue", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "2kg", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3744), null, false, null, 1 },
                    { 2, 1, "300g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3757), null, false, null, 2 },
                    { 3, 1, "500g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3760), null, false, null, 3 },
                    { 4, 1, "100g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3764), null, false, null, 4 },
                    { 5, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3767), null, false, null, 5 },
                    { 6, 1, "150g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3771), null, false, null, 6 },
                    { 7, 1, "500g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3774), null, false, null, 7 },
                    { 8, 1, "300g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3777), null, false, null, 8 },
                    { 9, 1, "3kg", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3781), null, false, null, 9 },
                    { 10, 1, "400g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3784), null, false, null, 10 },
                    { 11, 1, "200g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3788), null, false, null, 11 },
                    { 12, 1, "5kg", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3791), null, false, null, 12 },
                    { 13, 1, "500g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3794), null, false, null, 13 },
                    { 14, 1, "500g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3798), null, false, null, 14 },
                    { 15, 1, "900g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3801), null, false, null, 15 },
                    { 16, 1, "100g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3805), null, false, null, 17 },
                    { 17, 1, "100g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3808), null, false, null, 18 },
                    { 18, 1, "100g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3811), null, false, null, 19 },
                    { 19, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3815), null, false, null, 20 },
                    { 20, 1, "400g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3819), null, false, null, 21 },
                    { 21, 1, "300g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3822), null, false, null, 22 },
                    { 22, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3847), null, false, null, 23 },
                    { 23, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3851), null, false, null, 24 },
                    { 24, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3854), null, false, null, 25 },
                    { 25, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3857), null, false, null, 16 },
                    { 26, 1, "50g", new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(3861), null, false, null, 26 }
                });

            migrationBuilder.InsertData(
                table: "MainAddresses",
                columns: new[] { "Id", "Address", "CityId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "PostalCode" },
                values: new object[,]
                {
                    { 1, "خیابان رحمت جنب کوچه 2", 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(1730), null, false, null, 1626627277 },
                    { 2, "خیابان ملاصدرا جنب کوچه 2", 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(1778), null, false, null, 1234567890 },
                    { 3, "خیابان شهناز جنب کوچه 2", 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(1781), null, false, null, 1634567611 },
                    { 4, "خیابان شهناز جنب کوچه 2", 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(1785), null, false, null, 1634567611 },
                    { 5, "خیابان داریوش جنب کوچه 2", 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(1788), null, false, null, 1713435657 }
                });

            migrationBuilder.InsertData(
                table: "Booths",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "Name", "SalesMoney", "ShopAddressId" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4685), null, false, null, "رضا لباس", 2700000L, 3 },
                    { 5, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4695), null, false, null, "برادران افشار", 1600000L, 4 },
                    { 6, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4698), null, false, null, "کاظم لباس", 0L, 5 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BasePrice", "BoothId", "CreatedAt", "DeletedAt", "Description", "ExpiredTime", "IsDeleted", "ModifiedAt", "ProductId" },
                values: new object[,]
                {
                    { 1, 500000L, 4, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3272), null, "یک کار ترک عالی با قیمتی باور نکردنی همین کار رو داخل غرفه و جنس ایرانی داریم میفروشیم یک ملیون نخری ضرر کردی", new DateTime(2023, 12, 26, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3282), false, null, 20 },
                    { 2, 100000L, 4, new DateTime(2023, 12, 11, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3290), null, "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند", new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3293), false, null, 20 },
                    { 3, 100000L, 4, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3298), null, "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند", new DateTime(2023, 12, 26, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3307), false, null, 22 },
                    { 4, 100000L, 4, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3312), null, "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند", new DateTime(2023, 12, 26, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3315), false, null, 23 },
                    { 5, 100000L, 6, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3319), null, "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند", new DateTime(2023, 12, 26, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3322), false, null, 24 },
                    { 6, 100000L, 6, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3326), null, "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند", new DateTime(2023, 12, 26, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3329), false, null, 25 },
                    { 7, 100000L, 6, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3333), null, "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند", new DateTime(2023, 12, 26, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(3336), false, null, 26 }
                });

            migrationBuilder.InsertData(
                table: "BoothProducts",
                columns: new[] { "Id", "BoothId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 17, 50 },
                    { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 18, 50 },
                    { 3, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 19, 50 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 20, 50 },
                    { 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 22, 50 },
                    { 6, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 23, 50 },
                    { 7, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 24, 50 },
                    { 8, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 25, 50 },
                    { 9, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 26, 50 },
                    { 10, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1, 100 },
                    { 11, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 2, 100 },
                    { 12, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 3, 100 },
                    { 13, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 4, 100 },
                    { 14, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 8, 100 },
                    { 15, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 16, 50 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BuyedAt", "CustomerId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(2589), 2, 3 },
                    { 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(2598), 2, 3 },
                    { 3, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(2602), 2, 3 },
                    { 4, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(2605), 2, 3 },
                    { 5, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(2727), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "AuctionPictures",
                columns: new[] { "Id", "AuctionId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "PictureId", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2140), null, false, null, 6, 2 },
                    { 2, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2186), null, false, null, 7, 2 },
                    { 3, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2189), null, false, null, 8, 2 },
                    { 4, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2193), null, false, null, 9, 2 },
                    { 5, 3, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2196), null, false, null, 10, 2 },
                    { 6, 3, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2199), null, false, null, 11, 2 },
                    { 7, 4, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2202), null, false, null, 12, 2 },
                    { 8, 4, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2206), null, false, null, 13, 2 },
                    { 9, 5, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2209), null, false, null, 14, 2 },
                    { 10, 5, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2212), null, false, null, 15, 2 },
                    { 11, 6, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2215), null, false, null, 16, 2 },
                    { 12, 7, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2219), null, false, null, 17, 2 },
                    { 13, 7, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2222), null, false, null, 18, 2 }
                });

            migrationBuilder.InsertData(
                table: "AuctionProposals",
                columns: new[] { "Id", "AuctionId", "CreatedAt", "CustomerId", "DeletedAt", "IsDeleted", "IsTopProposal", "ModifiedAt", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2717), 3, null, false, true, null, 550000L },
                    { 2, 1, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2741), 3, null, false, false, null, 520000L },
                    { 3, 3, new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2746), 3, null, false, true, null, 120000L },
                    { 4, 3, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2750), 3, null, false, false, null, 110000L },
                    { 5, 4, new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2754), 3, null, false, true, null, 120000L },
                    { 6, 4, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2757), 3, null, false, false, null, 110000L },
                    { 7, 5, new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2761), 3, null, false, true, null, 120000L },
                    { 8, 5, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2765), 3, null, false, false, null, 110000L },
                    { 9, 6, new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2769), 3, null, false, true, null, 120000L },
                    { 10, 6, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2772), 3, null, false, false, null, 110000L },
                    { 11, 7, new DateTime(2023, 12, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2776), 3, null, false, true, null, 120000L },
                    { 12, 7, new DateTime(2023, 12, 17, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(2780), 3, null, false, false, null, 110000L }
                });

            migrationBuilder.InsertData(
                table: "BoothProductsPrices",
                columns: new[] { "Id", "BoothProductId", "FromDate", "Price", "ToDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4197), 400000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4204) },
                    { 2, 2, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4215), 300000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4217) },
                    { 3, 3, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4229), 300000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4231) },
                    { 4, 4, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4236), 1000000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4238) },
                    { 5, 5, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4245), 700000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4248) },
                    { 6, 6, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4252), 700000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4255) },
                    { 7, 7, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4258), 700000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4261) },
                    { 8, 8, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4265), 700000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4267) },
                    { 9, 9, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4271), 700000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4274) },
                    { 10, 10, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4277), 500000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4280) },
                    { 11, 11, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4284), 500000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4286) },
                    { 12, 12, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4290), 500000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4292) },
                    { 13, 13, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4296), 20000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4298) },
                    { 14, 14, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4302), 100000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4305) },
                    { 15, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4308), 500000L, new DateTime(2024, 1, 18, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(4311) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BoothProductId", "CreatedAt", "CustomerId", "DeletedAt", "Description", "IsDeleted", "ModifiedAt", "Satisfaction", "Status" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8200), 2, null, "عالی واقعا راضی بودم از همین برا دمکنی و دستگیره استفاده میکنم", false, null, (byte)2, 1 },
                    { 2, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8218), 2, null, "عالی", false, null, (byte)5, 1 },
                    { 3, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8223), 3, null, "بد بود", false, null, (byte)1, 1 },
                    { 4, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8227), 3, null, "راضی بودم ولی خاک تو سرشون با بسته بندیشون", false, null, (byte)4, 1 },
                    { 5, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8230), 2, null, "دوسش داشتم", false, null, (byte)5, 1 },
                    { 6, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8234), 2, null, "برا بابام کادو گرفتم هنوز ندیده که بگم خوبه یا بد", false, null, (byte)3, 1 },
                    { 7, 15, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8238), 3, null, "بدک نبود", false, null, (byte)3, 1 },
                    { 8, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8241), 3, null, "خیلی خوب دمتون گرم", false, null, (byte)5, 1 },
                    { 9, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8245), 2, null, "مضخرف", false, null, (byte)2, 1 },
                    { 10, 1, new DateTime(2023, 12, 19, 11, 31, 45, 377, DateTimeKind.Local).AddTicks(8249), 2, null, "یه هفتس خریدم به دستم نرسیده", false, null, (byte)2, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "BoothProductId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 14, 1, 10 },
                    { 2, 12, 2, 1 },
                    { 3, 14, 3, 1 },
                    { 4, 15, 4, 2 },
                    { 5, 1, 4, 1 },
                    { 6, 15, 5, 2 },
                    { 7, 1, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductCustomerPics",
                columns: new[] { "Id", "BoothProductId", "CreatedAt", "CustomerId", "DeletedAt", "IsDeleted", "ModifiedAt", "PictureId", "Status" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4267), 2, null, false, null, 1, 2 },
                    { 2, 15, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4276), 2, null, false, null, 2, 2 },
                    { 3, 15, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4279), 2, null, false, null, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductSalerPics",
                columns: new[] { "Id", "BoothProductId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "PictureId", "Status" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4593), null, false, null, 4, 2 },
                    { 2, 15, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4602), null, false, null, 5, 2 },
                    { 3, 5, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4606), null, false, null, 19, 2 },
                    { 4, 5, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4609), null, false, null, 20, 2 },
                    { 5, 6, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4612), null, false, null, 21, 2 },
                    { 6, 6, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4616), null, false, null, 22, 2 },
                    { 7, 7, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4619), null, false, null, 23, 2 },
                    { 8, 7, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4623), null, false, null, 24, 2 },
                    { 9, 8, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4626), null, false, null, 25, 2 },
                    { 10, 3, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4629), null, false, null, 26, 2 },
                    { 11, 3, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4633), null, false, null, 27, 2 },
                    { 12, 3, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4636), null, false, null, 28, 2 },
                    { 13, 3, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4639), null, false, null, 29, 2 },
                    { 14, 4, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4644), null, false, null, 30, 2 },
                    { 15, 4, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4648), null, false, null, 31, 2 },
                    { 16, 4, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4651), null, false, null, 32, 2 },
                    { 17, 4, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4654), null, false, null, 33, 2 },
                    { 18, 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4658), null, false, null, 34, 2 },
                    { 19, 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4661), null, false, null, 35, 2 },
                    { 20, 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4664), null, false, null, 36, 2 },
                    { 21, 1, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4668), null, false, null, 37, 2 },
                    { 22, 11, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4671), null, false, null, 38, 2 },
                    { 23, 11, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4675), null, false, null, 39, 2 },
                    { 24, 11, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4678), null, false, null, 40, 2 },
                    { 25, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4681), null, false, null, 41, 2 },
                    { 26, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4685), null, false, null, 42, 2 },
                    { 27, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4688), null, false, null, 43, 2 },
                    { 28, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4691), null, false, null, 44, 2 },
                    { 29, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4695), null, false, null, 45, 2 },
                    { 30, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4698), null, false, null, 46, 2 },
                    { 31, 12, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4701), null, false, null, 47, 2 },
                    { 32, 14, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4705), null, false, null, 48, 2 },
                    { 33, 14, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4708), null, false, null, 49, 2 },
                    { 34, 14, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4712), null, false, null, 50, 2 },
                    { 35, 10, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4715), null, false, null, 51, 2 },
                    { 36, 10, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4719), null, false, null, 52, 2 },
                    { 37, 10, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4722), null, false, null, 53, 2 },
                    { 38, 10, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4725), null, false, null, 54, 2 },
                    { 39, 10, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4729), null, false, null, 55, 2 },
                    { 40, 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4732), null, false, null, 56, 2 },
                    { 41, 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4736), null, false, null, 57, 2 },
                    { 42, 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4739), null, false, null, 58, 2 },
                    { 43, 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4743), null, false, null, 59, 2 },
                    { 44, 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4746), null, false, null, 60, 2 },
                    { 45, 2, new DateTime(2023, 12, 19, 11, 31, 45, 629, DateTimeKind.Local).AddTicks(4749), null, false, null, 61, 2 }
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
                name: "IX_AccountClaims_UserId",
                table: "AccountClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLogins_UserId",
                table: "AccountLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Accounts",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Accounts",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_Auctions_BoothId",
                table: "Auctions",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ProductId",
                table: "Auctions",
                column: "ProductId");

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
                column: "ShopAddressId",
                unique: true,
                filter: "[ShopAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCustomAttribute_CategoryId",
                table: "CategoryCustomAttribute",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCustomAttribute_CustomAttributeTemplateId",
                table: "CategoryCustomAttribute",
                column: "CustomAttributeTemplateId");

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
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

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
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Salers_SellerTypeId",
                table: "Salers",
                column: "SellerTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " ProductsCustomAttributes");

            migrationBuilder.DropTable(
                name: "AccountClaims");

            migrationBuilder.DropTable(
                name: "AccountLogins");

            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropTable(
                name: "AccountTokens");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AuctionPictures");

            migrationBuilder.DropTable(
                name: "AuctionProposals");

            migrationBuilder.DropTable(
                name: "BoothProductsPrices");

            migrationBuilder.DropTable(
                name: "CategoryCustomAttribute");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "ProductCustomerPics");

            migrationBuilder.DropTable(
                name: "ProductSalerPics");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "CustomAttributeTemplates");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BoothProducts");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Booths");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Salers");

            migrationBuilder.DropTable(
                name: "MainAddresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SellerTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
