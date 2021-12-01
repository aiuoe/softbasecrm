using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SBCRM.Migrations
{
    public partial class AspNetZero_V4_1_Changes : Migration
    {
        private readonly IDbContextSchema _schema;
        public AspNetZero_V4_1_Changes()
        {
            _schema = new DbContextSchema(SBCRMConsts.DefaultSchemaName);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                schema: _schema.Schema,
                name: "FK_AbpRoleClaims_AbpRoles_UserId",
                table: "AbpRoleClaims");

            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpRoleClaims_UserId",
                table: "AbpRoleClaims");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "UserId",
                table: "AbpRoleClaims");

            migrationBuilder.AddColumn<bool>(
                schema: _schema.Schema,
                name: "IsInTrialPeriod",
                table: "AbpTenants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                schema: _schema.Schema,
                name: "SubscriptionEndDateUtc",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "SignInToken",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                schema: _schema.Schema,
                name: "SignInTokenExpireTimeUtc",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                schema: _schema.Schema,
                name: "IsDisabled",
                table: "AbpLanguages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>( 
                schema: _schema.Schema,
                name: "Discriminator",
                table: "AbpEditions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                schema: _schema.Schema,
                name: "AnnualPrice",
                table: "AbpEditions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "ExpiringEditionId",
                table: "AbpEditions",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                schema: _schema.Schema,
                name: "MonthlyPrice",
                table: "AbpEditions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "TrialDayCount",
                table: "AbpEditions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "WaitingDayAfterExpire",
                table: "AbpEditions",
                nullable: true);

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AbpPersistedGrants",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPersistedGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                schema: _schema.Schema,
                name: "AppSubscriptionPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DayCount = table.Column<int>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EditionId = table.Column<int>(nullable: false),
                    Gateway = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PaymentId = table.Column<string>(nullable: true),
                    PaymentPeriodType = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubscriptionPayments", x => x.Id);
                });

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpTenants_CreationTime",
                table: "AbpTenants",
                column: "CreationTime");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpTenants_SubscriptionEndDateUtc",
                table: "AbpTenants",
                column: "SubscriptionEndDateUtc");

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpPersistedGrants_SubjectId_ClientId_Type",
                table: "AbpPersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_PaymentId_Gateway",
                table: "AppSubscriptionPayments",
                columns: new[] { "PaymentId", "Gateway" });

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AppSubscriptionPayments_Status_CreationTime",
                table: "AppSubscriptionPayments",
                columns: new[] { "Status", "CreationTime" });

            migrationBuilder.AddForeignKey(
             schema: _schema.Schema,
                name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId",
                principalTable: "AbpRoles",
                principalSchema: _schema.Schema,
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("UPDATE "+ _schema.Schema + ".AbpEditions SET Discriminator = 'SubscribableEdition'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                schema: _schema.Schema,
                name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                table: "AbpRoleClaims");

             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AbpPersistedGrants");

             migrationBuilder.DropTable(
                schema: _schema.Schema,
                name: "AppSubscriptionPayments");

            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpTenants_CreationTime",
                table: "AbpTenants");

            migrationBuilder.DropIndex(
                schema: _schema.Schema,
                name: "IX_AbpTenants_SubscriptionEndDateUtc",
                table: "AbpTenants");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "IsInTrialPeriod",
                table: "AbpTenants");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "SubscriptionEndDateUtc",
                table: "AbpTenants");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "SignInToken",
                table: "AbpUsers");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "SignInTokenExpireTimeUtc",
                table: "AbpUsers");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "IsDisabled",
                table: "AbpLanguages");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "Discriminator",
                table: "AbpEditions");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "AnnualPrice",
                table: "AbpEditions");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "ExpiringEditionId",
                table: "AbpEditions");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "MonthlyPrice",
                table: "AbpEditions");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "TrialDayCount",
                table: "AbpEditions");

             migrationBuilder.DropColumn(
                schema: _schema.Schema,
                name: "WaitingDayAfterExpire",
                table: "AbpEditions");

            migrationBuilder.AddColumn<int>(
                schema: _schema.Schema,
                name: "UserId",
                table: "AbpRoleClaims",
                nullable: true);

             migrationBuilder.CreateIndex(
                schema: _schema.Schema,
                name: "IX_AbpRoleClaims_UserId",
                table: "AbpRoleClaims",
                column: "UserId");

            migrationBuilder.AddForeignKey(
             schema: _schema.Schema,
                name: "FK_AbpRoleClaims_AbpRoles_UserId",
                table: "AbpRoleClaims",
                column: "UserId",
                principalTable: "AbpRoles",
             principalSchema: _schema.Schema,
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
