using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Update_Branch_And_Dept_On_Opportunity : Migration
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

            migrationBuilder.AddColumn<short>(
                name: "BranchId",
                schema: "web",
                table: "Opportunities",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DepartmentId",
                schema: "web",
                table: "Opportunities",
                type: "smallint",
                nullable: true);

            //migrationBuilder.AddPrimaryKey("PK_Dept", "Dept", "Dept", "dbo");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_BranchId",
                schema: "web",
                table: "Opportunities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_DepartmentId",
                schema: "web",
                table: "Opportunities",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Branch_BranchId",
                schema: "web",
                table: "Opportunities",
                column: "BranchId",
                principalSchema: "dbo",
                principalTable: "Branch",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Dept_DepartmentId",
                schema: "web",
                table: "Opportunities",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Dept",
                principalColumn: "Dept",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Branch_BranchId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Dept_DepartmentId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Dept",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_BranchId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_DepartmentId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                schema: "web",
                table: "Opportunities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "web",
                table: "Opportunities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
