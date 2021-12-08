using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_GoogleAuthenticatorKey_Column : Migration
    {
        private readonly IDbContextSchema _schema;
        
        public Added_GoogleAuthenticatorKey_Column()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "GoogleAuthenticatorKey",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "GoogleAuthenticatorKey",
                table: "AbpUsers");
        }
    }
}
