using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACar.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("846dcfa6-03af-46a1-aeda-abc295d2a5a1"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ed9eae93-50d8-41b4-a75e-da96c3a823e1"));

            migrationBuilder.AddColumn<bool>(
                name: "RefundRequest",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                column: "ConcurrencyStamp",
                value: "8598037c-6fe4-4d0d-8c55-d2093a29bd3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                column: "ConcurrencyStamp",
                value: "779ce0b2-bc78-446f-8be0-6d2eaf1bee7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                column: "ConcurrencyStamp",
                value: "76936fd7-88d1-496a-84d0-1e2581c54eb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5df20af7-4dbf-4ba8-8399-27357a28d3c6", "AQAAAAEAACcQAAAAEKHs3tK9GLJwzdT3HgL5DDU/4gbarxV76s5l7fqvJT8y9Qnepmimd+oq86FXsCJeXA==", "95667d78-b861-4d17-9724-7ee5b3368a45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ead76d-964f-4676-88e1-7c0e7acf6b5d", "AQAAAAEAACcQAAAAEGfFWFkq30XHgi7z4NVV4lGxBr/VbWoSP1aAKKmAJbjpB1ZlPC+HvjfQIouUqqp2Tg==", "bab2a58f-8be9-4f36-b8cf-e193f88f70a4" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 626, DateTimeKind.Unspecified).AddTicks(9968), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 626, DateTimeKind.Unspecified).AddTicks(9978), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "CreatedBy", "CreatedDate", "DeletedTime", "Description", "FuelType", "ImageId", "IsDeleted", "IsDeletedBy", "Kilometer", "Model", "Price", "ProductionYear", "RentCount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7d685412-6ee3-4daf-913c-303729377214"), null, new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"), new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"), "Admin Test", new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 627, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Dizel", null, false, null, 50545, "E250", 600m, 2015, 10, null, null },
                    { new Guid("e2b48a45-e19e-49c5-891a-b06bf8db1bb5"), null, new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"), new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"), "Admin Test", new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 627, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Benzin", null, false, null, 62511, "A3", 850m, 2018, 3, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 627, DateTimeKind.Unspecified).AddTicks(350), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 627, DateTimeKind.Unspecified).AddTicks(355), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 627, DateTimeKind.Unspecified).AddTicks(465), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 3, 2, 19, 0, 0, 627, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7d685412-6ee3-4daf-913c-303729377214"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e2b48a45-e19e-49c5-891a-b06bf8db1bb5"));

            migrationBuilder.DropColumn(
                name: "RefundRequest",
                table: "Rentals");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                column: "ConcurrencyStamp",
                value: "8da12b0f-009f-4963-b5e6-b4d8012a8f29");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                column: "ConcurrencyStamp",
                value: "3dd39498-2b5c-4a6c-a7e6-8702b4cb6e3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                column: "ConcurrencyStamp",
                value: "b4006db4-ca21-42ac-abf6-be12fb173dc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "584fcc78-2409-410a-ac1a-ce62c8376eb9", "AQAAAAEAACcQAAAAEEiarkhZ9xk0Z2DZpuDSBm7N0TkEBDQRcUmc28xI++8j75HUFJfBmZPicT+loLaOqg==", "8f32076c-abf7-44bd-9f63-dfe38af20cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4daceb-88a4-480b-8193-736eb8d04711", "AQAAAAEAACcQAAAAEKs/HTgVlcUykiLBhbfLhVfcLFAvhpTBP8iwz/VC+/LWl5/GnCea0MnOg2EbFxArkw==", "d4535db3-b5ff-4cde-8091-a2fa222da085" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2045), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "CreatedBy", "CreatedDate", "DeletedTime", "Description", "FuelType", "ImageId", "IsDeleted", "IsDeletedBy", "Kilometer", "Model", "Price", "ProductionYear", "RentCount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("846dcfa6-03af-46a1-aeda-abc295d2a5a1"), null, new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"), new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Dizel", null, false, null, 50545, "E250", 600m, 2015, 10, null, null },
                    { new Guid("ed9eae93-50d8-41b4-a75e-da96c3a823e1"), null, new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"), new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2284), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Benzin", null, false, null, 62511, "A3", 850m, 2018, 3, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2511), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 25, 2, 29, 22, 402, DateTimeKind.Unspecified).AddTicks(2506), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
