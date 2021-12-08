using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_ABP_5_1 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_ABP_5_1(IDbContextSchema schema)
        public Upgraded_To_ABP_5_1()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "UserNameOrEmailAddress",
                table: "AbpUserLoginAttempts",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Value",
                table: "AbpSettings",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "UserNameOrEmailAddress",
                table: "AbpUserLoginAttempts",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Value",
                table: "AbpSettings",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
