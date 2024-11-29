using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace study_center_ef.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForPeople_Teachers_Students : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, "123 Elm Street, Springfield", new DateTime(1990, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@email.com", "John", (byte)1, "Doe", "123-456-7890", "Michael", "David" },
                    { 2, "456 Oak Avenue, Springfield", new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@email.com", "Jane", (byte)2, "Smith", "987-654-3210", "Maria", "Ann" },
                    { 3, "789 Pine Road, Springfield", new DateTime(1988, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark.johnson@email.com", "Mark", (byte)1, "Johnson", "555-123-4567", "William", "Edward" },
                    { 4, "101 Maple Drive, Springfield", new DateTime(2000, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucy.green@email.com", "Lucy", (byte)2, "Green", "555-987-6543", "Alice", "Marie" },
                    { 5, "202 Birch Lane, Springfield", new DateTime(1992, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tom.taylor@email.com", "Tom", (byte)1, "Taylor", "321-654-9870", "Richard", "Henry" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "GradeLevelID", "PersonID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherID", "HireDate", "PersonID", "Qualification", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MSc in Mathematics", 50000m },
                    { 2, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "MSc in Physics", 55000m },
                    { 3, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "BA in English Literature", 45000m },
                    { 4, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "PhD in History", 60000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: 4);
        }
    }
}
