using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class RemoveFieldsOpportunityStages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                schema: "web",
                table: "OpportunityStages");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "web",
                table: "OpportunityStages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "web",
                table: "OpportunityStages",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "web",
                table: "OpportunityStages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
