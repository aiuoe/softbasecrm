using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_Abp_6_3 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_Abp_6_3(IDbContextSchema schema)
        public Upgraded_To_Abp_6_3()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "PropertyName",
                table: "AbpDynamicProperties",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "EntityFullName",
                table: "AbpDynamicEntityProperties",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "ExceptionMessage",
                table: "AbpAuditLogs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ExceptionMessage",
                table: "AbpAuditLogs");

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "PropertyName",
                table: "AbpDynamicProperties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "EntityFullName",
                table: "AbpDynamicEntityProperties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
