using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestState = table.Column<int>(type: "int", nullable: false),
                    AppointmentTimeId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountCodeCouponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AppointmentTimes_AppointmentTimeId",
                        column: x => x.AppointmentTimeId,
                        principalTable: "AppointmentTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId",
                        column: x => x.DiscountCodeCouponId,
                        principalTable: "DiscountCodeCoupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppointmentTimeId",
                table: "Bookings",
                column: "AppointmentTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DiscountCodeCouponId",
                table: "Bookings",
                column: "DiscountCodeCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DoctorId",
                table: "Bookings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PatientId1",
                table: "Bookings",
                column: "PatientId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentTimeId = table.Column<int>(type: "int", nullable: false),
                    DiscountCodeCouponId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    RequestState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AppointmentTimes_AppointmentTimeId",
                        column: x => x.AppointmentTimeId,
                        principalTable: "AppointmentTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_DiscountCodeCoupons_DiscountCodeCouponId",
                        column: x => x.DiscountCodeCouponId,
                        principalTable: "DiscountCodeCoupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AppointmentTimeId",
                table: "Requests",
                column: "AppointmentTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DiscountCodeCouponId",
                table: "Requests",
                column: "DiscountCodeCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DoctorId",
                table: "Requests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PatientId1",
                table: "Requests",
                column: "PatientId1");
        }
    }
}
