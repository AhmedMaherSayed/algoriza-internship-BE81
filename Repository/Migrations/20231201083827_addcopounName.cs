using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addcopounName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DiscountCodeCoupons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeCoupons_Name",
                table: "DiscountCodeCoupons",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiscountCodeCoupons_Name",
                table: "DiscountCodeCoupons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DiscountCodeCoupons");
        }
    }
}
