using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class changeBookingMinimumRequestName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinimumRequiredRequests",
                table: "DiscountCodeCoupons",
                newName: "MinimumRequiredBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinimumRequiredBookings",
                table: "DiscountCodeCoupons",
                newName: "MinimumRequiredRequests");
        }
    }
}
