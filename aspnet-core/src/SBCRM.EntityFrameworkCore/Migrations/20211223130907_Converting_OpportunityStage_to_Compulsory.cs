using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Converting_OpportunityStage_to_Compulsory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Opportunities_OpportunityStageId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.AlterColumn<int>(
                name: "OpportunityStageId",
                schema: "web",
                table: "Opportunities",
                type: "int",
                nullable: false);              

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_OpportunityStageId",
                schema: "web",
                table: "Opportunities",
                column: "OpportunityStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
              migrationBuilder.AlterColumn<int>(
                name: "OpportunityStageId",
                schema: "web",
                table: "Opportunities",
                type: "int",
                nullable: false,                
                oldNullable: true);

        }
    }
}
