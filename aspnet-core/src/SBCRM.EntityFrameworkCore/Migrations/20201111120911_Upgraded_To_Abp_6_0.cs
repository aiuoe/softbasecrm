using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_Abp_6_0 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_Abp_6_0(IDbContextSchema schema)
        public Upgraded_To_Abp_6_0()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "NewValueHash",
                table: "AbpEntityPropertyChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "OriginalValueHash",
                table: "AbpEntityPropertyChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "DisplayName",
                table: "AbpDynamicProperties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "NewValueHash",
                table: "AbpEntityPropertyChanges");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "OriginalValueHash",
                table: "AbpEntityPropertyChanges");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "DisplayName",
                table: "AbpDynamicProperties");
        }
    }
}
