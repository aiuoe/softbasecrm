using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_Abp_V3_5 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_Abp_V3_5(IDbContextSchema schema)
        public Upgraded_To_Abp_V3_5()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Value",
                table: "AbpUserTokens",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Name",
                table: "AbpUserTokens",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "LoginProvider",
                table: "AbpUserTokens",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "SecurityStamp",
                table: "AbpUsers",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "PhoneNumber",
                table: "AbpUsers",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Value",
                table: "AbpUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Name",
                table: "AbpUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "LoginProvider",
                table: "AbpUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "SecurityStamp",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "PhoneNumber",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
