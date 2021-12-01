using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_Abp_6_4_0 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_Abp_6_4_0(IDbContextSchema schema)
        public Upgraded_To_Abp_6_4_0()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpUserLogins_ProviderKey_TenantId",
                table: "AbpUserLogins",
                columns: new[] { "ProviderKey", "TenantId" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpUserLogins_ProviderKey_TenantId",
                table: "AbpUserLogins");
        }
    }
}
