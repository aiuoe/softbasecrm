using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace SBCRM.Migrations
{
    public partial class Upgrade_To_ABP_6_1 : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Upgrade_To_ABP_6_1(IDbContextSchema schema)
        public Upgrade_To_ABP_6_1()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_AbpDynamicPropertyValues", "AbpDynamicPropertyValues", schema: _schema.Schema);
             migrationBuilder.DropColumn(
                "Id", "AbpDynamicPropertyValues", schema: _schema.Schema);
            migrationBuilder.AddColumn<long>(
                    name: "Id",
                    table: "AbpDynamicPropertyValues",
                    nullable: false, schema: _schema.Schema)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpDynamicPropertyValues",
                table: "AbpDynamicPropertyValues",
                columns: new[] {"Id"}, schema: _schema.Schema);

            migrationBuilder.DropPrimaryKey("PK_AbpDynamicEntityPropertyValues", "AbpDynamicEntityPropertyValues", schema: _schema.Schema);
             migrationBuilder.DropColumn(
                "Id", "AbpDynamicEntityPropertyValues", schema: _schema.Schema);
            migrationBuilder.AddColumn<long>(
                    name: "Id",
                    table: "AbpDynamicEntityPropertyValues",
                    nullable: false, schema: _schema.Schema)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpDynamicEntityPropertyValues",
                table: "AbpDynamicEntityPropertyValues",
                schema: _schema.Schema,
                columns: new[] {"Id"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_AbpDynamicPropertyValues", "AbpDynamicPropertyValues", schema: _schema.Schema);
             migrationBuilder.DropColumn(
                "Id", "AbpDynamicPropertyValues",schema: _schema.Schema);
            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                    name: "Id",
                    table: "AbpDynamicPropertyValues",
                    nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpDynamicPropertyValues",
                table: "AbpDynamicPropertyValues",
                columns: new[] {"Id"}, schema: _schema.Schema);

            migrationBuilder.DropPrimaryKey("PK_AbpDynamicEntityPropertyValues", "AbpDynamicEntityPropertyValues");
             migrationBuilder.DropColumn(
                "Id", "AbpDynamicEntityPropertyValues", schema: _schema.Schema);
            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                    name: "Id",
                    table: "AbpDynamicEntityPropertyValues",
                    nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpDynamicEntityPropertyValues",
                table: "AbpDynamicEntityPropertyValues",
                columns: new[] {"Id"}, schema: _schema.Schema);
        }
    }
}