using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_PersonId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Patients_PatientId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PatientId",
                table: "Requests");

            
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7dadc15-467f-40f9-99e2-fcd733006743");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Doctors",
                newName: "DoctorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                newName: "IX_Doctors_DoctorUserId");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountCodeCouponId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PatientId1",
                table: "Requests",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors",
                column: "DoctorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_PatientId1",
                table: "Requests",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Requests",
                column: "DiscountCodeCouponId",
                principalTable: "DiscountCodeCoupons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_PatientId1",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PatientId1",
                table: "Requests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c283ec8-df90-4908-b01e-c5cc5099ec35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ecf267f-b8a1-4cfc-b8bb-3eb1c1912a80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50ef1de1-e0b3-48ff-a921-e49f166d66a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5ddabce-3811-4c2d-a53f-c3b302eb823c");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "DoctorUserId",
                table: "Doctors",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_DoctorUserId",
                table: "Doctors",
                newName: "IX_Doctors_PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountCodeCouponId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PatientId",
                table: "Requests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PersonId",
                table: "Patients",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_PersonId",
                table: "Doctors",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Requests",
                column: "DiscountCodeCouponId",
                principalTable: "DiscountCodeCoupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Patients_PatientId",
                table: "Requests",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
