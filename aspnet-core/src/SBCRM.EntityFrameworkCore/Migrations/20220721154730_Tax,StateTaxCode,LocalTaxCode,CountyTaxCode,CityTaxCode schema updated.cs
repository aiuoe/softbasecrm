using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class TaxStateTaxCodeLocalTaxCodeCountyTaxCodeCityTaxCodeschemaupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "CustomerOverride",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Quebec",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "CityTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "CityTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "CityTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "CityTaxCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "CityTaxCodes",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "CountyTaxCodes");

            migrationBuilder.DropColumn(
                name: "LaborNonTaxable",
                schema: "web",
                table: "CountyTaxCodes");

            migrationBuilder.DropColumn(
                name: "MiscNonTaxable",
                schema: "web",
                table: "CountyTaxCodes");

            migrationBuilder.DropColumn(
                name: "PartsNonTaxable",
                schema: "web",
                table: "CountyTaxCodes");

            migrationBuilder.DropColumn(
                name: "RentalNonTaxable",
                schema: "web",
                table: "CountyTaxCodes");

            migrationBuilder.DropColumn(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "CityTaxCodes");

            migrationBuilder.DropColumn(
                name: "LaborNonTaxable",
                schema: "web",
                table: "CityTaxCodes");

            migrationBuilder.DropColumn(
                name: "MiscNonTaxable",
                schema: "web",
                table: "CityTaxCodes");

            migrationBuilder.DropColumn(
                name: "PartsNonTaxable",
                schema: "web",
                table: "CityTaxCodes");

            migrationBuilder.DropColumn(
                name: "RentalNonTaxable",
                schema: "web",
                table: "CityTaxCodes");

            migrationBuilder.AlterColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CustomerOverride",
                schema: "web",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "StateTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RentalNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PartsNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MiscNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LaborNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EquipmentNonTaxable",
                schema: "web",
                table: "LocalTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Quebec",
                schema: "web",
                table: "CountyTaxCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
