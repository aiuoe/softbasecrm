using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_Customer_Navigation_Property_To_CustomerAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                schema: "web",
                table: "CustomerAttachments",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttachments_CustomerNumber",
                schema: "web",
                table: "CustomerAttachments",
                column: "CustomerNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAttachments_Customer_CustomerNumber",
                schema: "web",
                table: "CustomerAttachments",
                column: "CustomerNumber",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAttachments_Customer_CustomerNumber",
                schema: "web",
                table: "CustomerAttachments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAttachments_CustomerNumber",
                schema: "web",
                table: "CustomerAttachments");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                schema: "web",
                table: "CustomerAttachments");
        }
    }
}
