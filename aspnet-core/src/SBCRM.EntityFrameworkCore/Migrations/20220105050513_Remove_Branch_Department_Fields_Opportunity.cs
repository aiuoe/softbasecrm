using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Remove_Branch_Department_Fields_Opportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "Department",
                schema: "web",
                table: "Opportunities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Branch",
                schema: "web",
                table: "Opportunities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Department",
                schema: "web",
                table: "Opportunities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
