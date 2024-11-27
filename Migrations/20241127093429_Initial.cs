using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace study_center_ef.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<byte>(type: "TINYINT", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "GradeLevels",
                columns: table => new
                {
                    GradeLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeLevelName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeLevels", x => x.GradeLevelID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ThirdName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<byte>(type: "TINYINT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DateTime", nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    GradeLevelSubjectID = table.Column<int>(type: "int", nullable: false),
                    GroupStudentCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_Groups_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Qualification = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK_Teachers_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradeLevelSubjects",
                columns: table => new
                {
                    GradeLevelSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    GradeLevelID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Fees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeLevelSubjects", x => x.GradeLevelSubjectID);
                    table.ForeignKey(
                        name: "FK_GradeLevelSubjects_GradeLevels_GradeLevelID",
                        column: x => x.GradeLevelID,
                        principalTable: "GradeLevels",
                        principalColumn: "GradeLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeLevelSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "SubjectID", "SubjectName" },
                values: new object[,]
                {
                    { 1, "Mathematics" },
                    { 2, "Science" },
                    { 3, "English" },
                    { 4, "History" },
                    { 5, "Geography" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeLevelSubjects_GradeLevelID",
                table: "GradeLevelSubjects",
                column: "GradeLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeLevelSubjects_SubjectID",
                table: "GradeLevelSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ClassID",
                table: "Groups",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonID",
                table: "Students",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PersonID",
                table: "Teachers",
                column: "PersonID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeLevelSubjects");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "GradeLevels");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
