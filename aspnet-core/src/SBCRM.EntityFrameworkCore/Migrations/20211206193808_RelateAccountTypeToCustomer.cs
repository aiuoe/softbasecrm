using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class RelateAccountTypeToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                schema: "dbo",
                table: "Customer",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountTypeId",
                schema: "dbo",
                table: "Customer",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AccountTypes_AccountTypeId",
                schema: "dbo",
                table: "Customer",
                column: "AccountTypeId",
                principalSchema: "web",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AccountTypes_AccountTypeId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AccountTypeId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                schema: "dbo",
                table: "Customer");
        }
    }
}
