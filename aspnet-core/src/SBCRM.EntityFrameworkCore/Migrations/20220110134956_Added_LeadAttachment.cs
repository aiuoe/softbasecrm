using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_LeadAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Dept_Dept_Branch",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_Dept_Branch",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.CreateTable(
                name: "LeadAttachments",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadAttachments_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "web",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Branch_Dept",
                schema: "web",
                table: "Opportunities",
                columns: new[] { "Branch", "Dept" });

            migrationBuilder.CreateIndex(
                name: "IX_LeadAttachments_LeadId",
                schema: "web",
                table: "LeadAttachments",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dept_Branch_Branch",
                schema: "dbo",
                table: "Dept",
                column: "Branch",
                principalSchema: "dbo",
                principalTable: "Branch",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Dept_Branch_Dept",
                schema: "web",
                table: "Opportunities",
                columns: new[] { "Branch", "Dept" },
                principalSchema: "dbo",
                principalTable: "Dept",
                principalColumns: new[] { "Branch", "Dept" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dept_Branch_Branch",
                schema: "dbo",
                table: "Dept");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Dept_Branch_Dept",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.DropTable(
                name: "LeadAttachments",
                schema: "web");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_Branch_Dept",
                schema: "web",
                table: "Opportunities");

            migrationBuilder.AddColumn<short>(
                name: "DepartmentId",
                schema: "web",
                table: "Opportunities",
                type: "smallint",
                nullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
