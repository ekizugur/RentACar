using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACar.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("76ad1c57-3dee-452d-bfb3-871c78c947d2"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("87e41ea1-9e2c-49f2-86f2-ace9cbedd921"));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                column: "ConcurrencyStamp",
                value: "dcc61d55-761a-4f2a-9f5b-57ab55f42dde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                column: "ConcurrencyStamp",
                value: "42e86c83-80ed-49c5-b55a-4b6d986a5f83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                column: "ConcurrencyStamp",
                value: "42a59941-5d84-49cb-9ec0-a12b45b3a83c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b0b4fc1-7a99-4187-b00f-735315ac5b33", "AQAAAAEAACcQAAAAEGE69ISBeh8bLbtGc+7Et82nsDgbHjXLneQZFiAKPWtPSoXYsQfaqaD3wTveMpHQMw==", "9235be5d-63f0-4837-a7e3-b1b7352a48d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4838951-c810-488a-b16d-368a443f54a5", "AQAAAAEAACcQAAAAEL1yIiaEX4Rka1OHMeSkBznpC2rTlcmWegx20vy0t8jr5+UDFBKUQbJmIaMBRRcm/Q==", "d7afadc8-30a5-445b-97a3-0203cc9ff471" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "CreatedBy", "CreatedDate", "DeletedTime", "Description", "FuelType", "ImageId", "IsDeleted", "IsDeletedBy", "Kilometer", "Model", "Price", "ProductionYear", "RentCount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("47b58545-8535-4be8-9a44-7bfde556b20c"), null, new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"), new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Dizel", null, false, null, 50545, "E250", 600m, 2015, 10, null, null },
                    { new Guid("d20154ef-2de9-496e-b131-17601b27bb6b"), null, new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"), new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Benzin", null, false, null, 62511, "A3", 850m, 2018, 3, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6731), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6931), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 21, 9, 9, 574, DateTimeKind.Unspecified).AddTicks(6921), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("47b58545-8535-4be8-9a44-7bfde556b20c"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("d20154ef-2de9-496e-b131-17601b27bb6b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "Rentals",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                column: "ConcurrencyStamp",
                value: "e97e6363-ad6d-48ab-971a-47968583becc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                column: "ConcurrencyStamp",
                value: "8819fdba-f356-43ef-b80b-ab3fcee86be5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                column: "ConcurrencyStamp",
                value: "59b6aab6-3112-4cb7-9716-f898f0272c1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7eaac02-dada-4b08-92c5-20ee8a405f27", "AQAAAAEAACcQAAAAELVaJsXv3UYHXZk5eRxTuiGzSLhjA9Og8efliLvDu1ruHQwiWmaype/cbs5wxfUDzQ==", "95a63c22-29f7-4db5-bdc6-29b488573abc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de59a6e6-b634-4378-8f1d-1a7809dfd6f5", "AQAAAAEAACcQAAAAEOyV0Vwe4HZ1wtQ/7UGnIDTQWGtOJ9S9wQ2Mg7BTPGsojJSpj9qH8aWovPQXLtb7Mw==", "ef2b0b48-68c5-439c-84ad-91af4c096f90" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "CreatedBy", "CreatedDate", "DeletedTime", "Description", "FuelType", "ImageId", "IsDeleted", "IsDeletedBy", "Kilometer", "Model", "Price", "ProductionYear", "RentCount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("76ad1c57-3dee-452d-bfb3-871c78c947d2"), null, new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"), new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2604), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Dizel", null, false, null, 50545, "E250", 600m, 2015, 10, null, null },
                    { new Guid("87e41ea1-9e2c-49f2-86f2-ace9cbedd921"), null, new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"), new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2644), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Benzin", null, false, null, 62511, "A3", 850m, 2018, 3, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2770), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2928), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 22, 1, 53, 59, 780, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
