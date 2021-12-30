using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Regenerated_ActivitySourceType1279 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumValue",
                schema: "web",
                table: "ActivitySourceTypes");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "web",
                table: "ActivitySourceTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "web",
                table: "ActivitySourceTypes");

            migrationBuilder.AddColumn<int>(
                name: "EnumValue",
                schema: "web",
                table: "ActivitySourceTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
