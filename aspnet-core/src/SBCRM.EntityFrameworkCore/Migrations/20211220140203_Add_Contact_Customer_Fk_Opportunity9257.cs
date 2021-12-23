using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Regenerated_Opportunity9257 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                schema: "web",
                table: "Opportunities",
                type: "int",
                nullable: false,
                defaultValue: null);
            migrationBuilder.AddColumn<int>(
                name: "CustomerNumber",
                schema: "web",
                table: "Opportunities",
                type: "varchar(100)",
                nullable: false,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_ContactId",
                schema: "web",
                table: "Opportunities",
                column: "ContactId");
            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CustomerNumber",
                schema: "web",
                table: "Opportunities",
                column: "CustomerNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Contact_ContactId",
                schema: "web",
                table: "Opportunities",
                column: "ContactId",
                principalSchema: "dbo",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Customer_CustomerNumber",
                schema: "web",
                table: "Opportunities",
                column: "CustomerNumber",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Contact_ContactId",
                schema: "web",
                table: "Opportunities");
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Customer_CustomerNumber",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Opportunity_ContactId",
                schema: "web",
                table: "Opportunities");
            migrationBuilder.DropIndex(
                name: "IX_Opportunity_CustomerNumber",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "ContactId",
                schema: "web",
                table: "Opportunities");
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                schema: "web",
                table: "Opportunities");

        }
    }
}
