using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBCRMDemo.Migrations
{
    public partial class Upgraded_To_Abp_7_3_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TargetNotifiers",
                schema: "web",
                table: "AbpUserNotifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetNotifiers",
                schema: "web",
                table: "AbpNotifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetNotifiers",
                schema: "web",
                table: "AbpUserNotifications");

            migrationBuilder.DropColumn(
                name: "TargetNotifiers",
                schema: "web",
                table: "AbpNotifications");
        }
    }
}
