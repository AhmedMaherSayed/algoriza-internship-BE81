using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class setPriceForTheSpecificAppointmentDayNotDoctorIngeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTimes_Appointments_AppointmentId",
                table: "AppointmentTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AppointmentTimes_AppointmentTimeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_PatientId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PatientId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorUserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentTimeId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "AppointmentTimes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PatientId",
                table: "Bookings",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTimes_Appointments_AppointmentId",
                table: "AppointmentTimes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AppointmentTimes_AppointmentTimeId",
                table: "Bookings",
                column: "AppointmentTimeId",
                principalTable: "AppointmentTimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_PatientId",
                table: "Bookings",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors",
                column: "DoctorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTimes_Appointments_AppointmentId",
                table: "AppointmentTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AppointmentTimes_AppointmentTimeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_PatientId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PatientId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorUserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentTimeId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "AppointmentTimes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PatientId1",
                table: "Bookings",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTimes_Appointments_AppointmentId",
                table: "AppointmentTimes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AppointmentTimes_AppointmentTimeId",
                table: "Bookings",
                column: "AppointmentTimeId",
                principalTable: "AppointmentTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_PatientId1",
                table: "Bookings",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_DoctorUserId",
                table: "Doctors",
                column: "DoctorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
