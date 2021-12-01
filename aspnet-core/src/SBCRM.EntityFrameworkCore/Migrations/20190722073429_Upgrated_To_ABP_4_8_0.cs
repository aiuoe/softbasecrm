using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Upgrated_To_ABP_4_8_0 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgrated_To_ABP_4_8_0(IDbContextSchema schema)
        public Upgrated_To_ABP_4_8_0()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpSettings_TenantId_Name",
                table: "AbpSettings");

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "LanguageName",
                table: "AbpLanguageTexts",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Name",
                table: "AbpLanguages",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpSettings_TenantId_Name_UserId",
                table: "AbpSettings",
                columns: new[] { "TenantId", "Name", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpSettings_TenantId_Name_UserId",
                table: "AbpSettings");

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "LanguageName",
                table: "AbpLanguageTexts",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "Name",
                table: "AbpLanguages",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpSettings_TenantId_Name",
                table: "AbpSettings",
                columns: new[] { "TenantId", "Name" });
        }
    }
}
