using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_Abp_v4_2_0 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_Abp_v4_2_0(IDbContextSchema schema)
        public Upgraded_To_Abp_v4_2_0()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "LastLoginTime",
                table: "AbpUsers");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "LastLoginTime",
                table: "AbpUserAccounts");

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "ReturnValue",
                table: "AbpAuditLogs",
                nullable: true);

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id);
                });

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AbpOrganizationUnitRoles");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ReturnValue",
                table: "AbpAuditLogs");

            migrationBuilder.AddColumn<DateTime>(
                schema: _schema.Schema,
                name: "LastLoginTime",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                schema: _schema.Schema,
                name: "LastLoginTime",
                table: "AbpUserAccounts",
                nullable: true);
        }
    }
}
