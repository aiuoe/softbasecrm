using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class CurrencyTypes_schema_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyDate",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.RenameColumn(
                name: "ChangedBy",
                schema: "web",
                table: "CurrencyTypes",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "AddedBy",
                schema: "web",
                table: "CurrencyTypes",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "web",
                table: "CurrencyTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrencyMessage",
                schema: "web",
                table: "CurrencyTypes",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DecimalVerbage",
                schema: "web",
                table: "CurrencyTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExchangeAccount",
                schema: "web",
                table: "CurrencyTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "web",
                table: "CurrencyTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WholeVerbage",
                schema: "web",
                table: "CurrencyTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.DropColumn(
                name: "CurrencyMessage",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.DropColumn(
                name: "DecimalVerbage",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.DropColumn(
                name: "ExchangeAccount",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.DropColumn(
                name: "WholeVerbage",
                schema: "web",
                table: "CurrencyTypes");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "web",
                table: "CurrencyTypes",
                newName: "ChangedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "web",
                table: "CurrencyTypes",
                newName: "AddedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrencyDate",
                schema: "web",
                table: "CurrencyTypes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
