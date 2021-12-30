using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Remove_Terms_And_Conditions_From_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAcceptedTermsAndConditions",
                schema: "web",
                table: "AbpUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAcceptedTermsAndConditions",
                schema: "web",
                table: "AbpUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
