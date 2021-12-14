using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_Customer_Source_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsCreatedFromWebCrm",
                schema: "dbo",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreatedFromWebCrm",
                schema: "dbo",
                table: "Customer");
        }
    }
}
