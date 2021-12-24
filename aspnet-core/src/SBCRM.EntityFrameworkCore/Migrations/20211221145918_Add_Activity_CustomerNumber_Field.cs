using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_Activity_CustomerNumber_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                schema: "web",
                table: "Activities",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CustomerNumber",
                schema: "web",
                table: "Activities",
                column: "CustomerNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Customer_CustomerNumber",
                schema: "web",
                table: "Activities",
                column: "CustomerNumber",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Customer_CustomerNumber",
                schema: "web",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CustomerNumber",
                schema: "web",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                schema: "web",
                table: "Activities");
        }
    }
}
