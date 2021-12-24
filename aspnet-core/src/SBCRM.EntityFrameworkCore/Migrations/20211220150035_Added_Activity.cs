using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_Activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityId = table.Column<int>(type: "int", nullable: true),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ActivitySourceTypeId = table.Column<int>(type: "int", nullable: false),
                    ActivityTaskTypeId = table.Column<int>(type: "int", nullable: false),
                    ActivityStatusId = table.Column<int>(type: "int", nullable: false),
                    ActivityPriorityId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "web",
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityPriorities_ActivityPriorityId",
                        column: x => x.ActivityPriorityId,
                        principalSchema: "web",
                        principalTable: "ActivityPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_ActivitySourceTypes_ActivitySourceTypeId",
                        column: x => x.ActivitySourceTypeId,
                        principalSchema: "web",
                        principalTable: "ActivitySourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityStatuses_ActivityStatusId",
                        column: x => x.ActivityStatusId,
                        principalSchema: "web",
                        principalTable: "ActivityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTaskTypes_ActivityTaskTypeId",
                        column: x => x.ActivityTaskTypeId,
                        principalSchema: "web",
                        principalTable: "ActivityTaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "web",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "web",
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityPriorityId",
                schema: "web",
                table: "Activities",
                column: "ActivityPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivitySourceTypeId",
                schema: "web",
                table: "Activities",
                column: "ActivitySourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityStatusId",
                schema: "web",
                table: "Activities",
                column: "ActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTaskTypeId",
                schema: "web",
                table: "Activities",
                column: "ActivityTaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LeadId",
                schema: "web",
                table: "Activities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OpportunityId",
                schema: "web",
                table: "Activities",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                schema: "web",
                table: "Activities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities",
                schema: "web");
        }
    }
}
