using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_Customer_LeadSource_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadSourceId",
                schema: "dbo",
                table: "Customer",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LeadSourceId",
                schema: "dbo",
                table: "Customer",
                column: "LeadSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_LeadSources_LeadSourceId",
                schema: "dbo",
                table: "Customer",
                column: "LeadSourceId",
                principalSchema: "web",
                principalTable: "LeadSources",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_LeadSources_LeadSourceId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_LeadSourceId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LeadSourceId",
                schema: "dbo",
                table: "Customer");
        }
    }
}
