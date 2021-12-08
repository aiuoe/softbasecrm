using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SBCRM.Migrations
{
    public partial class TypeChange_SharedMessageId_String_Guid : Migration
    {
        private readonly IDbContextSchema _schema;

        //public TypeChange_SharedMessageId_String_Guid(IDbContextSchema schema)
        public TypeChange_SharedMessageId_String_Guid()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                schema: _schema.Schema,
                name: "SharedMessageId",
                table: "AppChatMessages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "SharedMessageId",
                table: "AppChatMessages",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
