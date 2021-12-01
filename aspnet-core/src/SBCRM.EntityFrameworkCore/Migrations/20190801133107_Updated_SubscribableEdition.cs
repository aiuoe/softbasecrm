using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Updated_SubscribableEdition : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Updated_SubscribableEdition(IDbContextSchema schema)
        public Updated_SubscribableEdition()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                schema: _schema.Schema,
                name: "DailyPrice",
                table: "AbpEditions",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                schema: _schema.Schema,
                name: "WeeklyPrice",
                table: "AbpEditions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "DailyPrice",
                table: "AbpEditions");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "WeeklyPrice",
                table: "AbpEditions");
        }
    }
}
