using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Added_User_OrganizationUnits : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Added_User_OrganizationUnits(IDbContextSchema schema)
        public Added_User_OrganizationUnits()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpUserOrganizationUnits_UserId",
                table: "AbpUserOrganizationUnits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
             schema: _schema.Schema,
                name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                table: "AbpUserOrganizationUnits",
                column: "UserId",
                principalTable: "AbpUsers",
             principalSchema: _schema.Schema,
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                schema: _schema.Schema,
                name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                table: "AbpUserOrganizationUnits");

            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpUserOrganizationUnits_UserId",
                table: "AbpUserOrganizationUnits");
        }
    }
}
