using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystemAPI.Migrations.API
{
    public partial class AddedDepartmentIDinSubjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Subjects");
        }
    }
}
