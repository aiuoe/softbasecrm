using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_Abp_V2_2 : Migration
    {
        private readonly IDbContextSchema _schema;
        public Upgraded_To_Abp_V2_2()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                schema: _schema.Schema,
                name: "IsDeleted",
                table: "AbpUserOrganizationUnits",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "IsDeleted",
                table: "AbpUserOrganizationUnits");
        }
    }
}
