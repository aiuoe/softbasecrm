using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SBCRM.Migrations
{
    public partial class AddEditionPaymentTypeToSubscriptionPayment : Migration
    {
        private readonly IDbContextSchema _schema;

        //public AddEditionPaymentTypeToSubscriptionPayment(IDbContextSchema schema)
        public AddEditionPaymentTypeToSubscriptionPayment()
        {
            //_schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "EditionPaymentType",
                table: "AppSubscriptionPayments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "EditionPaymentType",
                table: "AppSubscriptionPayments");
        }
    }
}
