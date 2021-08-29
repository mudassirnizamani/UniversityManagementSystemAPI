using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystemAPI.Migrations.API
{
    public partial class AddedMoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentStudents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSubjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyDepartments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyDepartments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentStudents");

            migrationBuilder.DropTable(
                name: "DepartmentSubjects");

            migrationBuilder.DropTable(
                name: "FacultyDepartments");
        }
    }
}
