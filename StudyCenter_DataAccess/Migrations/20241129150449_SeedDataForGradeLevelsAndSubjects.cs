using Microsoft.EntityFrameworkCore.Migrations;
using study_center_ef.Entities;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace study_center_ef.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForGradeLevelsAndSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GradeLevels",
                columns: new[] { "GradeLevelID", "GradeLevelName" },
                values: new object[,]
                {
                    { 1, "6th Grade" },
                    { 2, "7th Grade" },
                    { 3, "8th Grade" },
                    { 4, "9th Grade" }
                });


            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID","GradeLevelId", "SubjectName" },
                values: new object[,]
                {
                    { 1,1, "Mathematics" },
                    { 2,2 ,"Science" },
                    { 3, 3,"English" },
                    { 4,4, "History" },
                });


            migrationBuilder.InsertData(
                table: "GradeLevelSubjects",
                columns: new[] { "GradeLevelSubjectID", "Fees", "GradeLevelID", "SubjectID", "Title" },
                values: new object[,]
                {
                                            { 1, 100, 1, 1, "6th Grade - Mathematics" },
                                            { 2, 120, 2, 2, "7th Grade - Science" },
                                            { 3, 110, 3, 3, "8th Grade - English" },
                                            { 4, 130, 4, 4, "9th Grade - History" }
                });
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "GradeLevels",
               keyColumn: "GradeLevelID",
               keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "GradeLevelID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "GradeLevelID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "GradeLevelID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GradeLevelSubjects",
                keyColumn: "GradeLevelSubjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GradeLevelSubjects",
                keyColumn: "GradeLevelSubjectID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GradeLevelSubjects",
                keyColumn: "GradeLevelSubjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GradeLevelSubjects",
                keyColumn: "GradeLevelSubjectID",
                keyValue: 4);
        }
    }
}
