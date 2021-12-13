using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_Opportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunities",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Probability = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OpportunityStageId = table.Column<int>(type: "int", nullable: true),
                    LeadSourceId = table.Column<int>(type: "int", nullable: true),
                    OpportunityTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunities_LeadSources_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalSchema: "web",
                        principalTable: "LeadSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_OpportunityStages_OpportunityStageId",
                        column: x => x.OpportunityStageId,
                        principalSchema: "web",
                        principalTable: "OpportunityStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_OpportunityTypes_OpportunityTypeId",
                        column: x => x.OpportunityTypeId,
                        principalSchema: "web",
                        principalTable: "OpportunityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_LeadSourceId",
                schema: "web",
                table: "Opportunities",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_OpportunityStageId",
                schema: "web",
                table: "Opportunities",
                column: "OpportunityStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_OpportunityTypeId",
                schema: "web",
                table: "Opportunities",
                column: "OpportunityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunities",
                schema: "web");
        }
    }
}
