using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Persons_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Departments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolPeriods",
                columns: table => new
                {
                    SchoolPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPeriods", x => x.SchoolPeriodId);
                    table.ForeignKey(
                        name: "FK_SchoolPeriods_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolPeriodCourses",
                columns: table => new
                {
                    SchoolPeriodCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolPeriodId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPeriodCourses", x => x.SchoolPeriodCourseId);
                    table.ForeignKey(
                        name: "FK_SchoolPeriodCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolPeriodCourses_SchoolPeriods_SchoolPeriodId",
                        column: x => x.SchoolPeriodId,
                        principalTable: "SchoolPeriods",
                        principalColumn: "SchoolPeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SchoolPeriodCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.SchoolPeriodCourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudents_Persons_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudents_SchoolPeriodCourses_SchoolPeriodCourseId",
                        column: x => x.SchoolPeriodCourseId,
                        principalTable: "SchoolPeriodCourses",
                        principalColumn: "SchoolPeriodCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SchoolPeriodCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeachers", x => new { x.SchoolPeriodCourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_CourseTeachers_Persons_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeachers_SchoolPeriodCourses_SchoolPeriodCourseId",
                        column: x => x.SchoolPeriodCourseId,
                        principalTable: "SchoolPeriodCourses",
                        principalColumn: "SchoolPeriodCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Email", "Lastname", "Name", "PersonType" },
                values: new object[,]
                {
                    { 1, "Kim.Abercrombie@email.com", "Abercrombie", "Kim", 0 },
                    { 2, "Gytis.Barzdukas@email.com", "Barzdukas", "Gytis", 0 },
                    { 3, "Peggy.Justice@email.com", "Justice", "Peggy", 2 },
                    { 4, "Fadi.Fakhouri@email.com", "Fakhouri", "Fadi", 2 },
                    { 5, "Roger.Harui@email.com", "Harui", "Roger", 2 },
                    { 6, "Yan.Li@email.com", "Li", "Yan", 2 },
                    { 7, "Laura.Norman@email.com", "Norman", "Laura", 2 },
                    { 8, "Nino.Olivotto@email.com", "Olivotto", "Nino", 1 },
                    { 9, "Daniel.Tang@email.com", "Tang", "Daniel", 1 },
                    { 10, "Alonso.Meredith@email.com", "Meredith", "Alonso", 1 }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "CountryCode", "Name" },
                values: new object[,]
                {
                    { 1, "-", "US", "School 1" },
                    { 2, "-", "DE", "Schule 2" },
                    { 3, "-", "PE", "Escuela 1" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "AdministratorId", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 1, 1, "Economics", 1 },
                    { 2, 2, "English", 1 },
                    { 3, 2, "History", 1 },
                    { 4, 1, "Engineering", 1 }
                });

            migrationBuilder.InsertData(
                table: "SchoolPeriods",
                columns: new[] { "SchoolPeriodId", "Period", "SchoolId" },
                values: new object[,]
                {
                    { 1, "2020", 1 },
                    { 2, "2021", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Economic 1" },
                    { 2, 1, "Economic 2" },
                    { 3, 1, "Economic 3" },
                    { 4, 1, "Economic 4" },
                    { 5, 2, "Gramar 1" },
                    { 6, 2, "Oral expression1" },
                    { 7, 2, "Reading 1" },
                    { 8, 2, "Reading 2" },
                    { 9, 3, "National History 1" },
                    { 10, 3, "National history 2" },
                    { 11, 3, "Greek Mythology History 1" },
                    { 12, 3, "Nordic Mythology History 2" },
                    { 13, 4, "Computer Programming 1" },
                    { 14, 4, "Databases 1" }
                });

            migrationBuilder.InsertData(
                table: "SchoolPeriodCourses",
                columns: new[] { "SchoolPeriodCourseId", "CourseId", "Credits", "SchoolPeriodId" },
                values: new object[,]
                {
                    { 1, 1, 3, 2 },
                    { 15, 1, 5, 1 },
                    { 2, 2, 4, 2 },
                    { 3, 3, 4, 2 },
                    { 4, 4, 5, 2 },
                    { 5, 5, 5, 2 },
                    { 6, 6, 3, 2 },
                    { 7, 7, 3, 2 },
                    { 8, 8, 3, 2 },
                    { 9, 9, 4, 2 },
                    { 10, 10, 4, 2 },
                    { 11, 11, 4, 2 },
                    { 12, 12, 5, 2 },
                    { 13, 13, 5, 2 },
                    { 14, 14, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "SchoolPeriodCourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 5 },
                    { 4, 4 },
                    { 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "CourseTeachers",
                columns: new[] { "SchoolPeriodCourseId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 10 },
                    { 7, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeachers_TeacherId",
                table: "CourseTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AdministratorId",
                table: "Departments",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SchoolId",
                table: "Departments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPeriodCourses_CourseId",
                table: "SchoolPeriodCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPeriodCourses_SchoolPeriodId",
                table: "SchoolPeriodCourses",
                column: "SchoolPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPeriods_SchoolId",
                table: "SchoolPeriods",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "CourseTeachers");

            migrationBuilder.DropTable(
                name: "SchoolPeriodCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SchoolPeriods");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
