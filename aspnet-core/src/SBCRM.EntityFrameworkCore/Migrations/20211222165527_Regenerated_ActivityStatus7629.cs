using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Regenerated_ActivityStatus7629 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompletedStatus",
                schema: "web",
                table: "ActivityStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompletedStatus",
                schema: "web",
                table: "ActivityStatuses");
        }
    }
}
