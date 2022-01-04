using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Update_Activity_Change_UserId_to_Optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AbpUsers_UserId",
                schema: "web",
                table: "Activities");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "web",
                table: "Activities",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AbpUsers_UserId",
                schema: "web",
                table: "Activities",
                column: "UserId",
                principalSchema: "web",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AbpUsers_UserId",
                schema: "web",
                table: "Activities");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "web",
                table: "Activities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AbpUsers_UserId",
                schema: "web",
                table: "Activities",
                column: "UserId",
                principalSchema: "web",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
