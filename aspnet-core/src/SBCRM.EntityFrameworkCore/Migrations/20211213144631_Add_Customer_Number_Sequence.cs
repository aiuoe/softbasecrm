using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_Customer_Number_Sequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "CustomerNumberSequence",
                schema: "web",
                startValue: 100000,
                incrementBy: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "dbo",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR Web.CustomerNumberSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "CustomerNumberSequence",
                schema: "web");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "dbo",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValueSql: "NEXT VALUE FOR Web.CustomerNumberSequence");
        }
    }
}
