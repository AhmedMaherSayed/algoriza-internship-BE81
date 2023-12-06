using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "Gender", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c19937ea-edbe-4ce5-90a2-8e48ada52a60", 0, "030cb112-8710-4a56-940b-0d087ddd85b8", new DateTime(2001, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, "Admin Admin", 1, null, false, null, "ADMIN@GMAIL.COM", "c19937ea-edbe-4ce5-90a2-8e48ada52a60", "AQAAAAIAAYagAAAAEAbTVwWtzUrW7kOd8duy/nV1TTDonwx1nXDcSINXLG7YAY1Xmu5WcohX0RrSFDiMfQ==", "123456", false, "8ff32591-ef68-4316-b31b-ab6aeda737e1", false, "c19937ea-edbe-4ce5-90a2-8e48ada52a60" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "09066f40-d9df-493a-91be-b82e71f8353a", "c19937ea-edbe-4ce5-90a2-8e48ada52a60" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2553eda-413b-4e99-a7fc-a3ca40222cc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cef07a16-e4a5-453e-bc81-0d195fedd872");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09066f40-d9df-493a-91be-b82e71f8353a", "c19937ea-edbe-4ce5-90a2-8e48ada52a60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09066f40-d9df-493a-91be-b82e71f8353a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c19937ea-edbe-4ce5-90a2-8e48ada52a60");
        }
    }
}
