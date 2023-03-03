using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACar.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("15acb035-ce1d-40f2-b523-bade8c7c6fb9"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6510a532-f18e-438b-84ff-44a465610235"));

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Rentals");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Rentals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentInfoId",
                table: "Rentals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "PaymentInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfo", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PaymentInfoId",
                table: "Rentals",
                column: "PaymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_AspNetUsers_UserId",
                table: "Rentals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_PaymentInfo_PaymentInfoId",
                table: "Rentals",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_AspNetUsers_UserId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_PaymentInfo_PaymentInfoId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_PaymentInfoId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("76ad1c57-3dee-452d-bfb3-871c78c947d2"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("87e41ea1-9e2c-49f2-86f2-ace9cbedd921"));

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "PaymentInfoId",
                table: "Rentals");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Rentals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
        }
    }
}
