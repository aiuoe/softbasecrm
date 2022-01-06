using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_Pre_Branch_Department_Fields_Opportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Branch",
                schema: "web",
                table: "Opportunities",
                type: "smallint",
                nullable: false);

            migrationBuilder.AddColumn<short>(
                name: "Dept",
                schema: "web",
                table: "Opportunities",
                type: "smallint",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "Dept",
                schema: "web",
                table: "Opportunities");
        }
    }
}
