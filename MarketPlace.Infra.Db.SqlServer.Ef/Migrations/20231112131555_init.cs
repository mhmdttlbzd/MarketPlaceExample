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
                name: "SalerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    WagePercent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalerTypes", x => x.Id);
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
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
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
                        name: "FK_Peoducts_Categories",
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
                    SalerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saler_SalerTypes",
                        column: x => x.SalerTypeId,
                        principalTable: "SalerTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Salers_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booth_Saler",
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
                name: "Actions",
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
                    table.PrimaryKey("PK_BoothProductsAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Booths_BoothId",
                        column: x => x.BoothId,
                        principalTable: "Booths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoothProductsAction_Peoducts",
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
                        name: "FK_BoothProducts_Peoducts",
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
                        principalTable: "Actions",
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
                        principalTable: "Actions",
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
                    { 1, 0, "ebafa75b-bd71-46b3-af6e-361b3d05996f", "mhmdttlbzd@gmail.com", false, "طالب زاده", false, null, "محمد", "MHMDTTLBZD@GMAIL.COM", "MHMDTTLBZD@GMAIL.COM", "AQAAAAIAAYagAAAAEENO/MyQBfJ8PUx374tRMaKKaS9qTja+w8lhV1HI8rURPHrEgiIPhAkW4MGYyCMPqA==", null, false, "4cfa88de-1360-42c2-ab83-77e7785e2d1c", 1, false, "mhmdttlbzd@gmail.com" },
                    { 2, 0, "2e2cdeaa-c14a-419c-b68c-d17037e9ca8d", "example@gmail.com", false, "علی زاده", false, null, "محمد", null, "EXAMPLE@GMAIL.COM", "AQAAAAIAAYagAAAAEESoudMfd9Luy8wF/PPd21Kc5oIjvmdms+x/DyCYT/BQcWjRRbsZ18fmn/kiDaMlYg==", null, false, "d679af30-db00-4987-9821-14b14cce63e5", 1, false, "example@gmail.com" },
                    { 3, 0, "6094981a-2843-4e15-ab7c-d419ce7b90c2", "ali@gmail.com", false, "سعیدی", false, null, "علی", "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEF1b/LUE47+uvT+ztPzm+uqzFmGa/LScpCS4SZ7iHsxt7VdZi06wanD7uL1WTYuJXQ==", null, false, "f7e6fb18-49c1-4f17-9fa6-37e46d23a5e9", 1, false, "ali@gmail.com" },
                    { 4, 0, "9cce170b-f029-4eed-a276-9f82f7cbaed0", "reza@gmail.com", false, "شریفی", false, null, "رضا", "REZA@GMAIL.COM", "REZA@GMAIL.COM", "AQAAAAIAAYagAAAAEI+W9OYAxS6mxhnx/+MC6DtbJFPluwculws6HujRmKwNW88ao0nCBnorKokpfXI83A==", null, false, "90b826ce-c1bb-4128-bd1e-74fd19cc53d0", 1, false, "reza@gmail.com" },
                    { 5, 0, "6383aa86-b0d0-4d12-80e9-624b4c60b787", "saeed@gmail.com", false, "افشار", false, null, "سعید", "SAEED@GMAIL.COM", "SAEED@GMAIL.COM", "AQAAAAIAAYagAAAAEPMmrIzfxOXI79VF2Xpi/u7jkalW+m9ZIOaaHIJ9PHF2CLD1oLMOyCiRW76ewjGx8Q==", null, false, "233d6665-6d65-40a3-9dd9-eb1865679734", 1, false, "saeed@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Customer", "CUSTOMER" },
                    { 3, null, "Saler", "SALER" }
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
                    { 9, null, "product/9.jpg" }
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
                table: "SalerTypes",
                columns: new[] { "Id", "Title", "WagePercent" },
                values: new object[,]
                {
                    { 1, "normal", (byte)5 },
                    { 2, "golden", (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "FromWalletId", "PaidPrice", "SaleType", "Time", "ToWalletId", "Wage" },
                values: new object[,]
                {
                    { 1, 2, 1000000L, 2, new DateTime(2023, 11, 12, 16, 15, 54, 538, DateTimeKind.Local).AddTicks(8083), 5, 50000 },
                    { 2, 2, 500000L, 2, new DateTime(2023, 11, 12, 16, 15, 54, 538, DateTimeKind.Local).AddTicks(8097), 5, 25000 },
                    { 3, 2, 100000L, 2, new DateTime(2023, 11, 12, 16, 15, 54, 538, DateTimeKind.Local).AddTicks(8099), 5, 5000 },
                    { 4, 2, 1400000L, 2, new DateTime(2023, 11, 12, 16, 15, 54, 538, DateTimeKind.Local).AddTicks(8100), 4, 75000 },
                    { 5, 3, 1300000L, 2, new DateTime(2023, 11, 12, 16, 15, 54, 538, DateTimeKind.Local).AddTicks(8102), 4, 65000 }
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
                    { 5, 21000000L }
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
                    { 3, 5 }
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
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 13, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7954), null, false, null, "سرویس قابلمه 8 پارچه گرانیت", 2 },
                    { 2, 13, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7959), null, false, null, "کباب زن آرکا", 2 },
                    { 3, 13, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7961), null, false, null, "کباب روگازی کیوبی", 2 },
                    { 4, 16, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7963), null, false, null, "ظرف پلاستیکی یکبار مصرف", 2 },
                    { 5, 16, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7965), null, false, null, "لیوان کاغذی 50 عددی cc220", 1 },
                    { 6, 18, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7969), null, false, null, "دستگیره درب یخچال پارس", 1 },
                    { 7, 19, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7971), null, false, null, "فانل گتر قهوه سایز 51 مگنتیفانل گتر قهوه سایز 51 مگنتی", 1 },
                    { 8, 19, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7973), null, false, null, "قهوه جوش مسی دسته چوبی سیمین مس سایز یک", 2 },
                    { 9, 20, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7975), null, false, null, "جاروبرقی سطلی بوش", 1 },
                    { 10, 20, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7977), null, false, null, "جارو شارژی ماشین مدل HQ-01", 2 },
                    { 11, 21, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7980), null, false, null, "کاور مبل هفت نفره ماشال", 1 },
                    { 12, 21, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7982), null, false, null, "مبل راحتی اسکارلت 7 نفره پایه فلزی", 2 },
                    { 13, 22, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7984), null, false, null, "میز تحریر تاشو پنل دار وایت بردی (سایز 70)", 2 },
                    { 14, 23, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7986), null, false, null, "صندلی نماز حرمی قهوه ای کد 10(پایه استیل)", 2 },
                    { 15, 23, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7988), null, false, null, "صندلی گیمینگ ،صندلی گیم اریا ", 2 },
                    { 16, 29, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7991), null, false, null, "پیراهن مردانه پشمی تک جیب", 2 },
                    { 17, 29, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7993), null, false, null, "پیراهن مردانه بنگال کشی", 2 },
                    { 18, 29, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7996), null, false, null, "پیراهن مردانه تترون درجه یک", 2 },
                    { 19, 31, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7998), null, false, null, "جلیقه مردانه", 2 },
                    { 20, 31, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8000), null, false, null, "کت و شلوار فاستونی", 2 },
                    { 21, 31, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8002), null, false, null, "کت وشلوار سوپر کش", 1 },
                    { 22, 32, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8004), null, false, null, "عینک آفتابی مردانه شیشه سنگ امریکن اپتیک AO", 2 },
                    { 23, 32, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8007), null, false, null, "عینک آفتابی مارک جنتل مانستر دارای یووی 400", 2 },
                    { 24, 32, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8009), null, false, null, "عینک آفتابی مارک پلیس و دیتیا دارای یووی 400 ", 2 },
                    { 25, 32, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8011), null, false, null, "عینک ریبن خلبانی شیشه سنگ با پک کامل اورجینال", 2 },
                    { 26, 32, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(8013), null, false, null, "عینک آفتابی رندلف AO صاایران", 2 }
                });

            migrationBuilder.InsertData(
                table: "Salers",
                columns: new[] { "Id", "SalerTypeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: " ProductsCustomAttributes",
                columns: new[] { "Id", "AttributeId", "AttributeValue", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "2kg", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6810), null, false, null, 1 },
                    { 2, 1, "300g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6814), null, false, null, 2 },
                    { 3, 1, "500g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6816), null, false, null, 3 },
                    { 4, 1, "100g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6817), null, false, null, 4 },
                    { 5, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6819), null, false, null, 5 },
                    { 6, 1, "150g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6820), null, false, null, 6 },
                    { 7, 1, "500g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6821), null, false, null, 7 },
                    { 8, 1, "300g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6823), null, false, null, 8 },
                    { 9, 1, "3kg", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6824), null, false, null, 9 },
                    { 10, 1, "400g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6826), null, false, null, 10 },
                    { 11, 1, "200g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6827), null, false, null, 11 },
                    { 12, 1, "5kg", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6829), null, false, null, 12 },
                    { 13, 1, "500g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6831), null, false, null, 13 },
                    { 14, 1, "500g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6832), null, false, null, 14 },
                    { 15, 1, "900g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6834), null, false, null, 15 },
                    { 16, 1, "100g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6835), null, false, null, 17 },
                    { 17, 1, "100g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6837), null, false, null, 18 },
                    { 18, 1, "100g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6838), null, false, null, 19 },
                    { 19, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6839), null, false, null, 20 },
                    { 20, 1, "400g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6841), null, false, null, 21 },
                    { 21, 1, "300g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6842), null, false, null, 22 },
                    { 22, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6844), null, false, null, 23 },
                    { 23, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6845), null, false, null, 24 },
                    { 24, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6847), null, false, null, 25 },
                    { 25, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6849), null, false, null, 16 },
                    { 26, 1, "50g", new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(6850), null, false, null, 26 }
                });

            migrationBuilder.InsertData(
                table: "MainAddresses",
                columns: new[] { "Id", "Address", "CityId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "PostalCode" },
                values: new object[,]
                {
                    { 1, "خیابان رحمت جنب کوچه 2", 1, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5214), null, false, null, 1626627277 },
                    { 2, "خیابان ملاصدرا جنب کوچه 2", 1, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5225), null, false, null, 1234567890 },
                    { 3, "خیابان شهناز جنب کوچه 2", 1, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5227), null, false, null, 1634567611 },
                    { 4, "خیابان داریوش جنب کوچه 2", 1, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5228), null, false, null, 1213435657 }
                });

            migrationBuilder.InsertData(
                table: "Booths",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "Name", "ShopAddressId" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(9258), null, false, null, "رضا لباس", 3 },
                    { 5, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(9263), null, false, null, "برادران افشار", 4 }
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
                table: "Actions",
                columns: new[] { "Id", "BasePrice", "BoothId", "CreatedAt", "DeletedAt", "Description", "ExpiredTime", "IsDeleted", "ModifiedAt", "ProductId" },
                values: new object[] { 1, 500000L, 4, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(7717), null, "یک کار ترک عالی با قیمتی باور نکردنی همین کار رو داخل غرفه و جنس ایرانی داریم میفروشیم یک ملیون نخری ضرر کردی", new DateTime(2023, 11, 19, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(7720), false, null, 20 });

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
                    { 1, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5945), 2, 3 },
                    { 2, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5948), 2, 3 },
                    { 3, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5949), 2, 3 },
                    { 4, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5951), 2, 3 },
                    { 5, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(5952), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "AuctionPictures",
                columns: new[] { "Id", "AuctionId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "PictureId", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(7342), null, false, null, 6, 1 },
                    { 2, 1, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(7366), null, false, null, 7, 1 },
                    { 3, 1, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(7368), null, false, null, 8, 1 },
                    { 4, 1, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(7370), null, false, null, 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "BoothProductsPrices",
                columns: new[] { "Id", "BoothProductId", "FromDate", "Price", "ToDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8638), 400000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8641) },
                    { 2, 2, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8653), 300000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8654) },
                    { 3, 3, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8657), 300000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8658) },
                    { 4, 4, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8686), 1000000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8687) },
                    { 5, 5, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8690), 700000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8690) },
                    { 6, 6, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8693), 700000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8694) },
                    { 7, 7, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8696), 700000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8697) },
                    { 8, 8, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8699), 700000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8700) },
                    { 9, 9, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8702), 700000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8703) },
                    { 10, 10, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8705), 500000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8706) },
                    { 11, 11, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8708), 500000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8709) },
                    { 12, 12, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8711), 500000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8712) },
                    { 13, 13, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8714), 20000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8715) },
                    { 14, 14, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8717), 100000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8717) },
                    { 15, 15, new DateTime(2023, 11, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8719), 500000L, new DateTime(2023, 12, 12, 16, 15, 54, 12, DateTimeKind.Local).AddTicks(8720) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BoothProductId", "CreatedAt", "CustomerId", "DeletedAt", "Description", "IsDeleted", "ModifiedAt", "Satisfaction", "Status" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(894), 2, null, "عالی واقعا راضی بودم از همین برا دمکنی و دستگیره استفاده میکنم", false, null, (byte)2, 1 },
                    { 2, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(900), 2, null, "عالی", false, null, (byte)5, 1 },
                    { 3, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(902), 3, null, "بد بود", false, null, (byte)1, 1 },
                    { 4, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(904), 3, null, "راضی بودم ولی خاک تو سرشون با بسته بندیشون", false, null, (byte)4, 1 },
                    { 5, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(906), 2, null, "دوسش داشتم", false, null, (byte)5, 1 },
                    { 6, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(908), 2, null, "برا بابام کادو گرفتم هنوز ندیده که بگم خوبه یا بد", false, null, (byte)3, 1 },
                    { 7, 15, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(909), 3, null, "بدک نبود", false, null, (byte)3, 1 },
                    { 8, 1, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(911), 3, null, "خیلی خوب دمتون گرم", false, null, (byte)5, 1 },
                    { 9, 1, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(913), 2, null, "مضخرف", false, null, (byte)2, 1 },
                    { 10, 1, new DateTime(2023, 11, 12, 16, 15, 54, 13, DateTimeKind.Local).AddTicks(914), 2, null, "یه هفتس خریدم به دستم نرسیده", false, null, (byte)2, 1 }
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
                    { 1, 15, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7179), 2, null, false, null, 1, 1 },
                    { 2, 15, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7183), 2, null, false, null, 2, 1 },
                    { 3, 15, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7184), 2, null, false, null, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductSalerPics",
                columns: new[] { "Id", "BoothProductId", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "PictureId", "Status" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7481), null, false, null, 4, 1 },
                    { 2, 15, new DateTime(2023, 11, 12, 16, 15, 54, 261, DateTimeKind.Local).AddTicks(7484), null, false, null, 5, 1 }
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
                name: "IX_Actions_BoothId",
                table: "Actions",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ProductId",
                table: "Actions",
                column: "ProductId");

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
                name: "Actions");

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
                name: "SalerTypes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
