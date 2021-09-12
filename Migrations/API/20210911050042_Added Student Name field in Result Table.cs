using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystemAPI.Migrations.API
{
    public partial class AddedStudentNamefieldinResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Results");
        }
    }
}
