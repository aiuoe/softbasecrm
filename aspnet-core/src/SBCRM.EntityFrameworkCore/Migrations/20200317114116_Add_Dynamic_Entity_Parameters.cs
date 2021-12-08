using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Add_Dynamic_Entity_Parameters : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Add_Dynamic_Entity_Parameters(IDbContextSchema schema)
        public Add_Dynamic_Entity_Parameters()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AbpDynamicParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AbpDynamicParameterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    DynamicParameterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicParameterValues", x => x.Id);
                    table.ForeignKey(
                principalSchema: _schema.Schema,
                        name: "FK_AbpDynamicParameterValues_AbpDynamicParameters_DynamicParameterId",
                        column: x => x.DynamicParameterId,
                        principalTable: "AbpDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AbpEntityDynamicParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityFullName = table.Column<string>(nullable: true),
                    DynamicParameterId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityDynamicParameters", x => x.Id);
                    table.ForeignKey(
                principalSchema: _schema.Schema,
                        name: "FK_AbpEntityDynamicParameters_AbpDynamicParameters_DynamicParameterId",
                        column: x => x.DynamicParameterId,
                        principalTable: "AbpDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AbpEntityDynamicParameterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    EntityDynamicParameterId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityDynamicParameterValues", x => x.Id);
                    table.ForeignKey(
                principalSchema: _schema.Schema,
                        name: "FK_AbpEntityDynamicParameterValues_AbpEntityDynamicParameters_EntityDynamicParameterId",
                        column: x => x.EntityDynamicParameterId,
                        principalTable: "AbpEntityDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpDynamicParameters_ParameterName_TenantId",
                table: "AbpDynamicParameters",
                columns: new[] { "ParameterName", "TenantId" },
                unique: true,
                filter: "[ParameterName] IS NOT NULL AND [TenantId] IS NOT NULL");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpDynamicParameterValues_DynamicParameterId",
                table: "AbpDynamicParameterValues",
                column: "DynamicParameterId");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpEntityDynamicParameters_DynamicParameterId",
                table: "AbpEntityDynamicParameters",
                column: "DynamicParameterId");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpEntityDynamicParameters_EntityFullName_DynamicParameterId_TenantId",
                table: "AbpEntityDynamicParameters",
                columns: new[] { "EntityFullName", "DynamicParameterId", "TenantId" },
                unique: true,
                filter: "[EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpEntityDynamicParameterValues_EntityDynamicParameterId",
                table: "AbpEntityDynamicParameterValues",
                column: "EntityDynamicParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AbpDynamicParameterValues");

             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AbpEntityDynamicParameterValues");

             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AbpEntityDynamicParameters");

             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AbpDynamicParameters");
        }
    }
}
