using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class AddTermsAndConditionsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "HasAcceptedTermsAndConditions",
                schema: "web",
                table: "AbpUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "HasAcceptedTermsAndConditions",
                schema: "web",
                table: "AbpUsers");

        }
    }
}
