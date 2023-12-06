using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class MovePriceFromAppointmentToDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
