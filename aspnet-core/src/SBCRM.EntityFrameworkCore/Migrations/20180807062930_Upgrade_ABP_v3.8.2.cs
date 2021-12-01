using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Upgrade_ABP_v382 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgrade_ABP_v382(IDbContextSchema schema)
        public Upgrade_ABP_v382()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                schema: _schema.Schema,
                name: "ExpireDate",
                table: "AbpUserTokens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ExpireDate",
                table: "AbpUserTokens");
        }
    }
}
