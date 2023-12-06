using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class create1MrelationBetweenRequestsAndAppointmentTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Requests",
                newName: "AppointmentTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AppointmentTimeId",
                table: "Requests",
                column: "AppointmentTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AppointmentTimes_AppointmentTimeId",
                table: "Requests",
                column: "AppointmentTimeId",
                principalTable: "AppointmentTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AppointmentTimes_AppointmentTimeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_AppointmentTimeId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "AppointmentTimeId",
                table: "Requests",
                newName: "Day");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
