using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_BranchFk_DepartmentFk_Fields_Opportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Dept_Branch",
                schema: "web",
                table: "Opportunities",
                columns: new[] { "Dept", "Branch" });

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Dept_Dept_Branch",
                schema: "web",
                table: "Opportunities",
                columns: new[] { "Dept", "Branch" },
                principalSchema: "dbo",
                principalTable: "Dept",
                principalColumns: new[] { "Branch", "Dept" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Dept_Dept_Branch",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_Dept_Branch",
                schema: "web",
                table: "Opportunities");
        }
    }
}
