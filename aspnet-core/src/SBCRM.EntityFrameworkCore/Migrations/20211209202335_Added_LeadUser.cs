using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_LeadUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.CreateTable(
                name: "LeadUsers",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_LeadUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadUsers_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "web",
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadUsers_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "web",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadUsers_LeadId",
                schema: "web",
                table: "LeadUsers",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadUsers_UserId",
                schema: "web",
                table: "LeadUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.DropTable(
                name: "LeadUsers",
                schema: "web");
        }
    }
}
