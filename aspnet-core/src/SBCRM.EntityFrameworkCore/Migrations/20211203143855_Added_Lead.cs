using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_Lead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    LeadSourceId = table.Column<int>(type: "int", nullable: true),
                    LeadStatusId = table.Column<int>(type: "int", nullable: true),
                    CustomerNumber = table.Column<string>(type: "varchar(100)", nullable: true),

                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPosition = table.Column<string>(type: "varchar(100)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "varchar(50)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "varchar(100)", nullable: true),
                    PoBox = table.Column<string>(type: "varchar(100)", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactPhone = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactPhoneExtension = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactCellPhone = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactFaxNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    PagerNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactEmail = table.Column<string>(type: "varchar(100)", nullable: true),

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
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "web",
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leads_LeadSources_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalSchema: "web",
                        principalTable: "LeadSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leads_LeadStatuses_LeadStatusId",
                        column: x => x.LeadStatusId,
                        principalSchema: "web",
                        principalTable: "LeadStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leads_Customer_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadCustomerNumber",
                schema: "web",
                table: "Leads",
                column: "CustomerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads",
                schema: "web");
        }
    }
}
