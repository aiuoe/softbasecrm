using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Regenerated_ActivityTaskType8379 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumValue",
                schema: "web",
                table: "ActivityTaskTypes");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "web",
                table: "ActivityTaskTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "web",
                table: "ActivityTaskTypes");

            migrationBuilder.AddColumn<int>(
                name: "EnumValue",
                schema: "web",
                table: "ActivityTaskTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
