using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedSpecializtaionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Psychiatry(Mental, Emotional or Behavioral Disorders)" },
                    { 2, "Dentistry(Teeth)" },
                    { 3, "Pediatrics and New Born(Child)" },
                    { 4, "Orthopedics(Bones)" },
                    { 5, "Genecology and Infertility" },
                    { 6, "Ear, Nose and Throat" },
                    { 7, "Andrology and Male Infertility" },
                    { 8, "Allergy and Immunology(Sensitivity and Immunity)" },
                    { 9, "Cardiology and Vascular Disease(Heart)" },
                    { 10, "Audiology" },
                    { 11, "Cardiology and Thoracic Surgery(Heart & Chest)" },
                    { 12, "Chest and Respiratory" },
                    { 13, "Dietitian and Nutrition" },
                    { 14, "Diagnostic Radiology(Scan Centers)" },
                    { 15, "Diabetes and Endocrinology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
