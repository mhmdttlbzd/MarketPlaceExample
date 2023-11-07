using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class addUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiredTime" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(4547), new DateTime(2023, 11, 13, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "6d7b79a7-f118-4536-98d8-669e239c0633", "AQAAAAIAAYagAAAAEBAmpYO0e9yQKN2itHlQl7IZ/6qNcBZGuqwidvUiILWQvC40eVRBqdX/LUe5rnbKjw==", "37b71016-f575-44c5-989f-993d0ff7139d", 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "ecb60f53-1d5c-4e02-af3c-dcd7e3c23fd8", "AQAAAAIAAYagAAAAENOSBZi71lQ5BCsW5jOe9ao1Gn+13F8glTVQdR1QZeKJmKyhfQ+uygGMy+/UZXqeLw==", "371350bb-a49a-43bd-a9be-93929c770c99", 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "efc073e2-665f-471c-9c7c-54192f4f3857", "AQAAAAIAAYagAAAAEA4EUxjLv5WXudvNUkv8f5RCoM6E6fNhEz6otxRkJEFDDam9e3tnquQv6WIRZSVjLg==", "0cd55188-e23d-4073-be57-88b3e7c9a968", 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "7c4aed67-1132-442c-8c82-a9439f68ccb9", "AQAAAAIAAYagAAAAEF7cV1Sv/wYQDTdOwQGliH8I6+znjeiC28ZDEzJf7BBeAyBnsyLn4T1AJRjMJs9m0A==", "b1bb6403-db2f-4e41-8963-aa4774017b25", 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "01433c61-432d-42d0-9ff8-7f66885e9813", "AQAAAAIAAYagAAAAEEKII7jgWnoKa2zrX4TKQp3TdcLytrvucyr4z6YDd0TBCgnflkk27vivwGUf4fJghg==", "64789b44-c29a-4827-bf71-c17f7ec3527f", 1 });

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5425), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5440), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5441) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5443), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5447), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5448) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5449), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5452), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5453) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5455), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5455) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5457), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5469), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5479), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5499), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5502), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5503) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5505), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5508), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5509) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5510), new DateTime(2023, 12, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 269, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "ProductCustomerPics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "ProductCustomerPics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "ProductCustomerPics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "ProductSalerPics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "ProductSalerPics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 9, 59, 17, 270, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 11, 6, 9, 59, 19, 163, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 11, 6, 9, 59, 19, 163, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 11, 6, 9, 59, 19, 163, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 11, 6, 9, 59, 19, 163, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 11, 6, 9, 59, 19, 163, DateTimeKind.Local).AddTicks(4159));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(96));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.UpdateData(
                table: " ProductsCustomAttributes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiredTime" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(3565), new DateTime(2023, 11, 10, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(3569) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0d6b731-c41d-4fb5-9f40-41f87ed797f6", "AQAAAAIAAYagAAAAEHZtFgcwphNzYcMj3DRhFBgavSH3eZYb3TeH4DMdHG6KA00VYMaiCzfeT0/zKeaE8Q==", "67403a7b-f64d-45fd-9f67-f56c9bbfb1d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76e3a35d-074b-4fb6-8263-67519387bb87", "AQAAAAIAAYagAAAAEC3If6rzEPpTyeoJgtZCQRZvpeL6pzt50CAoRY9xzG5rsvm6EKrfhcJZsihvESKj3A==", "d392c425-0b4f-4f89-8d1d-2e422f30218a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a657929d-3dd3-49a3-b0cb-ab5ed731339a", "AQAAAAIAAYagAAAAEJjMhIzKcvuVB1KnNY7KMd0tRK2k1BHpZWNyE/fcPSqUnGgKDLxJZaVWQnydHULkqQ==", "14fe6455-530a-417e-a5e4-66d0a829d01c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf0ddc74-fc2a-41b3-961f-919a55806ff6", "AQAAAAIAAYagAAAAEEPEpYBLejGMhbY6zNfOsavNEyLxtFjm3rqp4eCGNZYdPUE+R7ag0gG1rhyMCUjHig==", "3321b5d1-751e-4841-b48e-e8fe11131640" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "854f40de-53ce-49ed-8df6-48aaab2fa95f", "AQAAAAIAAYagAAAAEJvuwH+pkHGTKJ8ORwWivYgWDzYIekobiZBIzZToy3JFA/U1CuLtrY2V8ZP1bSAJ5g==", "d7e5ba93-b661-4e49-a7a8-180db7ce360f" });

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "AuctionPictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4474), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4478) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4490), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4493), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4494) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4496), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4500), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4503), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4503) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4505), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4506) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4508), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4517) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4520), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4523) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4539), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4583), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4587), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4590), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4592), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "BoothProductsPrices",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4595), new DateTime(2023, 12, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "MainAddresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "BuyedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 787, DateTimeKind.Local).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "ProductCustomerPics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "ProductCustomerPics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "ProductCustomerPics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "ProductSalerPics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "ProductSalerPics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 3, 20, 58, 39, 788, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 11, 3, 20, 58, 40, 492, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 11, 3, 20, 58, 40, 492, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 11, 3, 20, 58, 40, 492, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 11, 3, 20, 58, 40, 492, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 11, 3, 20, 58, 40, 492, DateTimeKind.Local).AddTicks(9360));
        }
    }
}
