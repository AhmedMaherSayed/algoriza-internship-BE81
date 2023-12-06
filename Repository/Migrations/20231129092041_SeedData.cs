using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3863da99-4707-437c-bc07-1ab76f66c29a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a459acb-0006-41af-a4b1-3a4780b31538");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1adda34-93c3-4966-bd05-65d9e04c680f");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08f1994e-1ba2-43e7-909b-a43bbae79846", "457c0f94-0969-468e-a586-4923cf516535", "Admin", null },
                    { "456aeb89-9687-45ba-b7d8-29a39f94c211", "26a85dab-055b-41b7-a5ab-519aac3e7592", "Patient", null },
                    { "981f7daf-7aee-4ba3-8224-1be5ca6f35a4", "abf6a566-e0fb-4396-9c34-14192debfd77", "Doctor", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e7dadc15-467f-40f9-99e2-fcd733006743", 0, "b7fba8d2-8e03-4a25-967d-20919d7b3f0b", new DateTime(2001, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, 1, null, false, null, null, null, "AK0M4Cz9Od+ti11OQExPb80qPFMmZ5VdA+QEBNsIzakFtjxgW9/0oG0kGc3QFq6rHg==", "1234567890", false, "41c0c1b8-90bb-46b3-bb05-88d790b96645", false, "Admin Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08f1994e-1ba2-43e7-909b-a43bbae79846");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "456aeb89-9687-45ba-b7d8-29a39f94c211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "981f7daf-7aee-4ba3-8224-1be5ca6f35a4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7dadc15-467f-40f9-99e2-fcd733006743");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3863da99-4707-437c-bc07-1ab76f66c29a", "322cdf3f-6b64-484a-b061-83fd20965021", "Admin", null },
                    { "6a459acb-0006-41af-a4b1-3a4780b31538", "91d98654-fec8-4d87-82ee-28bd24c03295", "Patient", null },
                    { "f1adda34-93c3-4966-bd05-65d9e04c680f", "f0f25c21-2ee0-4962-863b-25814f0362fe", "Doctor", null }
                });
        }
    }
}
