using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SBCRM.Migrations
{
    public partial class Invoice_Changes : Migration
    {
        private readonly IDbContextSchema _schema;
        
        public Invoice_Changes()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "InvoiceNo",
                table: "AppSubscriptionPayments",
                nullable: true);

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AppInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoiceNo = table.Column<string>(nullable: true),
                    TenantAddress = table.Column<string>(nullable: true),
                    TenantLegalName = table.Column<string>(nullable: true),
                    TenantTaxNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AppInvoices");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "InvoiceNo",
                table: "AppSubscriptionPayments");
        }
    }
}
