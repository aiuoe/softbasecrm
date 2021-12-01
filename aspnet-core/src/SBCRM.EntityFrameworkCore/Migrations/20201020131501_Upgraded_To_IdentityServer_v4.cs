using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Upgraded_To_IdentityServer_v4 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgraded_To_IdentityServer_v4(IDbContextSchema schema)
        public Upgraded_To_IdentityServer_v4()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                schema: _schema.Schema,
                name: "ConsumedTime",
                table: "AbpPersistedGrants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "Description",
                table: "AbpPersistedGrants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "SessionId",
                table: "AbpPersistedGrants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpPersistedGrants_Expiration",
                table: "AbpPersistedGrants",
                column: "Expiration");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpPersistedGrants_SubjectId_SessionId_Type",
                table: "AbpPersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpPersistedGrants_Expiration",
                table: "AbpPersistedGrants");

            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpPersistedGrants_SubjectId_SessionId_Type",
                table: "AbpPersistedGrants");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ConsumedTime",
                table: "AbpPersistedGrants");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "Description",
                table: "AbpPersistedGrants");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "SessionId",
                table: "AbpPersistedGrants");
        }
    }
}
