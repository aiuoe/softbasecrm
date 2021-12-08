using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Add_Description_To_Binary_Object : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Add_Description_To_Binary_Object(IDbContextSchema schema)
        public Add_Description_To_Binary_Object()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "Description",
                table: "AppBinaryObjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "Description",
                table: "AppBinaryObjects");
        }
    }
}
