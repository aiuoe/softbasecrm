using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Added_Relation_Between_Edition_And_SubscriptionPayment : Migration
    {
        private readonly IDbContextSchema _schema;

        public Added_Relation_Between_Edition_And_SubscriptionPayment()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_EditionId",
                table: "AppSubscriptionPayments",
                column: "EditionId");

            migrationBuilder.AddForeignKey(
             schema: _schema.Schema,
                name: "FK_AppSubscriptionPayments_AbpEditions_EditionId",
                table: "AppSubscriptionPayments",
                column: "EditionId",
                principalTable: "AbpEditions",
                principalSchema: _schema.Schema,
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                schema: _schema.Schema,
                name: "FK_AppSubscriptionPayments_AbpEditions_EditionId",
                table: "AppSubscriptionPayments");

            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_EditionId",
                table: "AppSubscriptionPayments");
        }
    }
}
