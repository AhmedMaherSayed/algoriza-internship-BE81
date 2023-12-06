using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "AppointmentTimes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_PatientId",
                table: "Bookings",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Bookings",
                column: "DiscountCodeCouponId",
                principalTable: "DiscountCodeCoupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "AppointmentTimes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId",
                table: "Bookings",
                column: "DiscountCodeCouponId",
                principalTable: "DiscountCodeCoupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
