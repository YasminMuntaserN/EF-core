using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace study_center_ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    DateOfBirth = table.Column<DateTime>(type: "DateTime2", nullable: false),
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
                    SubjectName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    GradeLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_GradeLevels_GradeLevelId",
                        column: x => x.GradeLevelId,
                        principalTable: "GradeLevels",
                        principalColumn: "GradeLevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    GradeLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_GradeLevels_GradeLevelID",
                        column: x => x.GradeLevelID,
                        principalTable: "GradeLevels",
                        principalColumn: "GradeLevelID",
                        onDelete: ReferentialAction.Cascade);
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
                    HireDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
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
                        principalColumn: "GradeLevelID");
                    table.ForeignKey(
                        name: "FK_GradeLevelSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    GradeLevelSubjectID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => x.TeacherSubjectID);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_GradeLevelSubjects_GradeLevelSubjectID",
                        column: x => x.GradeLevelSubjectID,
                        principalTable: "GradeLevelSubjects",
                        principalColumn: "GradeLevelSubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
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
                    TeacherSubjectID = table.Column<int>(type: "int", nullable: false),
                    GroupStudentCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MeetingTimeID = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Groups_GradeLevelSubjects_GradeLevelSubjectID",
                        column: x => x.GradeLevelSubjectID,
                        principalTable: "GradeLevelSubjects",
                        principalColumn: "GradeLevelSubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_TeacherSubjects_TeacherSubjectID",
                        column: x => x.TeacherSubjectID,
                        principalTable: "TeacherSubjects",
                        principalColumn: "TeacherSubjectID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: " MeetingTimes",
                columns: table => new
                {
                    MeetingTimeID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ MeetingTimes", x => x.MeetingTimeID);
                    table.ForeignKey(
                        name: "FK_ MeetingTimes_Groups_MeetingTimeID",
                        column: x => x.MeetingTimeID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GroupID",
                table: "Enrollments",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

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
                name: "IX_Groups_GradeLevelSubjectID",
                table: "Groups",
                column: "GradeLevelSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherSubjectID",
                table: "Groups",
                column: "TeacherSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GroupID",
                table: "Payments",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentID",
                table: "Payments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeLevelID",
                table: "Students",
                column: "GradeLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonID",
                table: "Students",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GradeLevelId",
                table: "Subjects",
                column: "GradeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PersonID",
                table: "Teachers",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_GradeLevelSubjectID",
                table: "TeacherSubjects",
                column: "GradeLevelSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_TeacherID",
                table: "TeacherSubjects",
                column: "TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " MeetingTimes");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "GradeLevelSubjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "GradeLevels");
        }
    }
}
