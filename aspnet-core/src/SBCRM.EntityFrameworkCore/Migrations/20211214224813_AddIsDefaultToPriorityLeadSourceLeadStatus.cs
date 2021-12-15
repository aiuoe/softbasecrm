using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class AddIsDefaultToPriorityLeadSourceLeadStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "web",
                table: "Priorities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "web",
                table: "LeadStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "web",
                table: "LeadSources",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "web",
                table: "Priorities");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "web",
                table: "LeadStatuses");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "web",
                table: "LeadSources");
        }
    }
}
