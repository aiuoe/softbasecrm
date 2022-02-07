using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Opportunity_Nullable_LeadSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeadSourceId",
                schema: "web",
                table: "Opportunities",
                type: "int",
                nullable: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeadSourceId",
                schema: "web",
                table: "Opportunities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
