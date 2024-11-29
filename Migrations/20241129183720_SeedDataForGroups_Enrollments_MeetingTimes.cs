using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace study_center_ef.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForGroups_Enrollments_MeetingTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ MeetingTimes_Groups_MeetingTimeID",
                table: " MeetingTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ MeetingTimes",
                table: " MeetingTimes");

            migrationBuilder.RenameTable(
                name: " MeetingTimes",
                newName: "MeetingTimes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Enrollments",
                type: "DateTime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "Enrollments",
                type: "DateTime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingTimes",
                table: "MeetingTimes",
                column: "MeetingTimeID");

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "TeacherSubjectID", "GradeLevelSubjectID", "IsActive", "TeacherID" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 2, true, 2 },
                    { 3, 3, false, 3 },
                    { 4, 4, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "ClassID", "CreationDate", "GradeLevelSubjectID", "GroupName", "GroupStudentCount", "IsActive", "MeetingTimeID", "TeacherSubjectID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 29, 19, 52, 1, 0, DateTimeKind.Unspecified), 1, "Math Morning Group", 20, true, 1, 1 },
                    { 2, 2, new DateTime(2024, 4, 29, 19, 52, 1, 0, DateTimeKind.Unspecified), 2, "Science Evening Group", 25, true, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentID", "DeletionDate", "EnrollmentDate", "GroupID", "IsActive", "StudentID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 29, 20, 37, 18, 873, DateTimeKind.Local).AddTicks(8281), 1, true, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 29, 20, 37, 18, 876, DateTimeKind.Local).AddTicks(2634), 2, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "MeetingTimes",
                columns: new[] { "MeetingTimeID", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 8, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingTimes_Groups_MeetingTimeID",
                table: "MeetingTimes",
                column: "MeetingTimeID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingTimes_Groups_MeetingTimeID",
                table: "MeetingTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingTimes",
                table: "MeetingTimes");

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MeetingTimes",
                keyColumn: "MeetingTimeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MeetingTimes",
                keyColumn: "MeetingTimeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumn: "TeacherSubjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumn: "TeacherSubjectID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumn: "TeacherSubjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumn: "TeacherSubjectID",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "MeetingTimes",
                newName: " MeetingTimes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Enrollments",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "Enrollments",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ MeetingTimes",
                table: " MeetingTimes",
                column: "MeetingTimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ MeetingTimes_Groups_MeetingTimeID",
                table: " MeetingTimes",
                column: "MeetingTimeID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
