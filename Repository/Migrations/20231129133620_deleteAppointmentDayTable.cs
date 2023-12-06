using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class deleteAppointmentDayTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTimes_AppointmentDayOfWeek_AppointmentDayId",
                table: "AppointmentTimes");

            migrationBuilder.DropTable(
                name: "AppointmentDayOfWeek");

            migrationBuilder.RenameColumn(
                name: "AppointmentDayId",
                table: "AppointmentTimes",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentTimes_AppointmentDayId",
                table: "AppointmentTimes",
                newName: "IX_AppointmentTimes_AppointmentId");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTimes_Appointments_AppointmentId",
                table: "AppointmentTimes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTimes_Appointments_AppointmentId",
                table: "AppointmentTimes");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppointmentTimes",
                newName: "AppointmentDayId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentTimes_AppointmentId",
                table: "AppointmentTimes",
                newName: "IX_AppointmentTimes_AppointmentDayId");

            migrationBuilder.CreateTable(
                name: "AppointmentDayOfWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDayOfWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDayOfWeek_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c283ec8-df90-4908-b01e-c5cc5099ec35", "7bce69f0-80a3-49b6-98e9-5df0f80bfdac", "Patient", null },
                    { "1ecf267f-b8a1-4cfc-b8bb-3eb1c1912a80", "1cb7ea9d-3009-4283-8e26-3ffc26a1d3cf", "Admin", null },
                    { "50ef1de1-e0b3-48ff-a921-e49f166d66a6", "df21cde2-4823-49ce-a0a3-877fcc35453d", "Doctor", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b5ddabce-3811-4c2d-a53f-c3b302eb823c", 0, "785ecdf4-a6f7-43a3-8699-b3d59b23f3d0", new DateTime(2001, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, 1, null, false, null, null, null, "AQAAAAIAAYagAAAAELoqsB/KvzqzyB1PGpVNlx8GdoPKhrWKEo2LqNCXnnaUKDzgo6K4C6/bwF0Syd+49g==", "1234567890", false, "f69f20bf-a466-46ae-9926-baef746903dc", false, "Admin Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDayOfWeek_AppointmentId",
                table: "AppointmentDayOfWeek",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTimes_AppointmentDayOfWeek_AppointmentDayId",
                table: "AppointmentTimes",
                column: "AppointmentDayId",
                principalTable: "AppointmentDayOfWeek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
