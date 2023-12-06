using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addForiegnAttribut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorUserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors",
                column: "DoctorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorUserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors",
                column: "DoctorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
