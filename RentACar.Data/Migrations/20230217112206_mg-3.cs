using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACar.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("42111ac1-bdbd-4b6d-b3a0-25bfd9723784"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c45fab66-02dc-4252-891b-12ad514cba48"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                column: "ConcurrencyStamp",
                value: "34276ba7-aafd-4ec1-a792-ccfd1c7013f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                column: "ConcurrencyStamp",
                value: "90cf02d5-ed1e-46ae-99a9-8650b216b5d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                column: "ConcurrencyStamp",
                value: "29d8936b-e75c-4fd2-94ce-4d7419d6d9e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d759faf2-e36f-4c27-9a19-7f02cf61cd25", "AQAAAAEAACcQAAAAEA0miThFNtm3G1KBnhmq8VhQ6UtOZWGAUcnhUwiZvbRGrv5vIZ4aqtRWzhWUiXh1Zg==", "73a145f9-fe2f-44a5-accc-75d19684ae8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe5f0d3d-4ee0-456d-b3a8-7a90de670fad", "AQAAAAEAACcQAAAAEIbKao1JRTBnm16xdyc2XfCiV9WHqrzTVSF+IX8fX+9CccOoBeo36Gr8zUr+8KzvNQ==", "c5d09d4f-368b-45ce-a512-7302ae0c11c0" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "CreatedBy", "CreatedDate", "DeletedTime", "Description", "FuelType", "ImageId", "IsDeleted", "IsDeletedBy", "Kilometer", "Model", "Price", "ProductionYear", "RentCount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("15acb035-ce1d-40f2-b523-bade8c7c6fb9"), null, new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"), new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6505), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Benzin", null, false, null, 62511, "A3", 850.0, 2018, 3, null, null },
                    { new Guid("6510a532-f18e-438b-84ff-44a465610235"), null, new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"), new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6496), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Dizel", null, false, null, 50545, "E250", 600.0, 2015, 10, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6627), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6732), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("15acb035-ce1d-40f2-b523-bade8c7c6fb9"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6510a532-f18e-438b-84ff-44a465610235"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                column: "ConcurrencyStamp",
                value: "c62e0a7e-39d6-40a6-b333-26268c4179d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                column: "ConcurrencyStamp",
                value: "14d245d5-8dbb-45ee-9838-35fbb386dc36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                column: "ConcurrencyStamp",
                value: "b564697b-acdd-40b9-8ef9-ebe18da39f0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dc2ade6-acbe-44cb-8540-4b4de70dc38e", "AQAAAAEAACcQAAAAEBrzEbEn/kMq7X0rIOReGZeJKYQ2ce9C1pdMPiucXKlqlLM64wOFWb3BifiEW6irrA==", "525943d3-8526-4c1e-8946-26230e9bc2d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6ca2567-955e-4c75-bb53-f5e57c5f2434", "AQAAAAEAACcQAAAAEIqoySrRcbBUzC1LUsNG4iKqfiPKWUzGrA1b/IQprW/p5vvnY0jQRs2i5HOLFRRuEA==", "555957d8-4946-4c0f-9d04-9ef72245ae21" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AppUserId", "BrandId", "CategoryId", "CreatedBy", "CreatedDate", "DeletedTime", "Description", "FuelType", "ImageId", "IsDeleted", "IsDeletedBy", "Kilometer", "Model", "Price", "ProductionYear", "RentCount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("42111ac1-bdbd-4b6d-b3a0-25bfd9723784"), null, new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"), new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8724), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Benzin", null, false, null, 62511, "A3", 850.0, 2018, 3, null, null },
                    { new Guid("c45fab66-02dc-4252-891b-12ad514cba48"), null, new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"), new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"), "Admin Test", new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 3, 0, 0, 0)), null, "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.", "Dizel", null, false, null, 50545, "E250", 600.0, 2015, 10, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8821), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8922), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 2, 14, 0, 49, 24, 343, DateTimeKind.Unspecified).AddTicks(8914), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
