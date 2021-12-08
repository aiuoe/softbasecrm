using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class Recurring_Payment_Changes : Migration
    {
        private readonly IDbContextSchema _schema;

        //public Recurring_Payment_Changes(IDbContextSchema schema)
        public Recurring_Payment_Changes()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_PaymentId_Gateway",
                table: "AppSubscriptionPayments");

            migrationBuilder.RenameColumn(
                schema: _schema.Schema,
                name: "PaymentId",
                table: "AppSubscriptionPayments",
                newName: "SuccessUrl");

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "SuccessUrl",
                table: "AppSubscriptionPayments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "Description",
                table: "AppSubscriptionPayments",
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "ErrorUrl",
                table: "AppSubscriptionPayments",
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "ExternalPaymentId",
                table: "AppSubscriptionPayments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                schema: _schema.Schema,
                name: "IsRecurring",
                table: "AppSubscriptionPayments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "SubscriptionPaymentType",
                table: "AbpTenants",
                nullable: false,
                defaultValue: 0);

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_ExternalPaymentId_Gateway",
                table: "AppSubscriptionPayments",
                columns: new[] { "ExternalPaymentId", "Gateway" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_ExternalPaymentId_Gateway",
                table: "AppSubscriptionPayments");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "Description",
                table: "AppSubscriptionPayments");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ErrorUrl",
                table: "AppSubscriptionPayments");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ExternalPaymentId",
                table: "AppSubscriptionPayments");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "IsRecurring",
                table: "AppSubscriptionPayments");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "SubscriptionPaymentType",
                table: "AbpTenants");

            migrationBuilder.RenameColumn(
                schema: _schema.Schema,
                name: "SuccessUrl",
                table: "AppSubscriptionPayments",
                newName: "PaymentId");

             migrationBuilder.AlterColumn<string>(
                schema: _schema.Schema,
                name: "PaymentId",
                table: "AppSubscriptionPayments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_PaymentId_Gateway",
                table: "AppSubscriptionPayments",
                columns: new[] { "PaymentId", "Gateway" });
        }
    }
}
