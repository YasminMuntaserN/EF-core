using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace study_center_ef.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "Capacity", "ClassName", "Description" },
                values: new object[,]
                {
                    { 1, (byte)30, "Math-101", "Intro to Algebra" },
                    { 2, (byte)25, "Sci-102", "Basic Chemistry" },
                    { 3, (byte)20, "Eng-201", "Advanced Grammar" },
                    { 4, (byte)15, "Hist-301", "World History" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassID",
                keyValue: 4);
        }
    }
}
