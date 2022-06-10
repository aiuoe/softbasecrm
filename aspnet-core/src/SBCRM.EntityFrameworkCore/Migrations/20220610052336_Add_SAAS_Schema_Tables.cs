using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBCRM.Migrations
{
    public partial class Add_SAAS_Schema_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalCharges",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    Dept = table.Column<int>(type: "int", nullable: false),
                    MiscDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MiscPercentage = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscSaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountLimit = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborOnly = table.Column<bool>(type: "bit", nullable: true),
                    PartsOnly = table.Column<bool>(type: "bit", nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    AmountMin = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalCharges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminDeletedRecords",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Branch = table.Column<int>(type: "int", nullable: true),
                    Dept = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RemovedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDeletedRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdTrack",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdTrack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdTrackDef",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TargetMarket = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TargetMarketSize = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EstimatedSales = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EstimatedHits = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdTrackDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advance",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allianz",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allianz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryFlag = table.Column<bool>(type: "bit", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorNo = table.Column<int>(type: "int", nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CheckNo = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    APInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Authorizedby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuthorizedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Holdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountTaken = table.Column<bool>(type: "bit", nullable: true),
                    PONo = table.Column<int>(type: "int", nullable: true),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MEConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MEDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PMEConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PMEDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SalesTaxAccount = table.Column<int>(type: "int", nullable: true),
                    SalesTaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ApplyToAPInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    TrinDocsID = table.Column<int>(type: "int", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APPaymentType",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APRepeat",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OriginalAPInvoiceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalRepeats = table.Column<short>(type: "smallint", nullable: true),
                    CurrentCount = table.Column<short>(type: "smallint", nullable: true),
                    FrequencyMethod = table.Column<short>(type: "smallint", nullable: true),
                    Frequency = table.Column<short>(type: "smallint", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Added = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APRepeat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APRepeatDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ControlNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Added = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APRepeatDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APVoucher",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posted = table.Column<bool>(type: "bit", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PONo = table.Column<int>(type: "int", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoldOnPost = table.Column<bool>(type: "bit", nullable: true),
                    Reoccurring = table.Column<bool>(type: "bit", nullable: true),
                    TotalRepeats = table.Column<short>(type: "smallint", nullable: true),
                    FrequencyMethod = table.Column<short>(type: "smallint", nullable: true),
                    Frequency = table.Column<short>(type: "smallint", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CheckNo = table.Column<int>(type: "int", nullable: true),
                    CashAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WriteCheckFlag = table.Column<bool>(type: "bit", nullable: true),
                    ApplyToAPInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WriteCCFlag = table.Column<int>(type: "int", nullable: true),
                    CCVendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CCAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APVoucher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APVoucherDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VoucherEntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxFlag = table.Column<bool>(type: "bit", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APVoucherDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ARDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryFlag = table.Column<bool>(type: "bit", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplyToInvoiceNo = table.Column<int>(type: "int", nullable: false),
                    EntryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Due = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CheckNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dispute = table.Column<bool>(type: "bit", nullable: true),
                    DisputeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvoiceRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentPromiseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MEConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MEDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PMEConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PMEDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SalesTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesTaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerSelected = table.Column<bool>(type: "bit", nullable: true),
                    ExcludeCredit = table.Column<bool>(type: "bit", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ariens",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ObsoleteCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackageQty = table.Column<short>(type: "smallint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ariens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ARImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceNo = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    ProcessedParts = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedLabor = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedComments = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedCSS = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedPartsBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessedLaborBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessedCommentsBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessedCSSBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncludeWithInvoice = table.Column<bool>(type: "bit", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ARImagesDeleted",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceNo = table.Column<long>(type: "bigint", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    ProcessedParts = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedLabor = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedComments = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedCSS = table.Column<bool>(type: "bit", nullable: true),
                    ProcessedPartsBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessedLaborBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessedCommentsBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessedCSSBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARImagesDeleted", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ARTerms",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    COD = table.Column<short>(type: "smallint", nullable: true),
                    DaysDue = table.Column<short>(type: "smallint", nullable: true),
                    Days = table.Column<short>(type: "smallint", nullable: true),
                    DayOfMonth = table.Column<short>(type: "smallint", nullable: true),
                    Day = table.Column<short>(type: "smallint", nullable: true),
                    PrintWaterMark = table.Column<short>(type: "smallint", nullable: true),
                    CreditCard = table.Column<bool>(type: "bit", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barrett",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitsOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PriceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QtyBreak1 = table.Column<int>(type: "int", nullable: true),
                    QtyBreak2 = table.Column<int>(type: "int", nullable: true),
                    QtyBreak3 = table.Column<int>(type: "int", nullable: true),
                    QtyBreak4 = table.Column<int>(type: "int", nullable: true),
                    QtyBreak5 = table.Column<int>(type: "int", nullable: true),
                    PriceBreak1 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceBreak2 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceBreak3 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceBreak4 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceBreak5 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartNoReplaces = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnFlag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrett", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BebQuotes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BEBQuoteNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Probability = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<short>(type: "smallint", nullable: true),
                    Models = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    QuoteLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QuickLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExpiresDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BebQuotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BigJoe",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigJoe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bobcat",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Markup = table.Column<short>(type: "smallint", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NonReturn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncDec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SellMultiple = table.Column<int>(type: "int", nullable: true),
                    QtyBreak = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HCPCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnershipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipDirectOnly = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InactivePart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bobcat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boss",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Receivable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinanceCharge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinanceRate = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    FinanceDays = table.Column<short>(type: "smallint", nullable: true),
                    StateTaxLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyTaxLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShowSplitSalesTax = table.Column<bool>(type: "bit", nullable: true),
                    CityTaxLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalTaxLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClarkPartsCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClarkDealerAccessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseStateTaxCodeDescription = table.Column<bool>(type: "bit", nullable: true),
                    UseCountyTaxCodeDescription = table.Column<bool>(type: "bit", nullable: true),
                    UseCityTaxCodeDescription = table.Column<bool>(type: "bit", nullable: true),
                    UseLocalTaxCodeDescription = table.Column<bool>(type: "bit", nullable: true),
                    RentalDeliveryDefaultTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StateTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseAbsoluteTaxCodes = table.Column<bool>(type: "bit", nullable: true),
                    SmallSubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShopID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseImage = table.Column<bool>(type: "bit", nullable: true),
                    LogoFile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VendorID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintFinalCC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PrintFinalBCC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StoreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TVHAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TVHKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TVHCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TVHWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchARCurrency",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ARAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebitAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebitAccountReevaluate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditAccountReevaluate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchARCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Briggs",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StockingCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinOrderQty = table.Column<short>(type: "smallint", nullable: true),
                    Disposition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Briggs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BTPrimeMover",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTPrimeMover", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallReports",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CallDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Salesman = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowupDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Complete = table.Column<short>(type: "smallint", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    BillableHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ScheduleFollowup = table.Column<short>(type: "smallint", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CascadeParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UsePartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CascadeParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCTransactions",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionID = table.Column<long>(type: "bigint", nullable: true),
                    smartTerminalID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RequestPaymentID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Processed = table.Column<bool>(type: "bit", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    eRentResNum = table.Column<long>(type: "bigint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GPAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Controlled = table.Column<bool>(type: "bit", nullable: true),
                    AccountsRecievable = table.Column<bool>(type: "bit", nullable: true),
                    AccountsPayable = table.Column<bool>(type: "bit", nullable: true),
                    CashAccount = table.Column<bool>(type: "bit", nullable: true),
                    ReportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SectionGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Item = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyExchangeAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    WIPAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccruedPOAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxFlag = table.Column<bool>(type: "bit", nullable: true),
                    PaidTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaidTaxProfitAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaidTaxLossAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSDept = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSProduct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckData",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckNo = table.Column<int>(type: "int", nullable: false),
                    CheckDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CashAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    PrintedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    PostedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cleared = table.Column<bool>(type: "bit", nullable: false),
                    DateCleared = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClearedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClearedEntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckDataTemp",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    CheckNo = table.Column<long>(type: "bigint", nullable: true),
                    CheckDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CashAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    PrintedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckDataTemp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    APInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HistoryFlag = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountTaken = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesTaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    APDetailID = table.Column<int>(type: "int", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckDetailTemp",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    APInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HistoryFlag = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountTaken = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesTaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    APDetailID = table.Column<int>(type: "int", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckDetailTemp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckFormat",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TopPosition = table.Column<int>(type: "int", nullable: true),
                    LeftPosition = table.Column<int>(type: "int", nullable: true),
                    Font = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FontSize = table.Column<int>(type: "int", nullable: true),
                    FontBold = table.Column<bool>(type: "bit", nullable: false),
                    FontItalic = table.Column<bool>(type: "bit", nullable: false),
                    PrintElement = table.Column<bool>(type: "bit", nullable: false),
                    ElementFormat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckFormat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityTaxCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTaxCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clark",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NetPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CHCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyNetPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCustomerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentTemplate",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Template = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Group1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Group2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Group3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Group4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Group5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Group6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceCopies = table.Column<short>(type: "smallint", nullable: true),
                    LastInvoiceCopy = table.Column<bool>(type: "bit", nullable: false),
                    AutomaticInvoiceDate = table.Column<bool>(type: "bit", nullable: false),
                    PartsCurrencyFormat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountingPackage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountingPath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APCheckFormat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NextPO = table.Column<int>(type: "int", nullable: true),
                    EqNextPO = table.Column<int>(type: "int", nullable: true),
                    CurrentFiscalStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    RetainedEarnings = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountingCutoffDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrintLaborSummary = table.Column<bool>(type: "bit", nullable: false),
                    PrintSerialNo = table.Column<bool>(type: "bit", nullable: false),
                    PrintMake = table.Column<bool>(type: "bit", nullable: false),
                    PrintModel = table.Column<bool>(type: "bit", nullable: false),
                    PrintUnitNo = table.Column<bool>(type: "bit", nullable: false),
                    PrintModelGroup = table.Column<bool>(type: "bit", nullable: false),
                    PrintModelYear = table.Column<bool>(type: "bit", nullable: false),
                    PrintStage = table.Column<bool>(type: "bit", nullable: false),
                    PrintUpright = table.Column<bool>(type: "bit", nullable: false),
                    PrintDownHeight = table.Column<bool>(type: "bit", nullable: false),
                    PrintForks = table.Column<bool>(type: "bit", nullable: false),
                    PrintAttachments = table.Column<bool>(type: "bit", nullable: false),
                    PrintPower = table.Column<bool>(type: "bit", nullable: false),
                    PrintTransmission = table.Column<bool>(type: "bit", nullable: false),
                    PrintCapacity = table.Column<bool>(type: "bit", nullable: false),
                    PrintTireType = table.Column<bool>(type: "bit", nullable: false),
                    PrintLBR = table.Column<bool>(type: "bit", nullable: false),
                    PrintEquipmentComments = table.Column<bool>(type: "bit", nullable: false),
                    DefaultEquipmentComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoFile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AutoSalesGroup = table.Column<bool>(type: "bit", nullable: false),
                    DisableMilesCalculation = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextCustomerNo = table.Column<int>(type: "int", nullable: true),
                    DefaultCustomerTerms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LTGuruUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LTGuruPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DealerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IntrupaDealerNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LPMDealerNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactFollowupDays = table.Column<short>(type: "smallint", nullable: true),
                    DefaultWholeVerbage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultDecimalVerbage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceCutOffDay = table.Column<short>(type: "smallint", nullable: true),
                    WIPAccrual = table.Column<bool>(type: "bit", nullable: false),
                    IncludeWIPBalance = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CheckDateFormat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SMTPServer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SMTPUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SMTPPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EMailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FutureCutOffDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    UseImage = table.Column<bool>(type: "bit", nullable: false),
                    NextControlNo = table.Column<int>(type: "int", nullable: true),
                    LaborRounding = table.Column<short>(type: "smallint", nullable: true),
                    EmailComments = table.Column<string>(type: "text", nullable: true),
                    SMTPPort = table.Column<int>(type: "int", nullable: true),
                    UseUserID = table.Column<bool>(type: "bit", nullable: true),
                    eLiftUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eLiftPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eliftTest = table.Column<short>(type: "smallint", nullable: true),
                    MobileIncludeMisc = table.Column<int>(type: "int", nullable: true),
                    MobileIncludeTimes = table.Column<int>(type: "int", nullable: true),
                    MobileAutoDocCenter = table.Column<int>(type: "int", nullable: true),
                    MobileEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SMTPSecure = table.Column<bool>(type: "bit", nullable: true),
                    SMTPSecureType = table.Column<int>(type: "int", nullable: true),
                    StartTimeDefault = table.Column<DateTime>(type: "datetime", nullable: true),
                    NoClearSignature = table.Column<int>(type: "int", nullable: true),
                    DispatchManualRefresh = table.Column<int>(type: "int", nullable: true),
                    QuotePartsNA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileSuppressPartNo = table.Column<int>(type: "int", nullable: true),
                    MobileAddHours = table.Column<int>(type: "int", nullable: true),
                    Office365 = table.Column<int>(type: "int", nullable: true),
                    MSExchange = table.Column<int>(type: "int", nullable: true),
                    QtoOAllowPartialBO = table.Column<int>(type: "int", nullable: true),
                    HourMeterChangeAllowed = table.Column<int>(type: "int", nullable: true),
                    EmailOption = table.Column<int>(type: "int", nullable: true),
                    UsePayByCreditCard = table.Column<bool>(type: "bit", nullable: false),
                    CreditCardVendor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuthLogin = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AuthPwd = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LCount = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TVHAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TVHKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TVHCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TVHWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncludeRAWHours = table.Column<bool>(type: "bit", nullable: false),
                    QuoteHoldParts = table.Column<int>(type: "int", nullable: true),
                    EquipmentDeleteTest = table.Column<int>(type: "int", nullable: true),
                    QtoOPromptEachBO = table.Column<int>(type: "int", nullable: true),
                    eRentKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PJTest = table.Column<bool>(type: "bit", nullable: true),
                    TrailerFlag = table.Column<bool>(type: "bit", nullable: true),
                    DisallowAutoPostCC = table.Column<bool>(type: "bit", nullable: true),
                    BillTrustHost = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillTrustUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillTrustPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillTrustPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillTrustAgingDay = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMailing",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMailing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IndexPointer = table.Column<short>(type: "smallint", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cellular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    wwwHomePage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesGroup1 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup2 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup3 = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    SalesGroup4 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup5 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup6 = table.Column<bool>(type: "bit", nullable: false),
                    MailingList = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountyTaxCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountySpecialFlag = table.Column<bool>(type: "bit", nullable: false),
                    StateSpecialAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateSpecialRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateSpecialMin = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateSpecialMax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Quebec = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyTaxCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crown",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecialQty = table.Column<bool>(type: "bit", nullable: false),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NationalList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedbyPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LevelCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    QtyBreakCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BestQtyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WalMartList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NewChanged = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TargetList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crown", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cushman",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Returnable = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cushman", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SearchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    POBox = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salutation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cellular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Beeper = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResaleNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WWWAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MapLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Salesman2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LockAPR1 = table.Column<bool>(type: "bit", nullable: false),
                    LockAPR2 = table.Column<bool>(type: "bit", nullable: false),
                    LockAPR3 = table.Column<bool>(type: "bit", nullable: false),
                    LockAPR4 = table.Column<bool>(type: "bit", nullable: false),
                    LockAPR5 = table.Column<bool>(type: "bit", nullable: false),
                    LockAPR6 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup1 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup2 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup3 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup4 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup5 = table.Column<bool>(type: "bit", nullable: false),
                    SalesGroup6 = table.Column<bool>(type: "bit", nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FiscalEnd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DunsCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SICCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailingGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Makes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    POReq = table.Column<bool>(type: "bit", nullable: false),
                    PrevShip = table.Column<bool>(type: "bit", nullable: false),
                    Taxable = table.Column<bool>(type: "bit", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LaborRate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShopLaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShowLaborRate = table.Column<short>(type: "smallint", nullable: true),
                    RentalRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShowPartNoAlias = table.Column<short>(type: "smallint", nullable: true),
                    PartsRate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PartsRateDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Added = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CSContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountingContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InternalCustomer = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentBid = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCommentsDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompanyCommentsBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SICCode2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SICCode3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SICCode4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shifts = table.Column<short>(type: "smallint", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoursOfOpStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoursOfOpEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeliveryInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTerritory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditHoldFlag = table.Column<bool>(type: "bit", nullable: false),
                    CreditRating1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditRating2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Statements = table.Column<bool>(type: "bit", nullable: false),
                    CreditHoldDays = table.Column<bool>(type: "bit", nullable: false),
                    FinanceCharge = table.Column<bool>(type: "bit", nullable: false),
                    ResaleExpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StateTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AbsoluteTaxCodes = table.Column<bool>(type: "bit", nullable: false),
                    MFGPermitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MFGPermitExpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    ShowLaborHours = table.Column<bool>(type: "bit", nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardCVV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardExpDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameOnCreditCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SuppressPartsPricing = table.Column<bool>(type: "bit", nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ServiceChargeDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FinalCopies = table.Column<bool>(type: "bit", nullable: false),
                    POBoxAndAddress = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsuranceNoDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsuranceNoRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreditCardAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardPOBox = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PMLaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReferenceNo1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReferenceNo2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GMSummary = table.Column<bool>(type: "bit", nullable: false),
                    OB10No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerBillTo = table.Column<bool>(type: "bit", nullable: false),
                    ShipVia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NoAddMisc = table.Column<bool>(type: "bit", nullable: false),
                    LaborDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TMHUNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LockTaxCode = table.Column<bool>(type: "bit", nullable: false),
                    TaxCodeImport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoShippingCharge = table.Column<bool>(type: "bit", nullable: false),
                    ShippingCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMailInvoiceAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EMailInvoiceAttention = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EMailInvoice = table.Column<bool>(type: "bit", nullable: false),
                    NoPrintInvoice = table.Column<bool>(type: "bit", nullable: false),
                    BackupRequired = table.Column<bool>(type: "bit", nullable: false),
                    OldSalesman1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldSalesman2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldSalesman3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldSalesman4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldSalesman5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldSalesman6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastAutoSalesmanUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAutoSalesmanUpdate1 = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAutoSalesmanUpdate2 = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAutoSalesmanUpdate3 = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAutoSalesmanUpdate4 = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAutoSalesmanUpdate5 = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAutoSalesmanUpdate6 = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvoiceLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeopleSoft = table.Column<bool>(type: "bit", nullable: true),
                    PSCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSDept = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PSProduct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AltCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OverRideShipTo = table.Column<bool>(type: "bit", nullable: false),
                    OnFileResale = table.Column<bool>(type: "bit", nullable: false),
                    OnFileMFGPermit = table.Column<bool>(type: "bit", nullable: false),
                    OnFileInsurance = table.Column<bool>(type: "bit", nullable: false),
                    Inactive = table.Column<int>(type: "int", nullable: true),
                    OverRideShipToRates = table.Column<int>(type: "int", nullable: true),
                    SuppressPartsList = table.Column<short>(type: "smallint", nullable: true),
                    MarketingSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreditCardLastTransID = table.Column<int>(type: "int", nullable: true),
                    EmailRoadService = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    EmailShopService = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    EmailPMService = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    EmailRentalPMService = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    EmailPartsCounter = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    EmailEquipmentSales = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    EmailRentals = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    ARStatementsEmailAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPartsPrice",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPartsPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPO",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LimitAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Daewoo",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IncrementalSellQty = table.Column<int>(type: "int", nullable: true),
                    SellUnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DealerNet = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyDealerNet = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyRetailPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daewoo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryNoLog",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryNo = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RentalDays = table.Column<int>(type: "int", nullable: true),
                    TransportationHours = table.Column<int>(type: "int", nullable: true),
                    DeliveryCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReturnCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DeliveryHourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNoLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depreciation",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepreciationGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartingValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ResidualValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NetBookValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalMonths = table.Column<short>(type: "smallint", nullable: true),
                    RemainingMonths = table.Column<short>(type: "smallint", nullable: true),
                    CreditAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebitAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdatedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ManualAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dept",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<short>(type: "smallint", nullable: false),
                    Dept = table.Column<short>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleGroup = table.Column<short>(type: "smallint", nullable: true),
                    MechGroup = table.Column<short>(type: "smallint", nullable: true),
                    InvoiceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InvoiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LaborAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EquipmentAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InternalCustomer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NextInvoice = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MiscDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiscPercent = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    MiscSaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiscLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MiscLaborOnly = table.Column<bool>(type: "bit", nullable: true),
                    DeptGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TermsOverRide = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsPricing = table.Column<bool>(type: "bit", nullable: true),
                    InitialComments = table.Column<bool>(type: "bit", nullable: true),
                    MiscPartsOnly = table.Column<bool>(type: "bit", nullable: true),
                    HoursInDay = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DaysInWeek = table.Column<short>(type: "smallint", nullable: true),
                    DaysIn4Week = table.Column<short>(type: "smallint", nullable: true),
                    DaysInMonth = table.Column<short>(type: "smallint", nullable: true),
                    DaysInQuarter = table.Column<short>(type: "smallint", nullable: true),
                    NextPONo = table.Column<int>(type: "int", nullable: true),
                    NextQuote = table.Column<int>(type: "int", nullable: true),
                    QuoteComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NextRentalContract = table.Column<int>(type: "int", nullable: true),
                    SuppressLaborHours = table.Column<bool>(type: "bit", nullable: true),
                    AdditionalLaborHours = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AdditionalLaborMech = table.Column<int>(type: "int", nullable: true),
                    AdditionalLaborAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalReturnStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SuppressPartsPricing = table.Column<bool>(type: "bit", nullable: true),
                    QuoteExpirationDays = table.Column<short>(type: "smallint", nullable: true),
                    InvoiceComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenWOWatermark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BOPriority = table.Column<short>(type: "smallint", nullable: true),
                    StockPriority = table.Column<short>(type: "smallint", nullable: true),
                    EmergencyCostPriority = table.Column<short>(type: "smallint", nullable: true),
                    TaxAtDealer = table.Column<bool>(type: "bit", nullable: true),
                    QuoteVerbiage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoCreditOnQuote = table.Column<bool>(type: "bit", nullable: true),
                    InvoiceNameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuoteVerbiageFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileDisclaimer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileSignatureDisclaimer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalTopText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditCardAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoCC = table.Column<bool>(type: "bit", nullable: true),
                    PartsRecvEmail = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchNames",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DispatchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchPriority",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchSecondary",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WONo = table.Column<long>(type: "bigint", nullable: true),
                    DispatchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchSecondary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchStatusTable",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchStatusTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dixon",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dixon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EFTData",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EFTNo = table.Column<int>(type: "int", nullable: false),
                    EFTDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EFTAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CashAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Posted = table.Column<int>(type: "int", nullable: true),
                    PostedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cleared = table.Column<bool>(type: "bit", nullable: false),
                    DateCleared = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClearedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClearedEntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFTData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EFTDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyID = table.Column<long>(type: "bigint", nullable: true),
                    EFTNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    APInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HistoryFlag = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountTaken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesTaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    APDetailID = table.Column<int>(type: "int", nullable: true),
                    ApplyToAPInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFTDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMailLog",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeadersSource = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    ApplicationSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMailLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMailLogError",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorID = table.Column<int>(type: "int", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeadersSource = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    ApplicationSource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMailLogError", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OEMLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UniqueKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MasterPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OEMList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyOEMList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CatalogPriority = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CategoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecordSerialNo = table.Column<int>(type: "int", nullable: true),
                    CommodityClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EQControlNoChange",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastWOOpen = table.Column<int>(type: "int", nullable: true),
                    LastWOClosed = table.Column<int>(type: "int", nullable: true),
                    LastRentalClosed = table.Column<int>(type: "int", nullable: true),
                    LastEquipmentClosed = table.Column<int>(type: "int", nullable: true),
                    LastEquipmentCostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastServiceClosed = table.Column<int>(type: "int", nullable: true),
                    DealerOrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerAquisitionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerSaleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CommissionPaid = table.Column<bool>(type: "bit", nullable: false),
                    DealerWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerWarrantyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DealerETA = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerPaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerPaid = table.Column<bool>(type: "bit", nullable: false),
                    ITAState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ITACounty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ITASIC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerOrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerAquisitionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerMajorWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerExtendedWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExtendedWarrantyApplicationNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerWarrantyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerRequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerEnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PPSA = table.Column<short>(type: "smallint", nullable: true),
                    PPSANo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PPSACustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PPSAExpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TradeIn = table.Column<bool>(type: "bit", nullable: false),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AsIsWholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DRWholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SpecDealerReady = table.Column<bool>(type: "bit", nullable: false),
                    Retail = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PublishedPrice = table.Column<bool>(type: "bit", nullable: false),
                    WholesaleList = table.Column<bool>(type: "bit", nullable: false),
                    RetailList = table.Column<bool>(type: "bit", nullable: false),
                    CustomerLaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerShopLaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    UnitInOperation = table.Column<bool>(type: "bit", nullable: false),
                    WebRentalFlag = table.Column<bool>(type: "bit", nullable: false),
                    WebUsedFlag = table.Column<bool>(type: "bit", nullable: false),
                    SRNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FloorPlan = table.Column<bool>(type: "bit", nullable: false),
                    FloorPlanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FloorPlanBank = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FloorPlanAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FloorPlanStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FloorPlanPaid = table.Column<DateTime>(type: "datetime", nullable: true),
                    RENo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinancingNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeaseCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LeaseFlag = table.Column<bool>(type: "bit", nullable: false),
                    LeasePayment = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeaseStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeaseExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeaseTerm = table.Column<bool>(type: "bit", nullable: false),
                    LeaseResidual = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeaseAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeaseNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoursPerWorkday = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DaysPerWeek = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WeeksPerYear = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MaintPayment = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeasePONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQControlNoChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EQCustomFields",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Custom01 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom02 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom03 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom04 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom05 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom06 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom07 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom08 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom09 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom10 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom11 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom12 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom13 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom14 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom15 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom16 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom17 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom18 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom19 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom20 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQCustomFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EQCustomLabels",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Custom01 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom02 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom03 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom04 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom05 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom06 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom07 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom08 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom09 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom10 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom11 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom12 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom13 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom14 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom15 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom16 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom17 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom18 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom19 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Custom20 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQCustomLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipLocationChange",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromBranch = table.Column<bool>(type: "bit", nullable: false),
                    FromDept = table.Column<bool>(type: "bit", nullable: false),
                    FromInventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromCustomerFlag = table.Column<bool>(type: "bit", nullable: false),
                    ToBranch = table.Column<bool>(type: "bit", nullable: false),
                    ToDept = table.Column<bool>(type: "bit", nullable: false),
                    ToInventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToCustomerFlag = table.Column<bool>(type: "bit", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipLocationChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AttachedTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer = table.Column<bool>(type: "bit", nullable: false),
                    InventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InventoryBranch = table.Column<short>(type: "smallint", nullable: true),
                    InventoryDept = table.Column<short>(type: "smallint", nullable: true),
                    AttachmentInventory = table.Column<short>(type: "smallint", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AsIsWholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DRWholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Retail = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PublishedPrice = table.Column<bool>(type: "bit", nullable: false),
                    WholesaleList = table.Column<bool>(type: "bit", nullable: false),
                    RetailList = table.Column<bool>(type: "bit", nullable: false),
                    Bid1Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bid1Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Bid1Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Bid2Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bid2Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Bid2Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Bid3Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bid3Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Bid3Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    RentalRateCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DayRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WeekRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FourWeekRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MonthRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalStatusComment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelAge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldDiversion = table.Column<bool>(type: "bit", nullable: false),
                    SRNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FloorPlan = table.Column<bool>(type: "bit", nullable: false),
                    FloorPlanPaid = table.Column<DateTime>(type: "datetime", nullable: true),
                    UprightSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UprightDownHeight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UprightHeight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UprightStage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TireType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecForks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecAttatchments = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecTransmission = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecComments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecWarranty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecLBR = table.Column<bool>(type: "bit", nullable: false),
                    SpecTirePercent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecDealerReady = table.Column<bool>(type: "bit", nullable: false),
                    SpecSource = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecRetailComments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EngineSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SteerAxilSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdditionalSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WOInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastHourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastHourMeterDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HourMeterHistory = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HourMeterStart = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HourMeterStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastOdometer = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastOdometerDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OdometerHistory = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OdometerStart = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OdometerStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalFuel = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalFuelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FuelRequireHour = table.Column<bool>(type: "bit", nullable: false),
                    FuelRequireOdometer = table.Column<bool>(type: "bit", nullable: false),
                    LastWOOpen = table.Column<long>(type: "bigint", nullable: true),
                    LastWOOpenDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastWOClosed = table.Column<int>(type: "int", nullable: true),
                    LastWOClosedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastRentalClosed = table.Column<int>(type: "int", nullable: true),
                    LastRentalClosedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastEquipmentClosed = table.Column<long>(type: "bigint", nullable: true),
                    LastEquipmentClosedTerr = table.Column<int>(type: "int", nullable: true),
                    LastEquipmentClosedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastEquipmentSalesman = table.Column<int>(type: "int", nullable: true),
                    LastEquipmentCostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastServiceClosed = table.Column<int>(type: "int", nullable: true),
                    LastServiceClosedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerAquisitionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerSaleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerWarrantyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DealerPaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerPaid = table.Column<short>(type: "smallint", nullable: true),
                    CustomerAquisitionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerWarrantyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeaseExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerLaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerShopLaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServiceITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IncomeITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ServiceITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IncomeITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ServiceYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IncomeYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ServiceYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IncomeYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalServiceITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalPartsITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalLaborITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalMiscITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalIncomeITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalRentalITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalServiceITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalPartsITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalLaborITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalMiscITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalIncomeITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalServiceYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalPartsYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalLaborYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalMiscYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalIncomeYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalRentalYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalServiceYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalPartsYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalLaborYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalMiscYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalIncomeYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GuaranteedMaintenance = table.Column<bool>(type: "bit", nullable: false),
                    GMService = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GMParts = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GMLabor = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GMMisc = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GMIncome = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GMPeriods = table.Column<bool>(type: "bit", nullable: false),
                    GMPeriodsBilled = table.Column<bool>(type: "bit", nullable: false),
                    GMStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastGM = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastYTDRoll = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastYTDRollBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UprightModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UprightLot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderBooked = table.Column<bool>(type: "bit", nullable: false),
                    CustomerMajorWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PictureFile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DealerOrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OnOrder = table.Column<bool>(type: "bit", nullable: false),
                    SpecInternalHosing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeprAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerExtendedWarrantyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FloorPlanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RENo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinancingNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuarterRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SpecTireSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecValves = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoursAllowed = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GMLastInvoiceNo = table.Column<int>(type: "int", nullable: true),
                    OTRatePerHour = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SpecBattery = table.Column<bool>(type: "bit", nullable: false),
                    SpecCharger = table.Column<bool>(type: "bit", nullable: false),
                    WebRentalFlag = table.Column<bool>(type: "bit", nullable: false),
                    WebUsedFlag = table.Column<bool>(type: "bit", nullable: false),
                    AcquiredFrom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DealerETA = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerRequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeaseCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LeasePayment = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeaseTerm = table.Column<bool>(type: "bit", nullable: false),
                    LeaseResidual = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeaseAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LeaseNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoadCenter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaintPayment = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HoursPerWorkday = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WeeksPerYear = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DaysPerWeek = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PPSANo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PPSAExpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PPSACustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PPSA = table.Column<short>(type: "smallint", nullable: true),
                    ExtendedWarrantyApplicationNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InsuranceRequired = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceCoverage = table.Column<bool>(type: "bit", nullable: false),
                    TireDriveSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TireSteerSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BatteryVoltage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BatteryConnector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineMake = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InTransitAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecFreeLift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecEngineType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeliveryNo = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RentalDays = table.Column<int>(type: "int", nullable: true),
                    TransportationHours = table.Column<int>(type: "int", nullable: true),
                    DeliveryCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReturnCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DeliveryHourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ImportNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UprightScale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WOComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITAState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ITACounty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ITASIC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StockType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommissionPaid = table.Column<bool>(type: "bit", nullable: false),
                    SpecWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerEnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerOrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TargetCostPerHour = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TireDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RerentFlag = table.Column<bool>(type: "bit", nullable: false),
                    RerentHere = table.Column<bool>(type: "bit", nullable: false),
                    FloorPlanBank = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FloorPlanAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FloorPlanStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeaseStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastDeliveryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastDeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenHousingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenPhase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenFuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenCondition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenVoltage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenInventoryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenEndSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenEndModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenEndMake = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenFrequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenRPM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenFuelTankID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenEPATier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeaseFlag = table.Column<bool>(type: "bit", nullable: false),
                    LeasePONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelShort = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    eLiftTruck = table.Column<bool>(type: "bit", nullable: false),
                    eMake = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eEngine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eMastType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eOther = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    eState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileRecommended = table.Column<string>(type: "text", nullable: true),
                    TradeIn = table.Column<short>(type: "smallint", nullable: true),
                    LoadBankTested = table.Column<int>(type: "int", nullable: true),
                    LoadTestDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LoadTestVoltage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalOTRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitInOperation = table.Column<bool>(type: "bit", nullable: false),
                    TShardware_id = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    TrackingSolutions = table.Column<bool>(type: "bit", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCost",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PONo = table.Column<long>(type: "bigint", nullable: false),
                    PODescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RecvBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EntryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer = table.Column<bool>(type: "bit", nullable: false),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPODetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONo = table.Column<int>(type: "int", nullable: false),
                    Received = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RecvBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccruedPOAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPODetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentRemoved",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InventoryBranch = table.Column<int>(type: "int", nullable: true),
                    InventoryDept = table.Column<int>(type: "int", nullable: true),
                    Customer = table.Column<int>(type: "int", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RemovedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRemoved", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentYTD",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IncomeYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ServiceYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IncomeYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalServiceYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalPartsYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalLaborYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalMiscYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalIncomeYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalRentalYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalServiceYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalPartsYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalLaborYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalMiscYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InternalIncomeYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentYTD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eRentContactDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<long>(type: "bigint", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ContactMe = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eRentContactDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eRentEquipmentDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<long>(type: "bigint", nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipmentGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DailyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WeeklyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MonthlyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Transportation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eRentEquipmentDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eRentFeesDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<long>(type: "bigint", nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipmentGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Charge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    EquipmentDetailID = table.Column<long>(type: "bigint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eRentFeesDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eRentReservation",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<long>(type: "bigint", nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerPO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Insurance = table.Column<byte[]>(type: "image", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Booked = table.Column<bool>(type: "bit", nullable: false),
                    DateBooked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhoBooked = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eRentReservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventData = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<short>(type: "smallint", nullable: false),
                    Dept = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InternalCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerBatch = table.Column<short>(type: "smallint", nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: false),
                    OverRideInvCOG = table.Column<bool>(type: "bit", nullable: false),
                    BuildPart = table.Column<bool>(type: "bit", nullable: false),
                    Added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EZGo",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EZGo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryCat",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryCat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FedExCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FedExCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FOB",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FOB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SortOrder = table.Column<short>(type: "smallint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EntryBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Odometer = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FuelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FuelAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    PumpNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ValuePerUnit = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GL",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    Month = table.Column<short>(type: "smallint", nullable: false),
                    YTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastTransAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastTransDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastTransBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastEffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NumberOfTrans = table.Column<int>(type: "int", nullable: true),
                    LastTransJournal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GLDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AccountField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HistoryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HistoryFlag = table.Column<bool>(type: "bit", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProgramVersion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ARCheckNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ARPONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    APCheckNo = table.Column<int>(type: "int", nullable: true),
                    APPONo = table.Column<int>(type: "int", nullable: true),
                    UniqueFieldLegacy = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GLField",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<bool>(type: "bit", nullable: false),
                    Calculated = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GLGroup",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectionGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GLQuarter",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    MTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    YTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LMTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LQTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLQuarter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GLSection",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gravely",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ObsoleteCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackageQty = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gravely", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroundPower",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PriceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundPower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTable",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PriceDisk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Discount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Internal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warranty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Wholesale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MarkupCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MarkupDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MarkupList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MarkupInternal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MarkupWarranty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MarkupWholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MinDays = table.Column<short>(type: "smallint", nullable: true),
                    MaxDays = table.Column<short>(type: "smallint", nullable: true),
                    AvgMonths = table.Column<short>(type: "smallint", nullable: true),
                    RatingA = table.Column<short>(type: "smallint", nullable: true),
                    RatingB = table.Column<short>(type: "smallint", nullable: true),
                    RatingC = table.Column<short>(type: "smallint", nullable: true),
                    RatingD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RatingMonths = table.Column<short>(type: "smallint", nullable: true),
                    PhaseInDemand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PhaseInBinTrips = table.Column<int>(type: "int", nullable: true),
                    PhaseInMonths = table.Column<short>(type: "smallint", nullable: true),
                    PhaseOutDemand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PhaseOutBinTrips = table.Column<int>(type: "int", nullable: true),
                    PhaseOutMonths = table.Column<short>(type: "smallint", nullable: true),
                    NoCostReprice = table.Column<short>(type: "smallint", nullable: true),
                    NoListReprice = table.Column<short>(type: "smallint", nullable: true),
                    LandedPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UseCurrencyCost = table.Column<short>(type: "smallint", nullable: true),
                    DefaultGroup = table.Column<short>(type: "smallint", nullable: true),
                    EmergencyMarkup = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamech",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpecialQty = table.Column<short>(type: "smallint", nullable: false),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedbyPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LevelCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QtyBreakCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BestQtyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WalMartList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NewChanged = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TargetList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamech", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helmar",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helmar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Henderson",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Henderson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hiab",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hiab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Honda",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NewPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NewPart_PRNT_MK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NonReturnable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Part_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hyundai",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NotReturnable = table.Column<short>(type: "smallint", nullable: true),
                    SupersededBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hyundai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionQuestion",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OK = table.Column<int>(type: "int", nullable: true),
                    Potential = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Urgent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternetLog",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selection = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecureName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intrupa",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OEM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Occurrence = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IntrupaNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Package = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unknown1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unknown2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intrupa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvCategory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Count = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountFlag = table.Column<short>(type: "smallint", nullable: true),
                    CountDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostFlag = table.Column<short>(type: "smallint", nullable: true),
                    PostDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CaptureDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvDetailBin",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Count = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountFlag = table.Column<short>(type: "smallint", nullable: true),
                    CountDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostFlag = table.Column<short>(type: "smallint", nullable: true),
                    PostDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CaptureDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvDetailBin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCount",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BinLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Count = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Posted = table.Column<short>(type: "smallint", nullable: true),
                    DateGenerated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvHeader",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcludeDelete = table.Column<bool>(type: "bit", nullable: true),
                    ExcludeChanged = table.Column<bool>(type: "bit", nullable: true),
                    ExcludeNew = table.Column<bool>(type: "bit", nullable: true),
                    CycleCount = table.Column<bool>(type: "bit", nullable: true),
                    BinFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BinTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefreshedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: true),
                    NotCountedSince = table.Column<DateTime>(type: "datetime", nullable: true),
                    DemandRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MultipleBinMethod = table.Column<bool>(type: "bit", nullable: true),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncludeNeverCounted = table.Column<short>(type: "smallint", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RefreshedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceReg",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<int>(type: "int", nullable: false),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpBranch = table.Column<short>(type: "smallint", nullable: true),
                    ExpDept = table.Column<short>(type: "smallint", nullable: true),
                    ExpCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer = table.Column<short>(type: "smallint", nullable: true),
                    GuaranteedMaintenance = table.Column<short>(type: "smallint", nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillToName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillToZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OpenBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RecvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CopiesPrinted = table.Column<short>(type: "smallint", nullable: true),
                    DemandCopyPrinted = table.Column<bool>(type: "bit", nullable: true),
                    CopiesComplete = table.Column<bool>(type: "bit", nullable: true),
                    DetailCopiesPrinted = table.Column<bool>(type: "bit", nullable: true),
                    PartsCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsTaxable = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborTaxable = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscTaxable = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalTaxable = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentTaxable = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsNonTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborNonTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscNonTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalNonTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentNonTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateFinalPrinted = table.Column<DateTime>(type: "datetime", nullable: true),
                    StateTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountyTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CityTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PrintSkippedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OdometerReading = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LocalTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ConvertedGrandTotal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NumeroDeFactura = table.Column<int>(type: "int", nullable: true),
                    StateSpecialTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OB10No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OB10Export = table.Column<short>(type: "smallint", nullable: true),
                    TMHUExport = table.Column<short>(type: "smallint", nullable: true),
                    TMHUNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintSelect = table.Column<short>(type: "smallint", nullable: true),
                    TMTExport = table.Column<short>(type: "smallint", nullable: true),
                    TSPull = table.Column<int>(type: "int", nullable: true),
                    BillTrustExclude = table.Column<bool>(type: "bit", nullable: true),
                    BillTrustFlag = table.Column<bool>(type: "bit", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceReg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDescription",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDescription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JohnDeere",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorePart = table.Column<short>(type: "smallint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PackageQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExchangeCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExchangeList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReturnCreditCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReturnCreditList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Returnable = table.Column<short>(type: "smallint", nullable: true),
                    PricedPerEachOrPer100 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceEffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StockOrderDiscount = table.Column<short>(type: "smallint", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JohnDeere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Payment = table.Column<short>(type: "smallint", nullable: true),
                    APCheck = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalHeader",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    AccountField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyOfJournal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cleared = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kohler",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PartNoPrefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoSuffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kohler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Komatsu",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NetPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CHCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsePartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyNetPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCustomerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCodeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KomatsuUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komatsu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kubota",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MultiPack = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kubota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborQuote",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AvgHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MaxHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborQuote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborQuoteGroup",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborQuoteGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborRate",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OverTime = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Premium = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tabbed = table.Column<short>(type: "smallint", nullable: true),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldNo = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Indexed = table.Column<short>(type: "smallint", nullable: true),
                    LabelCaption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Linde",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ECost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyECost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linde", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalTaxCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    LaborNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    MiscNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    RentalNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTaxCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPM",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OEM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Occurrence = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LPMNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Package = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unknown1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unknown2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LynxRite",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OEMPartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MFG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost1050 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost51100 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost1050 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost51100 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LynxRite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailingCategory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Make",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketingSources",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    MarketingSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MechanicImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    MechanicNo = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    ProcessedTicket = table.Column<short>(type: "smallint", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MechanicLabor",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    MechanicNo = table.Column<int>(type: "int", nullable: true),
                    LaborDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WOArrivalID = table.Column<int>(type: "int", nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DispatchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TravelFlag = table.Column<bool>(type: "bit", nullable: false),
                    LostTimeFlag = table.Column<bool>(type: "bit", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicLabor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MechanicLaborSignature",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    MechanicNo = table.Column<int>(type: "int", nullable: true),
                    LaborDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateSigned = table.Column<DateTime>(type: "datetime", nullable: true),
                    Signature = table.Column<byte[]>(type: "image", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicLaborSignature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiscPODetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PONo = table.Column<int>(type: "int", nullable: false),
                    Received = table.Column<short>(type: "smallint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReceivedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    AccruedPOAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WOMiscID = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscPODetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MitCat",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ECostCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NonReturnable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacementCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinQty = table.Column<short>(type: "smallint", nullable: true),
                    HazMatCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NetWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GrossWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FreeTrade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rebuilt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerCoreCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerCoreCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VelocityIndicator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MitCat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MitCatReplacement",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReplacementType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNo1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty1 = table.Column<short>(type: "smallint", nullable: true),
                    PartNo2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty2 = table.Column<short>(type: "smallint", nullable: true),
                    PartNo3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty3 = table.Column<short>(type: "smallint", nullable: true),
                    PartNo4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty4 = table.Column<short>(type: "smallint", nullable: true),
                    PartNo5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty5 = table.Column<short>(type: "smallint", nullable: true),
                    PartNo6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty6 = table.Column<short>(type: "smallint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MitCatReplacement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileHourMeter",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileHourMeter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelGroup",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moffett",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moffett", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationalParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nissan",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PriceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacesPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedByPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnableFlag = table.Column<short>(type: "smallint", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nissan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<short>(type: "smallint", nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CostEach = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NoCostUpdate = table.Column<short>(type: "smallint", nullable: true),
                    RecvQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Recved = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PrintTicket = table.Column<short>(type: "smallint", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Priority = table.Column<short>(type: "smallint", nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorBO = table.Column<short>(type: "smallint", nullable: true),
                    ItemComments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReceivedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Approved = table.Column<short>(type: "smallint", nullable: true),
                    VendorBODate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreRecv = table.Column<short>(type: "smallint", nullable: true),
                    DetailLineNo = table.Column<int>(type: "int", nullable: true),
                    PreRecvQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OriginalInvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccruedPOAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    WOPartsID = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TempQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Selected = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersFreight",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Customs = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RecvBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersFreight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersRecv",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    OrdersEntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CostEach = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RecvQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Priority = table.Column<short>(type: "smallint", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrokerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomsNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FreightAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomsAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AccruedPOAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxNo = table.Column<short>(type: "smallint", nullable: true),
                    RecvBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    PreviousImportQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersRecv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ottawa",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ottawa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parker",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartNoAlias",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PartNoAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartNoAlias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MFGCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MasterPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsePartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CorePartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoreWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PriorStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode = table.Column<short>(type: "smallint", nullable: true),
                    Published = table.Column<short>(type: "smallint", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RatingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Internal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Warranty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Wholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OldCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OldDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OldList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NoReprice = table.Column<short>(type: "smallint", nullable: true),
                    NonTaxable = table.Column<short>(type: "smallint", nullable: true),
                    FullBin = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StartingOnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Allocated = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OnOrder = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BackOrder = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AbsoluteMin = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MinStock = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MaxStock = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PackageQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BlockQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AutoOrder = table.Column<short>(type: "smallint", nullable: true),
                    CoreFlag = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastOrder = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastDemand = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastSale = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastPick = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastRecv = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAdjustment = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastInventory = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastTransfer = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastReplenishment = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastReprice = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthEndStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthEndQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SellAsAlias = table.Column<short>(type: "smallint", nullable: true),
                    PreferredVendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReferenceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreFreightCustomsCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OldNUmber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KitFlag = table.Column<short>(type: "smallint", nullable: true),
                    NonReturnable = table.Column<short>(type: "smallint", nullable: true),
                    PartNoOriginal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeadTime = table.Column<short>(type: "smallint", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SerialNoRequired = table.Column<short>(type: "smallint", nullable: true),
                    StatusReviewDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InvCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    DefaultTaxCodesParts = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesPartsDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsAltPricing",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartsRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalList = table.Column<short>(type: "smallint", nullable: true),
                    QtyBreak = table.Column<short>(type: "smallint", nullable: true),
                    WalmartPricing = table.Column<short>(type: "smallint", nullable: true),
                    TargetPricing = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsAltPricing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsBinHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OldBin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsBinHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsBinTrips",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BinTrips1 = table.Column<int>(type: "int", nullable: true),
                    BinTrips2 = table.Column<int>(type: "int", nullable: true),
                    BinTrips3 = table.Column<int>(type: "int", nullable: true),
                    BinTrips4 = table.Column<int>(type: "int", nullable: true),
                    BinTrips5 = table.Column<int>(type: "int", nullable: true),
                    BinTrips6 = table.Column<int>(type: "int", nullable: true),
                    BinTrips7 = table.Column<int>(type: "int", nullable: true),
                    BinTrips8 = table.Column<int>(type: "int", nullable: true),
                    BinTrips9 = table.Column<int>(type: "int", nullable: true),
                    BinTrips10 = table.Column<int>(type: "int", nullable: true),
                    BinTrips11 = table.Column<int>(type: "int", nullable: true),
                    BinTrips12 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast1 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast2 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast3 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast4 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast5 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast6 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast7 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast8 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast9 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast10 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast11 = table.Column<int>(type: "int", nullable: true),
                    BinTripsLast12 = table.Column<int>(type: "int", nullable: true),
                    LastRoll = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsBinTrips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsCost",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    BrokerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomsNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsCostChange",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PreviousCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrentCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCostChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsCustAlias",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCustAlias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsDemand",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Demand1 = table.Column<int>(type: "int", nullable: true),
                    Demand2 = table.Column<int>(type: "int", nullable: true),
                    Demand3 = table.Column<int>(type: "int", nullable: true),
                    Demand4 = table.Column<int>(type: "int", nullable: true),
                    Demand5 = table.Column<int>(type: "int", nullable: true),
                    Demand6 = table.Column<int>(type: "int", nullable: true),
                    Demand7 = table.Column<int>(type: "int", nullable: true),
                    Demand8 = table.Column<int>(type: "int", nullable: true),
                    Demand9 = table.Column<int>(type: "int", nullable: true),
                    Demand10 = table.Column<int>(type: "int", nullable: true),
                    Demand11 = table.Column<int>(type: "int", nullable: true),
                    Demand12 = table.Column<int>(type: "int", nullable: true),
                    DemandLast1 = table.Column<int>(type: "int", nullable: true),
                    DemandLast2 = table.Column<int>(type: "int", nullable: true),
                    DemandLast3 = table.Column<int>(type: "int", nullable: true),
                    DemandLast4 = table.Column<int>(type: "int", nullable: true),
                    DemandLast5 = table.Column<int>(type: "int", nullable: true),
                    DemandLast6 = table.Column<int>(type: "int", nullable: true),
                    DemandLast7 = table.Column<int>(type: "int", nullable: true),
                    DemandLast8 = table.Column<int>(type: "int", nullable: true),
                    DemandLast9 = table.Column<int>(type: "int", nullable: true),
                    DemandLast10 = table.Column<int>(type: "int", nullable: true),
                    DemandLast11 = table.Column<int>(type: "int", nullable: true),
                    DemandLast12 = table.Column<int>(type: "int", nullable: true),
                    LastRoll = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsDemand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsInquiryHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Internal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Warranty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Wholesale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Customer = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsInquiryHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsKit",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    KitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NoPrint = table.Column<short>(type: "smallint", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsKit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsLostSaleDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    EmployeeNo = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReasonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoDemand = table.Column<short>(type: "smallint", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsLostSaleDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsLostSaleReason",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ReasonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReasonDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsLostSaleReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsLostSales",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lost1 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost2 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost3 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost4 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost5 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost6 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost7 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost8 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost9 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost10 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost11 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Lost12 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast1 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast2 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast3 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast4 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast5 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast6 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast7 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast8 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast9 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast10 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast11 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LostLast12 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastRoll = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsLostSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsOnHandChange",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PreviousOnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrentOnHand = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOnHandChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsPriceFiles",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNoWODash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoOriginal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoWOPrefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MFGCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacesPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ECost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WholesalePrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyECost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WalMartList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TargetList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyNationalList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyWalMartList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyTargetList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QUP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Markup = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackageQty = table.Column<int>(type: "int", nullable: true),
                    BlockQty = table.Column<int>(type: "int", nullable: true),
                    ObsoleteCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnFlag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NonReturn = table.Column<int>(type: "int", nullable: true),
                    ReturnCode = table.Column<int>(type: "int", nullable: true),
                    ReturnCodeDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductionStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductionEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsPriceFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsSales",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sales1 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales2 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales3 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales4 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales5 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales6 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales7 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales8 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales9 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales10 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales11 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sales12 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast1 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast2 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast3 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast4 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast5 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast6 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast7 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast8 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast9 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast10 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast11 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SalesLast12 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastRoll = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsSuppliers",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrefixToAdd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MFGCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsTransfer",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransferedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssociatedWONo = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferIDNo = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsUserCross",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MasterNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsUserCross", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsVendorAlias",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsVendorAlias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleInit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaleFemale = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtentionList = table.Column<bool>(type: "bit", nullable: false),
                    Mechanic = table.Column<bool>(type: "bit", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MonthlyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    Dept = table.Column<short>(type: "smallint", nullable: true),
                    UseDefaults = table.Column<bool>(type: "bit", nullable: false),
                    ServiceVan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureFile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastReviewDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NextReviewDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PositionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SSNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonImage = table.Column<byte[]>(type: "image", nullable: true),
                    PersonGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    AutomaticEmailBCC = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroup",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<short>(type: "smallint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PM",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpBranch = table.Column<short>(type: "smallint", nullable: true),
                    ExpDept = table.Column<short>(type: "smallint", nullable: true),
                    ExpCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MapLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OpenPmWO = table.Column<bool>(type: "bit", nullable: false),
                    WONo = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Frequency = table.Column<short>(type: "smallint", nullable: true),
                    FrequencyHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastLaborDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NextPMDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DaysRented = table.Column<int>(type: "int", nullable: true),
                    LaborCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mechanic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrentHourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastHourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Automatic = table.Column<bool>(type: "bit", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PMCancelled = table.Column<bool>(type: "bit", nullable: false),
                    PMCancelledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstLaborHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PassCount = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactEmailSubject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactEmailBody = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PMName",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PMName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PMParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Required = table.Column<short>(type: "smallint", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PMName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PMSecondary",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    EstLaborHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PassCount = table.Column<short>(type: "smallint", nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PMName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frequency = table.Column<short>(type: "smallint", nullable: true),
                    LastLaborDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NextPMDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FrequencyHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastHourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PMCancelled = table.Column<short>(type: "smallint", nullable: true),
                    PMCancelledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBasicPM = table.Column<short>(type: "smallint", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMSecondary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PMSignupHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PMCancelledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PMCancelledBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMSignupHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PMStatus",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POHeader",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PONo = table.Column<int>(type: "int", nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorSubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorZip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorFax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipVia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FOB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Disposition = table.Column<short>(type: "smallint", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToVendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToZip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToAttn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Terms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipToSubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    POBranch = table.Column<short>(type: "smallint", nullable: true),
                    PODept = table.Column<short>(type: "smallint", nullable: true),
                    VendorPromiseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipToPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrivateComments = table.Column<string>(type: "text", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PONo = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IncludeWithPO = table.Column<bool>(type: "bit", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PORecent",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyID = table.Column<int>(type: "int", nullable: true),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PONo = table.Column<long>(type: "bigint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PORecent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerBoss",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Discount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerBoss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimeMover",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimeMover", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Princeton",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Princeton", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrinterSetup",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    EmployeeNo = table.Column<int>(type: "int", nullable: false),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    BData = table.Column<byte[]>(type: "image", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrinterSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintInfoBar",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    Dept = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FieldLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintTop = table.Column<int>(type: "int", nullable: true),
                    PrintLeft = table.Column<int>(type: "int", nullable: true),
                    PrintWidth = table.Column<int>(type: "int", nullable: true),
                    FontName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FontSize = table.Column<int>(type: "int", nullable: true),
                    FontBold = table.Column<int>(type: "int", nullable: true),
                    FontItalic = table.Column<int>(type: "int", nullable: true),
                    NumericField = table.Column<int>(type: "int", nullable: true),
                    DateField = table.Column<int>(type: "int", nullable: true),
                    FieldLabelFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintInfoBar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RapidParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OEMName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MasterPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapidParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonDelayCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ATACodes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonDelayCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonRepairCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ATACodes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonRepairCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecentCustomer",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalContract",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RentalContractNo = table.Column<int>(type: "int", nullable: false),
                    CustomerCalledForPickup = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerWantsPickup = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    PickupCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DeliveryCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OpenEndedContract = table.Column<short>(type: "smallint", nullable: true),
                    PickupChargeText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeliveryChargeText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommentsPublic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentsPrivate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalDeliveryDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UnassignedRentalContract = table.Column<short>(type: "smallint", nullable: true),
                    InsuranceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsuranceRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsuranceExpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalContractLayout",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToolTipText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExampleContent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LeftPosition = table.Column<int>(type: "int", nullable: true),
                    TopPosition = table.Column<int>(type: "int", nullable: true),
                    FontName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FontSize = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalContractLayout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalHistory",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    Month = table.Column<short>(type: "smallint", nullable: false),
                    DaysRented = table.Column<int>(type: "int", nullable: true),
                    RentAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RentalContractNo = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalRate",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RentalRateCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthlyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FourWeekRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WeeklyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DailyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QuarterlyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalOTRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairCode",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCodeMemo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursAllowed = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportDefinitions",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<long>(type: "bigint", nullable: true),
                    ReportGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportGroupGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    ReportTitle = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    ReportPath = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReportSchema = table.Column<string>(type: "text", nullable: true),
                    BaseReport = table.Column<bool>(type: "bit", nullable: false),
                    ReportCreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReportLastUpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportVersion = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportGroups",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    ReportGroupGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReportGroupName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    UserDefinedGroup = table.Column<bool>(type: "bit", nullable: false),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportSecurity",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<long>(type: "bigint", nullable: true),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrigReportGroupGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportGroupGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSecurity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStyles",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Style = table.Column<string>(type: "text", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<short>(type: "smallint", nullable: false),
                    Dept = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartsCost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsDiscount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsList = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWholesale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWarranty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsInternal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Labor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Misc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rental = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsCostCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsDiscountCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsListCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWholesaleCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWarrantyCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsInternalCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LaborCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiscCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EquipmentCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscINV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsTax = table.Column<bool>(type: "bit", nullable: false),
                    LaborTax = table.Column<bool>(type: "bit", nullable: false),
                    MiscTax = table.Column<bool>(type: "bit", nullable: false),
                    RentalTax = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentTax = table.Column<bool>(type: "bit", nullable: false),
                    PartsSale = table.Column<short>(type: "smallint", nullable: true),
                    LaborSale = table.Column<short>(type: "smallint", nullable: true),
                    MiscSale = table.Column<short>(type: "smallint", nullable: true),
                    RentalSale = table.Column<short>(type: "smallint", nullable: true),
                    EquipmentSale = table.Column<short>(type: "smallint", nullable: true),
                    GeneralDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LaborDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiscDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EquipmentDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer = table.Column<bool>(type: "bit", nullable: false),
                    ReWork = table.Column<bool>(type: "bit", nullable: false),
                    GuaranteedMaintenance = table.Column<bool>(type: "bit", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalCostPrompt = table.Column<bool>(type: "bit", nullable: false),
                    AutoExp = table.Column<bool>(type: "bit", nullable: false),
                    AutoExpBranch = table.Column<short>(type: "smallint", nullable: true),
                    AutoExpDept = table.Column<short>(type: "smallint", nullable: true),
                    AutoExpCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequireSerialNo = table.Column<bool>(type: "bit", nullable: false),
                    LandedAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsStateTax = table.Column<bool>(type: "bit", nullable: false),
                    PartsCountyTax = table.Column<bool>(type: "bit", nullable: false),
                    PartsCityTax = table.Column<bool>(type: "bit", nullable: false),
                    PartsLocalTax = table.Column<bool>(type: "bit", nullable: false),
                    LaborStateTax = table.Column<bool>(type: "bit", nullable: false),
                    LaborCountyTax = table.Column<bool>(type: "bit", nullable: false),
                    LaborCityTax = table.Column<bool>(type: "bit", nullable: false),
                    LaborLocalTax = table.Column<bool>(type: "bit", nullable: false),
                    MiscStateTax = table.Column<bool>(type: "bit", nullable: false),
                    MiscCountyTax = table.Column<bool>(type: "bit", nullable: false),
                    MiscCityTax = table.Column<bool>(type: "bit", nullable: false),
                    MiscLocalTax = table.Column<bool>(type: "bit", nullable: false),
                    RentalStateTax = table.Column<bool>(type: "bit", nullable: false),
                    RentalCountyTax = table.Column<bool>(type: "bit", nullable: false),
                    RentalCityTax = table.Column<bool>(type: "bit", nullable: false),
                    RentalLocalTax = table.Column<bool>(type: "bit", nullable: false),
                    EqStateTax = table.Column<bool>(type: "bit", nullable: false),
                    EqCountyTax = table.Column<bool>(type: "bit", nullable: false),
                    EqCityTax = table.Column<bool>(type: "bit", nullable: false),
                    EqLocalTax = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiscMarkup = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExcludeCredit = table.Column<bool>(type: "bit", nullable: false),
                    SubTotalType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TravelTime = table.Column<bool>(type: "bit", nullable: false),
                    LostTime = table.Column<bool>(type: "bit", nullable: false),
                    DefaultTaxCodesParts = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesPartsDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesLabor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesLaborDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesMisc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesMiscDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesRental = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesRentalDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesEquip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesEquipDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleCodesEQMake",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    Dept = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EquipmentCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCodesEQMake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleCodesEquipment",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<short>(type: "smallint", nullable: false),
                    Dept = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EquipmentCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCodesEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleCodesParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<short>(type: "smallint", nullable: false),
                    Dept = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartsCost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsDiscount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsList = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWholesale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWarranty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsInternal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsCostCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsDiscountCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsListCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWholesaleCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsWarrantyCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsInternalCOG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCodesParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WIP = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentITD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentITDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    YTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxLastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsLastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborLastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscLastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalLastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentLastYTD = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    YTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsLastYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborLastYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MiscLastYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentalLastYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    EquipmentLastYTDCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastSale = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastSaleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastInvoice = table.Column<int>(type: "int", nullable: true),
                    LastYTDRoll = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastYTDRollBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastPaymentAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salesman",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeNo = table.Column<int>(type: "int", nullable: true),
                    SalesGroup = table.Column<short>(type: "smallint", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesman", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesmanCommission",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesmanCommission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxAccounts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxIntegration",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    SalesTaxProvider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServiceURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequestTimeout = table.Column<int>(type: "int", nullable: false),
                    DisableAddressVerification = table.Column<bool>(type: "bit", nullable: true),
                    DisableDocumentRecording = table.Column<bool>(type: "bit", nullable: true),
                    EnableLogging = table.Column<bool>(type: "bit", nullable: true),
                    EnableAvataxUPC = table.Column<bool>(type: "bit", nullable: true),
                    DefaultTaxCodesParts = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesPartsDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesLabor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesLaborDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesMisc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesMiscDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesRental = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesRentalDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DefaultTaxCodesEquip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultTaxCodesEquipDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LastUpdatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultGLTaxAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxIntegration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecureDept",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SecureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecureBranchLimit = table.Column<short>(type: "smallint", nullable: false),
                    SecureDeptLimit = table.Column<short>(type: "smallint", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecureDept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecureWarehouse",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SecureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecureWarehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceClaim",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    DealerInvoiceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProcessedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerPO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RepairDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerParts = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerLabor = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerSublet = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerFreight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerMisc = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerSalesTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerTotal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedParts = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedLabor = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedSublet = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedFreight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedMisc = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedSalesTax = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedTotal = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BatchNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RepairReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdjustmentReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PendingInfo = table.Column<short>(type: "smallint", nullable: true),
                    AdjustmentsMade = table.Column<short>(type: "smallint", nullable: true),
                    ReturnReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnCode1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ResubmittedDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResbComments = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Exported = table.Column<short>(type: "smallint", nullable: true),
                    CustomerExported = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceClaimRepairCode",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RepairCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceClaimRepairCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceClaimRepairType",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RepairType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceClaimRepairType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceClaimReturnCode",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ReturnCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceClaimReturnCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePriorities",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ServicePriority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServicePriorityDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceVanReplenishment",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromWarehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NeededQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ToAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplenishmentBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOnly = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToBinLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromBinLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVanReplenishment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceVanTemp",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FromWarehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NeededQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ToAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplenishmentBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOnly = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToBinLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromBinLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVanTemp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SecureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Param1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param5 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param6 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param7 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param8 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param9 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Param10 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipVia",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ShipVia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SortOrder = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipVia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopStatusTable",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ShopStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStatusTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMH",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartNoOriginal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MFGCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMHCross",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MasterNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMHCross", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snapper",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snapper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftbaseLicense",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    ComputerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MachineID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HDSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WhiteListed = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftbaseLicense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecStatus",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SpecStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprayerSystems",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprayerSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarLiftCross",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OEMCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NonToyotaPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToyotaPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarLiftCross", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateTaxCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxRateLabor = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PartsNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    LaborNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    MiscNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    RentalNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTaxCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stihl",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NewPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitofMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Markup = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PackageQty = table.Column<short>(type: "smallint", nullable: true),
                    ReturnCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UPCCodePackage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UPCCodeSingle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Changed = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stihl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyHeader",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Survey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valid = table.Column<short>(type: "smallint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Survey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuestionNo = table.Column<short>(type: "smallint", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Response = table.Column<short>(type: "smallint", nullable: true),
                    CheckResponses = table.Column<short>(type: "smallint", nullable: true),
                    Multiple = table.Column<short>(type: "smallint", nullable: true),
                    NextIfYes = table.Column<short>(type: "smallint", nullable: true),
                    NextIfNo = table.Column<short>(type: "smallint", nullable: true),
                    Check1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check9 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Check10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Survey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuestionNo = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Check1 = table.Column<short>(type: "smallint", nullable: true),
                    Check2 = table.Column<short>(type: "smallint", nullable: true),
                    Check3 = table.Column<short>(type: "smallint", nullable: true),
                    Check4 = table.Column<short>(type: "smallint", nullable: true),
                    Check5 = table.Column<short>(type: "smallint", nullable: true),
                    Check6 = table.Column<short>(type: "smallint", nullable: true),
                    Check7 = table.Column<short>(type: "smallint", nullable: true),
                    Check8 = table.Column<short>(type: "smallint", nullable: true),
                    Check9 = table.Column<short>(type: "smallint", nullable: true),
                    Check10 = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAnswered = table.Column<DateTime>(type: "datetime", nullable: true),
                    AnsweredBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SurveyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tailift",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tailift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tax",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartsNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    LaborNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    MiscNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    RentalNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    CountyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountyAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerOverride = table.Column<bool>(type: "bit", nullable: false),
                    AccountPaid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaylorDunn",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    NetItem = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaylorDunn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCM",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GroupCode = table.Column<short>(type: "smallint", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DealerPriceList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreCurrencyDealerPriceList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoWODash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCMSub",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OldPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NewPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCMSub", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecumseh",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangeCode = table.Column<short>(type: "smallint", nullable: true),
                    NewPart = table.Column<short>(type: "smallint", nullable: true),
                    AvailabilityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecumseh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TireTypes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TireType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toro",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NewPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsageCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TRPP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackageQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ValidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USRetail = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toyota",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Class = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AccessoryCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DealerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WholesalePrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QUP = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CoreCharge = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PreCurrencyDealerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyWholesalePrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyRetailPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ProductionStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductionEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toyota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToyotaSub",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChangeSequenceCount = table.Column<short>(type: "smallint", nullable: false),
                    ChangeSequenceTotal = table.Column<short>(type: "smallint", nullable: true),
                    NewPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubstitutionCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    QuantityPerAssy = table.Column<short>(type: "smallint", nullable: true),
                    PartNoWDash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NewPartNoWDash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyotaSub", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrailerCheckIn",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UniqueID = table.Column<int>(type: "int", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Disposition = table.Column<short>(type: "smallint", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryWho = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ResolutionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    Spot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    zSpotDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastChangedWho = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailerCheckIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrailerSpecs",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Width = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Height = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InternalHeight = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Composition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GVW = table.Column<int>(type: "int", nullable: true),
                    GVWR = table.Column<int>(type: "int", nullable: true),
                    PayloadCapacity = table.Column<int>(type: "int", nullable: true),
                    TypeofNeck = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumberofRearAxles = table.Column<int>(type: "int", nullable: true),
                    Doors = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Insulated = table.Column<bool>(type: "bit", nullable: true),
                    LiftGate = table.Column<bool>(type: "bit", nullable: true),
                    Suspension = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FloorType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tires = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Wheels = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AxleType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Skirts = table.Column<bool>(type: "bit", nullable: true),
                    SkirtType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReeferSerialNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReeferMake = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReeferModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailerSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrainingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trainer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrainingExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingType",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TrainingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<int>(type: "int", nullable: true),
                    Waypoint = table.Column<int>(type: "int", nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalContractNo = table.Column<int>(type: "int", nullable: true),
                    EquipmentSaleWONo = table.Column<int>(type: "int", nullable: true),
                    ServiceWONo = table.Column<int>(type: "int", nullable: true),
                    TransportChargeWONo = table.Column<int>(type: "int", nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    Dept = table.Column<short>(type: "smallint", nullable: true),
                    PublicComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledPickup = table.Column<DateTime>(type: "datetime", nullable: true),
                    ScheduledDelivery = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualPickup = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualDelivery = table.Column<DateTime>(type: "datetime", nullable: true),
                    EQPONo = table.Column<int>(type: "int", nullable: true),
                    OriginAtDealer = table.Column<int>(type: "int", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AllocatedHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    TinnacityShippingNo = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransHeader",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<int>(type: "int", nullable: false),
                    TruckNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OriginAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OriginCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OriginPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DestAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DestCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HaulerVendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HaulerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HaulerAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HaulerCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HaulerState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HaulerZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HaulerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HaulerPONo = table.Column<int>(type: "int", nullable: true),
                    PublicComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinnacityStatus = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransSignature",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    TrackingNo = table.Column<int>(type: "int", nullable: true),
                    SignatureType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateSigned = table.Column<DateTime>(type: "datetime", nullable: true),
                    Signature = table.Column<byte[]>(type: "image", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransSignature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrinDocsDetail",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TrinDocsID = table.Column<int>(type: "int", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentNo = table.Column<int>(type: "int", nullable: true),
                    BranchNo = table.Column<int>(type: "int", nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemNo = table.Column<int>(type: "int", nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    QTY = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExtendedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AmountEach = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TemplateType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinDocsDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrinDocsHeader",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    TrinDocsID = table.Column<int>(type: "int", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Approver = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentNo = table.Column<int>(type: "int", nullable: true),
                    APInvoiceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    JournalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Freight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ARInvoiceNo = table.Column<int>(type: "int", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Error = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinDocsHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TSHourMeter",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    hardware_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    serial_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gmt_datetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    hour_meter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSHourMeter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tusk",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NetPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CHCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsePartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreCurrencyNetPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCustomerPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReturnCodeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TuskUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tusk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVHCache",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    InquiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ItemPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Available = table.Column<int>(type: "int", nullable: true),
                    InquiryCount = table.Column<int>(type: "int", nullable: true),
                    SecureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVHCache", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailingAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailingCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailingState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailingZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WWWAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentCompanyNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseDays = table.Column<bool>(type: "bit", nullable: true),
                    DaysDue = table.Column<short>(type: "smallint", nullable: true),
                    UseDayOfMonth = table.Column<bool>(type: "bit", nullable: true),
                    DayOfMonthDue = table.Column<short>(type: "smallint", nullable: true),
                    Vendor1099 = table.Column<short>(type: "smallint", nullable: true),
                    FID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AllowDiscounts = table.Column<bool>(type: "bit", nullable: true),
                    DiscountDays = table.Column<short>(type: "smallint", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AllowDiscountDayOfMonth = table.Column<bool>(type: "bit", nullable: true),
                    DiscountDayOfMonth = table.Column<short>(type: "smallint", nullable: true),
                    DiscountPercentDayOfMonth = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountFreight = table.Column<short>(type: "smallint", nullable: true),
                    DiscountTax = table.Column<short>(type: "smallint", nullable: true),
                    LastInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastCheckDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    APAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpenseAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoleProprietor = table.Column<bool>(type: "bit", nullable: true),
                    SoleProprietorReported = table.Column<DateTime>(type: "datetime", nullable: true),
                    SSNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailingCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InsuranceNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsuranceNoDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsuranceNoRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VendorAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportToState = table.Column<short>(type: "smallint", nullable: true),
                    W9 = table.Column<bool>(type: "bit", nullable: true),
                    CheckMemo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorExpAccounts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpAccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorExpAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorImages",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    VendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InventoryAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FIFOInventory = table.Column<short>(type: "smallint", nullable: true),
                    ServiceVan = table.Column<short>(type: "smallint", nullable: true),
                    PickTickets = table.Column<short>(type: "smallint", nullable: true),
                    Supply1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supply2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supply3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supply4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supply5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Branch = table.Column<short>(type: "smallint", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reprice = table.Column<short>(type: "smallint", nullable: true),
                    Consignment = table.Column<short>(type: "smallint", nullable: true),
                    AverageCost = table.Column<short>(type: "smallint", nullable: true),
                    LandedAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyCodes",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebPartsOrder",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CustomerPONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequestedPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ImportFlag = table.Column<short>(type: "smallint", nullable: true),
                    EnteredBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImportedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImportedToWONo = table.Column<int>(type: "int", nullable: true),
                    ShipVia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UniqueField = table.Column<int>(type: "int", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPartsOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WO",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    Disposition = table.Column<short>(type: "smallint", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpBranch = table.Column<short>(type: "smallint", nullable: true),
                    ExpDept = table.Column<short>(type: "smallint", nullable: true),
                    ExpCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerSale = table.Column<bool>(type: "bit", nullable: true),
                    GuaranteedMaintenance = table.Column<bool>(type: "bit", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContinueWO = table.Column<bool>(type: "bit", nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Terms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipSubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salesman = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Technician = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Writer = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ReWorkTechnician = table.Column<int>(type: "int", nullable: true),
                    AssociatedWONo = table.Column<int>(type: "int", nullable: true),
                    ControlNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsRateDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PMDueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WarrantyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServiceVan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServiceZone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Authorized = table.Column<bool>(type: "bit", nullable: true),
                    ShopRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopSoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShopComments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShopAdditionalQuoteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopDelayComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopEstimatedCompletionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopEstimatedLaborHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShopMiscComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopQuoteAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShopQuoteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopQuoteHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShopRentalGiven = table.Column<bool>(type: "bit", nullable: true),
                    ShopRevisedCompletionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopSignedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MapLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalPeriod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    RentalEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OpenBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintCount = table.Column<short>(type: "smallint", nullable: true),
                    LastPrint = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastPrintedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipVia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FOB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastMechanic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastPartsDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastLaborDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastMiscDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastRentalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastEquipmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreditFlag = table.Column<short>(type: "smallint", nullable: true),
                    CreditAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreditDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreditBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditRequested = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AbsoluteTaxCodes = table.Column<bool>(type: "bit", nullable: true),
                    StateTaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountyTaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CityTaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountyTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PMName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HourMeterDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Dispatched = table.Column<bool>(type: "bit", nullable: true),
                    DispatchedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DispatchedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaperWorkComplete = table.Column<bool>(type: "bit", nullable: true),
                    PaperWorkDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CallDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvToCOG = table.Column<bool>(type: "bit", nullable: true),
                    InvToCOGInvoiceNo = table.Column<int>(type: "int", nullable: true),
                    RentalContractNo = table.Column<int>(type: "int", nullable: true),
                    FormOfPayment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FOPNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OdometerReading = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OdometerReadingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ScheduleDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ScheduleHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FOPExpiration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalTaxRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LocalTaxAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrivateComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BuildPartNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuildWarehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuildQuantity = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UtilizationDays = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FirstTimeCompletion = table.Column<bool>(type: "bit", nullable: true),
                    DispatchStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DispatchCheckin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinancedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReDispatched = table.Column<bool>(type: "bit", nullable: true),
                    ReDispatchedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReDispatchedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OnSite = table.Column<bool>(type: "bit", nullable: true),
                    NumeroDeFactura = table.Column<int>(type: "int", nullable: true),
                    RONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuoteType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reversed = table.Column<bool>(type: "bit", nullable: true),
                    ReplaceInvoiceComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<short>(type: "smallint", nullable: true),
                    OriginalWONo = table.Column<int>(type: "int", nullable: true),
                    Abuse = table.Column<bool>(type: "bit", nullable: true),
                    LaborDiscount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TrackingNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuthorizedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModelYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShopQuoteDeclinedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopInboundDroppedOff = table.Column<bool>(type: "bit", nullable: true),
                    ShopInboundPickedUp = table.Column<bool>(type: "bit", nullable: true),
                    ShopOutboundDroppedOff = table.Column<bool>(type: "bit", nullable: true),
                    ShopOutboundPickedUp = table.Column<bool>(type: "bit", nullable: true),
                    ShopDateIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopWorkStarted = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopApprovedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateTaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountyTaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CityTaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LocalTaxRateRental = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateTaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CountyTaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CityTaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LocalTaxRateEquip = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RepSite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FedExExport = table.Column<short>(type: "smallint", nullable: true),
                    FedExExported = table.Column<short>(type: "smallint", nullable: true),
                    DispatchTag = table.Column<bool>(type: "bit", nullable: true),
                    MobileRecommended = table.Column<string>(type: "text", nullable: true),
                    EmailCount = table.Column<int>(type: "int", nullable: true),
                    LastEmail = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastEmailedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FOPCVV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AltCustomerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServicePriority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountingNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DispatchPriority = table.Column<int>(type: "int", nullable: true),
                    StateTaxRateLabor = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShipEmailAddress = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    NoCC = table.Column<bool>(type: "bit", nullable: true),
                    QuoteHoldParts = table.Column<int>(type: "int", nullable: true),
                    eRentNo = table.Column<long>(type: "bigint", nullable: true),
                    zShopPartsOrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zShopPartsRecvDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zShopPartsHoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zSpotDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zShopEqptHoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zShopUnitHoldDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zShopWorkSuspended = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOArrival",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    DispatchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Altitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Heading = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Speed = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TravelFlag = table.Column<bool>(type: "bit", nullable: true),
                    LostTimeFlag = table.Column<bool>(type: "bit", nullable: true),
                    DepartureLatitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DepartureLongitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DepartureAltitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DepartureHeading = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DepartureSpeed = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OriginalArrivalDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    OriginalDepartureDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImportFlag = table.Column<bool>(type: "bit", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    LaborTypeROP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOArrival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOEq",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Disposition = table.Column<short>(type: "smallint", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    Transfer = table.Column<bool>(type: "bit", nullable: true),
                    TransferWONoFrom = table.Column<int>(type: "int", nullable: true),
                    TransferWONoTo = table.Column<int>(type: "int", nullable: true),
                    TransferBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoPrint = table.Column<bool>(type: "bit", nullable: true),
                    StateTax = table.Column<bool>(type: "bit", nullable: true),
                    CountyTax = table.Column<bool>(type: "bit", nullable: true),
                    CityTax = table.Column<bool>(type: "bit", nullable: true),
                    LocalTax = table.Column<bool>(type: "bit", nullable: true),
                    CustomerPOLineNo = table.Column<short>(type: "smallint", nullable: true),
                    WIPAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOEq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOInspection",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    InspectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Page = table.Column<int>(type: "int", nullable: true),
                    Question01 = table.Column<bool>(type: "bit", nullable: true),
                    Question02 = table.Column<bool>(type: "bit", nullable: true),
                    Question03 = table.Column<bool>(type: "bit", nullable: true),
                    Question04 = table.Column<bool>(type: "bit", nullable: true),
                    Question05 = table.Column<bool>(type: "bit", nullable: true),
                    Question06 = table.Column<bool>(type: "bit", nullable: true),
                    Question07 = table.Column<bool>(type: "bit", nullable: true),
                    Question08 = table.Column<bool>(type: "bit", nullable: true),
                    Question09 = table.Column<bool>(type: "bit", nullable: true),
                    Question10 = table.Column<bool>(type: "bit", nullable: true),
                    Question11 = table.Column<bool>(type: "bit", nullable: true),
                    Question12 = table.Column<bool>(type: "bit", nullable: true),
                    Question13 = table.Column<bool>(type: "bit", nullable: true),
                    Question14 = table.Column<bool>(type: "bit", nullable: true),
                    Question15 = table.Column<bool>(type: "bit", nullable: true),
                    Question16 = table.Column<bool>(type: "bit", nullable: true),
                    Question17 = table.Column<bool>(type: "bit", nullable: true),
                    Question18 = table.Column<bool>(type: "bit", nullable: true),
                    Question19 = table.Column<bool>(type: "bit", nullable: true),
                    Question20 = table.Column<bool>(type: "bit", nullable: true),
                    Question21 = table.Column<bool>(type: "bit", nullable: true),
                    Question22 = table.Column<bool>(type: "bit", nullable: true),
                    Question23 = table.Column<bool>(type: "bit", nullable: true),
                    Question24 = table.Column<bool>(type: "bit", nullable: true),
                    Question25 = table.Column<bool>(type: "bit", nullable: true),
                    Question26 = table.Column<bool>(type: "bit", nullable: true),
                    Question27 = table.Column<bool>(type: "bit", nullable: true),
                    Question28 = table.Column<bool>(type: "bit", nullable: true),
                    Question29 = table.Column<bool>(type: "bit", nullable: true),
                    Question30 = table.Column<bool>(type: "bit", nullable: true),
                    Question31 = table.Column<bool>(type: "bit", nullable: true),
                    Question32 = table.Column<bool>(type: "bit", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    QuestionFail01 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail02 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail03 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail04 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail05 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail06 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail07 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail08 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail09 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail10 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail11 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail12 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail13 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail14 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail15 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail16 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail17 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail18 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail19 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail20 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail21 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail22 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail23 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail24 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail25 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail26 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail27 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail28 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail29 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail30 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail31 = table.Column<bool>(type: "bit", nullable: true),
                    QuestionFail32 = table.Column<bool>(type: "bit", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOInspection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOInspectionQuestion",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OK = table.Column<int>(type: "int", nullable: true),
                    Potential = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Urgent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOInspectionQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOInspectionSetup",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    InspectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Page = table.Column<int>(type: "int", nullable: true),
                    Question01 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question02 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question03 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question04 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question05 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question06 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question07 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question08 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question09 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question11 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question12 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question13 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question14 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question15 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question16 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question17 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question18 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question19 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question20 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question21 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question22 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question23 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question24 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question25 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question26 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question27 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question28 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question29 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question30 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question31 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Question32 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Indent01 = table.Column<bool>(type: "bit", nullable: true),
                    Indent02 = table.Column<bool>(type: "bit", nullable: true),
                    Indent03 = table.Column<bool>(type: "bit", nullable: true),
                    Indent04 = table.Column<bool>(type: "bit", nullable: true),
                    Indent05 = table.Column<bool>(type: "bit", nullable: true),
                    Indent06 = table.Column<bool>(type: "bit", nullable: true),
                    Indent07 = table.Column<bool>(type: "bit", nullable: true),
                    Indent08 = table.Column<bool>(type: "bit", nullable: true),
                    Indent09 = table.Column<bool>(type: "bit", nullable: true),
                    Indent10 = table.Column<bool>(type: "bit", nullable: true),
                    Indent11 = table.Column<bool>(type: "bit", nullable: true),
                    Indent12 = table.Column<bool>(type: "bit", nullable: true),
                    Indent13 = table.Column<bool>(type: "bit", nullable: true),
                    Indent14 = table.Column<bool>(type: "bit", nullable: true),
                    Indent15 = table.Column<bool>(type: "bit", nullable: true),
                    Indent16 = table.Column<bool>(type: "bit", nullable: true),
                    Indent17 = table.Column<bool>(type: "bit", nullable: true),
                    Indent18 = table.Column<bool>(type: "bit", nullable: true),
                    Indent19 = table.Column<bool>(type: "bit", nullable: true),
                    Indent20 = table.Column<bool>(type: "bit", nullable: true),
                    Indent21 = table.Column<bool>(type: "bit", nullable: true),
                    Indent22 = table.Column<bool>(type: "bit", nullable: true),
                    Indent23 = table.Column<bool>(type: "bit", nullable: true),
                    Indent24 = table.Column<bool>(type: "bit", nullable: true),
                    Indent25 = table.Column<bool>(type: "bit", nullable: true),
                    Indent26 = table.Column<bool>(type: "bit", nullable: true),
                    Indent27 = table.Column<bool>(type: "bit", nullable: true),
                    Indent28 = table.Column<bool>(type: "bit", nullable: true),
                    Indent29 = table.Column<bool>(type: "bit", nullable: true),
                    Indent30 = table.Column<bool>(type: "bit", nullable: true),
                    Indent31 = table.Column<bool>(type: "bit", nullable: true),
                    Indent32 = table.Column<bool>(type: "bit", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOInspectionSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOLabor",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfLabor = table.Column<DateTime>(type: "datetime", nullable: true),
                    MechanicNo = table.Column<int>(type: "int", nullable: true),
                    MechanicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborRateType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SellRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Transfer = table.Column<bool>(type: "bit", nullable: true),
                    TransferWONoFrom = table.Column<int>(type: "int", nullable: true),
                    TransferWONoTo = table.Column<int>(type: "int", nullable: true),
                    TransferBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StateTax = table.Column<bool>(type: "bit", nullable: true),
                    CountyTax = table.Column<bool>(type: "bit", nullable: true),
                    CityTax = table.Column<bool>(type: "bit", nullable: true),
                    LocalTax = table.Column<bool>(type: "bit", nullable: true),
                    CustomerPOLineNo = table.Column<short>(type: "smallint", nullable: true),
                    WIPAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SectionNo = table.Column<short>(type: "smallint", nullable: true),
                    FedExCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdditionalDescription = table.Column<string>(type: "text", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOLabor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOLaborRemoved",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RemovedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfLabor = table.Column<DateTime>(type: "datetime", nullable: true),
                    MechanicNo = table.Column<int>(type: "int", nullable: true),
                    MechanicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LaborRateType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SellRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOLaborRemoved", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOLock",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    EmployeeNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LockDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOLock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOMisc",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Transfer = table.Column<bool>(type: "bit", nullable: true),
                    TransferWONoFrom = table.Column<int>(type: "int", nullable: true),
                    TransferWONoTo = table.Column<int>(type: "int", nullable: true),
                    TransferBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    GMSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GMHourMeter = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    InvVendorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OnOrder = table.Column<bool>(type: "bit", nullable: true),
                    PONo = table.Column<long>(type: "bigint", nullable: true),
                    StateTax = table.Column<bool>(type: "bit", nullable: true),
                    CountyTax = table.Column<bool>(type: "bit", nullable: true),
                    CityTax = table.Column<bool>(type: "bit", nullable: true),
                    LocalTax = table.Column<bool>(type: "bit", nullable: true),
                    CustomerPOLineNo = table.Column<int>(type: "int", nullable: true),
                    AdditionalChargesFlag = table.Column<bool>(type: "bit", nullable: true),
                    WIPAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SectionNo = table.Column<int>(type: "int", nullable: true),
                    AdditionalDescription = table.Column<string>(type: "text", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    NoPrint = table.Column<bool>(type: "bit", nullable: true),
                    RentalReoccur = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOMisc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOMiscRemoved",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RemovedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOMiscRemoved", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOParts",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Intructions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNoAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShipQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PickQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BOQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OrderQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OrderNo = table.Column<long>(type: "bigint", nullable: true),
                    InitQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NoDemand = table.Column<bool>(type: "bit", nullable: true),
                    Priority = table.Column<short>(type: "smallint", nullable: true),
                    CostRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SellRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ListRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BOStatus = table.Column<short>(type: "smallint", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Transfer = table.Column<bool>(type: "bit", nullable: true),
                    TransferWONoFrom = table.Column<int>(type: "int", nullable: true),
                    TransferWONoTo = table.Column<int>(type: "int", nullable: true),
                    TransferBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LandedCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LandedAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoPrint = table.Column<bool>(type: "bit", nullable: true),
                    BrokerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomsNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ReferenceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateTax = table.Column<bool>(type: "bit", nullable: true),
                    CountyTax = table.Column<bool>(type: "bit", nullable: true),
                    CityTax = table.Column<bool>(type: "bit", nullable: true),
                    LocalTax = table.Column<bool>(type: "bit", nullable: true),
                    QuoteDeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerPOLineNo = table.Column<short>(type: "smallint", nullable: true),
                    WIPAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BackorderCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    BackorderCostNoUpdate = table.Column<bool>(type: "bit", nullable: true),
                    PreferredVendor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorAliasNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SectionNo = table.Column<short>(type: "smallint", nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOPartsHold",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    QuoteWONo = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FrenchDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PartNoAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NoDemand = table.Column<int>(type: "int", nullable: true),
                    SellRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NoPrint = table.Column<int>(type: "int", nullable: true),
                    CustomerPOLineNo = table.Column<int>(type: "int", nullable: true),
                    PreferredVendor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Selected = table.Column<int>(type: "int", nullable: true),
                    Imported = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOPartsHold", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOPartsRemoved",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RemovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Warehouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PartsGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ShipQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InitQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CostRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SellRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOPartsRemoved", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOPartsSerialNo",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOPartsSerialNo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOPrint",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    EmployeeNo = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    BillTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MapLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PMDueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOPrint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOPrintFormat",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dept = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Item = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: true),
                    PositionY = table.Column<int>(type: "int", nullable: true),
                    CustomerFormat = table.Column<short>(type: "smallint", nullable: true),
                    InternalFormat = table.Column<short>(type: "smallint", nullable: true),
                    SetupLabel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FontSize = table.Column<short>(type: "smallint", nullable: true),
                    FontName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FontBold = table.Column<short>(type: "smallint", nullable: true),
                    FontItalic = table.Column<short>(type: "smallint", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOPrintFormat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOQuote",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: false),
                    SaleDept = table.Column<short>(type: "smallint", nullable: false),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuoteLine = table.Column<short>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<short>(type: "smallint", nullable: true),
                    Print = table.Column<short>(type: "smallint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StateTax = table.Column<short>(type: "smallint", nullable: true),
                    CountyTax = table.Column<short>(type: "smallint", nullable: true),
                    CityTax = table.Column<short>(type: "smallint", nullable: true),
                    LocalTax = table.Column<short>(type: "smallint", nullable: true),
                    QuoteText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoursAllowed = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RepairCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOQuote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WORental",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sell = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Disposition = table.Column<short>(type: "smallint", nullable: true),
                    SaleBranch = table.Column<short>(type: "smallint", nullable: true),
                    SaleDept = table.Column<short>(type: "smallint", nullable: true),
                    SaleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Taxable = table.Column<bool>(type: "bit", nullable: true),
                    Transfer = table.Column<bool>(type: "bit", nullable: true),
                    TransferWONoFrom = table.Column<int>(type: "int", nullable: true),
                    TransferWONoTo = table.Column<int>(type: "int", nullable: true),
                    TransferBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    HourMeter = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    StateTax = table.Column<bool>(type: "bit", nullable: true),
                    CountyTax = table.Column<bool>(type: "bit", nullable: true),
                    CityTax = table.Column<bool>(type: "bit", nullable: true),
                    LocalTax = table.Column<bool>(type: "bit", nullable: true),
                    NoPrint = table.Column<bool>(type: "bit", nullable: true),
                    CustomerPOLineNo = table.Column<short>(type: "smallint", nullable: true),
                    PeriodsBilled = table.Column<short>(type: "smallint", nullable: true),
                    ShowPeriodsBilled = table.Column<bool>(type: "bit", nullable: true),
                    DayRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WeekRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FourWeekRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MonthRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QuarterRent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    SwapOutStatus = table.Column<short>(type: "smallint", nullable: true),
                    SwapStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SwapEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORental", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOReplicate",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONoSource = table.Column<int>(type: "int", nullable: true),
                    DispositionSource = table.Column<int>(type: "int", nullable: true),
                    WONoDestination = table.Column<int>(type: "int", nullable: true),
                    ReplicatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOReplicate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOSection",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: false),
                    SectionNo = table.Column<short>(type: "smallint", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SectionDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOSignatures",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    WONo = table.Column<int>(type: "int", nullable: true),
                    SignatureType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SignedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateSigned = table.Column<DateTime>(type: "datetime", nullable: true),
                    Signature = table.Column<byte[]>(type: "image", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOSignatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yale",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    List = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyCost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PreCurrencyList = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    County = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Branch = table.Column<bool>(type: "bit", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Group1 = table.Column<bool>(type: "bit", nullable: true),
                    Group2 = table.Column<bool>(type: "bit", nullable: true),
                    Group3 = table.Column<bool>(type: "bit", nullable: true),
                    Group4 = table.Column<bool>(type: "bit", nullable: true),
                    Group5 = table.Column<bool>(type: "bit", nullable: true),
                    Group6 = table.Column<bool>(type: "bit", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TimeZone = table.Column<bool>(type: "bit", nullable: true),
                    Elevation = table.Column<int>(type: "int", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMigrated = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "AdditionalCharges_TenantId_index",
                schema: "web",
                table: "AdditionalCharges",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_AdditionalCharges",
                schema: "web",
                table: "AdditionalCharges",
                columns: new[] { "Branch", "Dept", "MiscDescription", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AdminDeletedRecords_TenantId_index",
                schema: "web",
                table: "AdminDeletedRecords",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "AdTrack_TenantId_index",
                schema: "web",
                table: "AdTrack",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_AdTrack",
                schema: "web",
                table: "AdTrack",
                columns: new[] { "AdTitle", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AdTrackDef_TenantId_index",
                schema: "web",
                table: "AdTrackDef",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_AdTrackDef",
                schema: "web",
                table: "AdTrackDef",
                columns: new[] { "AdTitle", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Advance_TenantId_index",
                schema: "web",
                table: "Advance",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Advance",
                schema: "web",
                table: "Advance",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Allianz_TenantId_index",
                schema: "web",
                table: "Allianz",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Allianz",
                schema: "web",
                table: "Allianz",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APDetail_TenantId_index",
                schema: "web",
                table: "APDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "APImages_TenantId_index",
                schema: "web",
                table: "APImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "APPaymentType_TenantId_index",
                schema: "web",
                table: "APPaymentType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_APPaymentType",
                schema: "web",
                table: "APPaymentType",
                columns: new[] { "PaymentType", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APRepeat_TenantId_index",
                schema: "web",
                table: "APRepeat",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_APRepeat",
                schema: "web",
                table: "APRepeat",
                columns: new[] { "VendorNo", "APInvoiceNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APRepeatDetail_TenantId_index",
                schema: "web",
                table: "APRepeatDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "APVoucher_TenantId_index",
                schema: "web",
                table: "APVoucher",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_APVoucher",
                schema: "web",
                table: "APVoucher",
                columns: new[] { "Journal", "APInvoiceNo", "VendorNo", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APVoucherDetail_TenantId_index",
                schema: "web",
                table: "APVoucherDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ARDetail_TenantId_index",
                schema: "web",
                table: "ARDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Ariens_TenantId_index",
                schema: "web",
                table: "Ariens",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Ariens",
                schema: "web",
                table: "Ariens",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ARImages_TenantId_index",
                schema: "web",
                table: "ARImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ARImagesDeleted_TenantId_index",
                schema: "web",
                table: "ARImagesDeleted",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ARTerms_TenantId_index",
                schema: "web",
                table: "ARTerms",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ARTerms",
                schema: "web",
                table: "ARTerms",
                columns: new[] { "Terms", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Barrett_TenantId_index",
                schema: "web",
                table: "Barrett",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Barrett",
                schema: "web",
                table: "Barrett",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BebQuotes_TenantId_index",
                schema: "web",
                table: "BebQuotes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "BigJoe_TenantId_index",
                schema: "web",
                table: "BigJoe",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_BigJoe",
                schema: "web",
                table: "BigJoe",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Bobcat_TenantId_index",
                schema: "web",
                table: "Bobcat",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Bobcat",
                schema: "web",
                table: "Bobcat",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Boss_TenantId_index",
                schema: "web",
                table: "Boss",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Boss",
                schema: "web",
                table: "Boss",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Branch_TenantId_index",
                schema: "web",
                table: "Branch",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Branch",
                schema: "web",
                table: "Branch",
                columns: new[] { "Number", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BranchARCurrency_TenantId_index",
                schema: "web",
                table: "BranchARCurrency",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_BranchARCurrency",
                schema: "web",
                table: "BranchARCurrency",
                columns: new[] { "Branch", "CurrencyType", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Briggs_TenantId_index",
                schema: "web",
                table: "Briggs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Briggs",
                schema: "web",
                table: "Briggs",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BTPrimeMover_TenantId_index",
                schema: "web",
                table: "BTPrimeMover",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_BTPrimeMover",
                schema: "web",
                table: "BTPrimeMover",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BusinessCategory_TenantId_index",
                schema: "web",
                table: "BusinessCategory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_BusinessCategory",
                schema: "web",
                table: "BusinessCategory",
                columns: new[] { "Category", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CallReports_TenantId_index",
                schema: "web",
                table: "CallReports",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "CascadeParts_TenantId_index",
                schema: "web",
                table: "CascadeParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CascadeParts",
                schema: "web",
                table: "CascadeParts",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CCTransactions_TenantId_index",
                schema: "web",
                table: "CCTransactions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ChartOfAccounts_TenantId_index",
                schema: "web",
                table: "ChartOfAccounts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ChartOfAccounts",
                schema: "web",
                table: "ChartOfAccounts",
                columns: new[] { "AccountNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CheckData_TenantId_index",
                schema: "web",
                table: "CheckData",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CheckData",
                schema: "web",
                table: "CheckData",
                columns: new[] { "CheckNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CheckDataTemp_TenantId_index",
                schema: "web",
                table: "CheckDataTemp",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "CheckDetail_TenantId_index",
                schema: "web",
                table: "CheckDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CheckDetail",
                schema: "web",
                table: "CheckDetail",
                columns: new[] { "CheckNo", "AccountNo", "VendorNo", "APInvoiceNo", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CheckDetailTemp_TenantId_index",
                schema: "web",
                table: "CheckDetailTemp",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "CheckFormat_TenantId_index",
                schema: "web",
                table: "CheckFormat",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CheckFormat",
                schema: "web",
                table: "CheckFormat",
                columns: new[] { "FormatName", "ElementName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CityTaxCodes_TenantId_index",
                schema: "web",
                table: "CityTaxCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CityTaxCodes",
                schema: "web",
                table: "CityTaxCodes",
                columns: new[] { "TaxCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Clark_TenantId_index",
                schema: "web",
                table: "Clark",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Clark",
                schema: "web",
                table: "Clark",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CommentTemplate_TenantId_index",
                schema: "web",
                table: "CommentTemplate",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CommentTemplate",
                schema: "web",
                table: "CommentTemplate",
                columns: new[] { "Template", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Company_TenantId_index",
                schema: "web",
                table: "Company",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Company",
                schema: "web",
                table: "Company",
                columns: new[] { "Number", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ComplaintCodes_TenantId_index",
                schema: "web",
                table: "ComplaintCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ComplaintCodes",
                schema: "web",
                table: "ComplaintCodes",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ComponentCodes_TenantId_index",
                schema: "web",
                table: "ComponentCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ComponentCodes",
                schema: "web",
                table: "ComponentCodes",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ContactMailing_TenantId_index",
                schema: "web",
                table: "ContactMailing",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ContactMailing",
                schema: "web",
                table: "ContactMailing",
                columns: new[] { "CustomerNo", "Contact", "Category", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Contacts_TenantId_index",
                schema: "web",
                table: "Contacts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "CountyTaxCodes_TenantId_index",
                schema: "web",
                table: "CountyTaxCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CountyTaxCodes",
                schema: "web",
                table: "CountyTaxCodes",
                columns: new[] { "TaxCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Crown_TenantId_index",
                schema: "web",
                table: "Crown",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Crown",
                schema: "web",
                table: "Crown",
                columns: new[] { "PartNo", "SpecialQty", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CurrencyHistory_TenantId_index",
                schema: "web",
                table: "CurrencyHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CurrencyHistory",
                schema: "web",
                table: "CurrencyHistory",
                columns: new[] { "CurrencyType", "CurrencyDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CurrencyTypes_TenantId_index",
                schema: "web",
                table: "CurrencyTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CurrencyTypes",
                schema: "web",
                table: "CurrencyTypes",
                columns: new[] { "CurrencyType", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Cushman_TenantId_index",
                schema: "web",
                table: "Cushman",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Cushman",
                schema: "web",
                table: "Cushman",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Customer_TenantId_index",
                schema: "web",
                table: "Customer",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Customer",
                schema: "web",
                table: "Customer",
                columns: new[] { "Number", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CustomerImages_TenantId_index",
                schema: "web",
                table: "CustomerImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "CustomerPartsPrice_TenantId_index",
                schema: "web",
                table: "CustomerPartsPrice",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_CustomerPartsPrice",
                schema: "web",
                table: "CustomerPartsPrice",
                columns: new[] { "CustomerNo", "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CustomerPO_TenantId_index",
                schema: "web",
                table: "CustomerPO",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Daewoo_TenantId_index",
                schema: "web",
                table: "Daewoo",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Daewoo",
                schema: "web",
                table: "Daewoo",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DeliveryNoLog_TenantId_index",
                schema: "web",
                table: "DeliveryNoLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_DeliveryNoLog",
                schema: "web",
                table: "DeliveryNoLog",
                columns: new[] { "DeliveryNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Depreciation_TenantId_index",
                schema: "web",
                table: "Depreciation",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Depreciation",
                schema: "web",
                table: "Depreciation",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Dept_TenantId_index",
                schema: "web",
                table: "Dept",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_DeptNews",
                schema: "web",
                table: "Dept",
                columns: new[] { "Branch", "Dept", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DispatchNames_TenantId_index",
                schema: "web",
                table: "DispatchNames",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_DispatchNames",
                schema: "web",
                table: "DispatchNames",
                columns: new[] { "SecureName", "DispatchName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DispatchPriority_TenantId_index",
                schema: "web",
                table: "DispatchPriority",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_DispatchPriority",
                schema: "web",
                table: "DispatchPriority",
                columns: new[] { "Priority", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DispatchSecondary_TenantId_index",
                schema: "web",
                table: "DispatchSecondary",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "DispatchStatusTable_TenantId_index",
                schema: "web",
                table: "DispatchStatusTable",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_DispatchStatusTable",
                schema: "web",
                table: "DispatchStatusTable",
                columns: new[] { "DispatchStatus", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Dixon_TenantId_index",
                schema: "web",
                table: "Dixon",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Dixon",
                schema: "web",
                table: "Dixon",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EFTData_TenantId_index",
                schema: "web",
                table: "EFTData",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EFTData",
                schema: "web",
                table: "EFTData",
                columns: new[] { "EFTNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EFTDetail_TenantId_index",
                schema: "web",
                table: "EFTDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EMailLog_TenantId_index",
                schema: "web",
                table: "EMailLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EMailLogError_TenantId_index",
                schema: "web",
                table: "EMailLogError",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "eParts_TenantId_index",
                schema: "web",
                table: "eParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_eParts",
                schema: "web",
                table: "eParts",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EQControlNoChange_TenantId_index",
                schema: "web",
                table: "EQControlNoChange",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EQControlNoChange",
                schema: "web",
                table: "EQControlNoChange",
                columns: new[] { "SerialNo", "ControlNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EQCustomFields_TenantId_index",
                schema: "web",
                table: "EQCustomFields",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EQCustomFields",
                schema: "web",
                table: "EQCustomFields",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EQCustomLabels_TenantId_index",
                schema: "web",
                table: "EQCustomLabels",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EQCustomLabels",
                schema: "web",
                table: "EQCustomLabels",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EquipLocationChange_TenantId_index",
                schema: "web",
                table: "EquipLocationChange",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EquipLocationChange",
                schema: "web",
                table: "EquipLocationChange",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Equipment_TenantId_index",
                schema: "web",
                table: "Equipment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Equipment",
                schema: "web",
                table: "Equipment",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EquipmentCost_TenantId_index",
                schema: "web",
                table: "EquipmentCost",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EquipmentCost",
                schema: "web",
                table: "EquipmentCost",
                columns: new[] { "SerialNo", "PONo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EquipmentHistory_TenantId_index",
                schema: "web",
                table: "EquipmentHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EquipmentImages_TenantId_index",
                schema: "web",
                table: "EquipmentImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EquipmentPODetail_TenantId_index",
                schema: "web",
                table: "EquipmentPODetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EquipmentRemoved_TenantId_index",
                schema: "web",
                table: "EquipmentRemoved",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EquipmentYTD_TenantId_index",
                schema: "web",
                table: "EquipmentYTD",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EquipmentYTD",
                schema: "web",
                table: "EquipmentYTD",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "eRentContactDetail_TenantId_index",
                schema: "web",
                table: "eRentContactDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "eRentEquipmentDetail_TenantId_index",
                schema: "web",
                table: "eRentEquipmentDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "eRentFeesDetail_TenantId_index",
                schema: "web",
                table: "eRentFeesDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "eRentReservation_TenantId_index",
                schema: "web",
                table: "eRentReservation",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EventLog_TenantId_index",
                schema: "web",
                table: "EventLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ExpCodes_TenantId_index",
                schema: "web",
                table: "ExpCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ExpCodes",
                schema: "web",
                table: "ExpCodes",
                columns: new[] { "Branch", "Dept", "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EZGo_TenantId_index",
                schema: "web",
                table: "EZGo",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_EZGo",
                schema: "web",
                table: "EZGo",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FactoryCat_TenantId_index",
                schema: "web",
                table: "FactoryCat",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_FactoryCat",
                schema: "web",
                table: "FactoryCat",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FedExCodes_TenantId_index",
                schema: "web",
                table: "FedExCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_FedExCodes",
                schema: "web",
                table: "FedExCodes",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FOB_TenantId_index",
                schema: "web",
                table: "FOB",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "FuelHistory_TenantId_index",
                schema: "web",
                table: "FuelHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_FuelHistory",
                schema: "web",
                table: "FuelHistory",
                columns: new[] { "SerialNo", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GL_TenantId_index",
                schema: "web",
                table: "GL",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GL",
                schema: "web",
                table: "GL",
                columns: new[] { "AccountNo", "AccountField", "Year", "Month", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GLDetail_TenantId_index",
                schema: "web",
                table: "GLDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "GLField_TenantId_index",
                schema: "web",
                table: "GLField",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GLField",
                schema: "web",
                table: "GLField",
                columns: new[] { "AccountField", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GLGroup_TenantId_index",
                schema: "web",
                table: "GLGroup",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GLGroup",
                schema: "web",
                table: "GLGroup",
                columns: new[] { "AccountField", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GLQuarter_TenantId_index",
                schema: "web",
                table: "GLQuarter",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GLQuarter",
                schema: "web",
                table: "GLQuarter",
                columns: new[] { "AccountNo", "AccountField", "Year", "Month", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GLSection_TenantId_index",
                schema: "web",
                table: "GLSection",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GLSection",
                schema: "web",
                table: "GLSection",
                columns: new[] { "Section", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Gravely_TenantId_index",
                schema: "web",
                table: "Gravely",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Gravely",
                schema: "web",
                table: "Gravely",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GroundPower_TenantId_index",
                schema: "web",
                table: "GroundPower",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GroundPower",
                schema: "web",
                table: "GroundPower",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "GroupTable_TenantId_index",
                schema: "web",
                table: "GroupTable",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_GroupTable",
                schema: "web",
                table: "GroupTable",
                columns: new[] { "PartsGroup", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Hamech_TenantId_index",
                schema: "web",
                table: "Hamech",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Hamech",
                schema: "web",
                table: "Hamech",
                columns: new[] { "PartNo", "SpecialQty", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Helmar_TenantId_index",
                schema: "web",
                table: "Helmar",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Helmar",
                schema: "web",
                table: "Helmar",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Henderson_TenantId_index",
                schema: "web",
                table: "Henderson",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Henderson",
                schema: "web",
                table: "Henderson",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Hiab_TenantId_index",
                schema: "web",
                table: "Hiab",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Hiab",
                schema: "web",
                table: "Hiab",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Honda_TenantId_index",
                schema: "web",
                table: "Honda",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Honda",
                schema: "web",
                table: "Honda",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Hyundai_TenantId_index",
                schema: "web",
                table: "Hyundai",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Hyundai",
                schema: "web",
                table: "Hyundai",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InspectionQuestion_TenantId_index",
                schema: "web",
                table: "InspectionQuestion",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InspectionQuestion",
                schema: "web",
                table: "InspectionQuestion",
                columns: new[] { "Name", "Section", "Question", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InternetLog_TenantId_index",
                schema: "web",
                table: "InternetLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InternetLog",
                schema: "web",
                table: "InternetLog",
                columns: new[] { "IPAddress", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Intrupa_TenantId_index",
                schema: "web",
                table: "Intrupa",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Intrupa",
                schema: "web",
                table: "Intrupa",
                columns: new[] { "OEM", "PartNo", "Occurrence", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InvCategory_TenantId_index",
                schema: "web",
                table: "InvCategory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "InvDetail_TenantId_index",
                schema: "web",
                table: "InvDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InvDetail",
                schema: "web",
                table: "InvDetail",
                columns: new[] { "InventoryID", "Warehouse", "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InvDetailBin_TenantId_index",
                schema: "web",
                table: "InvDetailBin",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InvDetailBin",
                schema: "web",
                table: "InvDetailBin",
                columns: new[] { "InventoryID", "Warehouse", "PartNo", "Bin", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InventoryCount_TenantId_index",
                schema: "web",
                table: "InventoryCount",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InventoryCount",
                schema: "web",
                table: "InventoryCount",
                columns: new[] { "InventoryID", "PartNo", "Warehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InvHeader_TenantId_index",
                schema: "web",
                table: "InvHeader",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InvHeader",
                schema: "web",
                table: "InvHeader",
                columns: new[] { "InventoryID", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InvoiceReg_TenantId_index",
                schema: "web",
                table: "InvoiceReg",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_InvoiceReg",
                schema: "web",
                table: "InvoiceReg",
                columns: new[] { "InvoiceNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ItemDescription_TenantId_index",
                schema: "web",
                table: "ItemDescription",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "JohnDeere_TenantId_index",
                schema: "web",
                table: "JohnDeere",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_JohnDeere",
                schema: "web",
                table: "JohnDeere",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "JournalDetail_TenantId_index",
                schema: "web",
                table: "JournalDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "JournalHeader_TenantId_index",
                schema: "web",
                table: "JournalHeader",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_JournalHeader",
                schema: "web",
                table: "JournalHeader",
                columns: new[] { "Journal", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Kohler_TenantId_index",
                schema: "web",
                table: "Kohler",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Kohler",
                schema: "web",
                table: "Kohler",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Komatsu_TenantId_index",
                schema: "web",
                table: "Komatsu",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Komatsu",
                schema: "web",
                table: "Komatsu",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Kubota_TenantId_index",
                schema: "web",
                table: "Kubota",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Kubota",
                schema: "web",
                table: "Kubota",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LaborQuote_TenantId_index",
                schema: "web",
                table: "LaborQuote",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_LaborQuote",
                schema: "web",
                table: "LaborQuote",
                columns: new[] { "Make", "ModelGroup", "RepairGroup", "RepairCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LaborQuoteGroup_TenantId_index",
                schema: "web",
                table: "LaborQuoteGroup",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_LaborQuoteGroup",
                schema: "web",
                table: "LaborQuoteGroup",
                columns: new[] { "RepairGroup", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LaborRate_TenantId_index",
                schema: "web",
                table: "LaborRate",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_LaborRate",
                schema: "web",
                table: "LaborRate",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Language_TenantId_index",
                schema: "web",
                table: "Language",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Language",
                schema: "web",
                table: "Language",
                columns: new[] { "ProgramName", "FormName", "FieldName", "FieldNo", "Language", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Linde_TenantId_index",
                schema: "web",
                table: "Linde",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Linde",
                schema: "web",
                table: "Linde",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LocalTaxCodes_TenantId_index",
                schema: "web",
                table: "LocalTaxCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_LocalTaxCodes",
                schema: "web",
                table: "LocalTaxCodes",
                columns: new[] { "TaxCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Location_TenantId_index",
                schema: "web",
                table: "Location",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Location",
                schema: "web",
                table: "Location",
                columns: new[] { "Location", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LPM_TenantId_index",
                schema: "web",
                table: "LPM",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_LPM",
                schema: "web",
                table: "LPM",
                columns: new[] { "OEM", "PartNo", "Occurrence", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LynxRite_TenantId_index",
                schema: "web",
                table: "LynxRite",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_LynxRite",
                schema: "web",
                table: "LynxRite",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MailingCategory_TenantId_index",
                schema: "web",
                table: "MailingCategory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_MailingCategory",
                schema: "web",
                table: "MailingCategory",
                columns: new[] { "Category", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Make_TenantId_index",
                schema: "web",
                table: "Make",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Make",
                schema: "web",
                table: "Make",
                columns: new[] { "Make", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MarketingSources_TenantId_index",
                schema: "web",
                table: "MarketingSources",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "MechanicImages_TenantId_index",
                schema: "web",
                table: "MechanicImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "MechanicLabor_TenantId_index",
                schema: "web",
                table: "MechanicLabor",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "MechanicLaborSignature_TenantId_index",
                schema: "web",
                table: "MechanicLaborSignature",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "MiscPODetail_TenantId_index",
                schema: "web",
                table: "MiscPODetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "MitCat_TenantId_index",
                schema: "web",
                table: "MitCat",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_MitCat",
                schema: "web",
                table: "MitCat",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MitCatReplacement_TenantId_index",
                schema: "web",
                table: "MitCatReplacement",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_MitCatReplacement",
                schema: "web",
                table: "MitCatReplacement",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MobileHourMeter_TenantId_index",
                schema: "web",
                table: "MobileHourMeter",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Model_TenantId_index",
                schema: "web",
                table: "Model",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Model",
                schema: "web",
                table: "Model",
                columns: new[] { "Model", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ModelGroup_TenantId_index",
                schema: "web",
                table: "ModelGroup",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ModelGroup",
                schema: "web",
                table: "ModelGroup",
                columns: new[] { "ModelGroup", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Moffett_TenantId_index",
                schema: "web",
                table: "Moffett",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Moffett",
                schema: "web",
                table: "Moffett",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NationalParts_TenantId_index",
                schema: "web",
                table: "NationalParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_NationalParts",
                schema: "web",
                table: "NationalParts",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Nissan_TenantId_index",
                schema: "web",
                table: "Nissan",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Nissan",
                schema: "web",
                table: "Nissan",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Orders_TenantId_index",
                schema: "web",
                table: "Orders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "OrdersFreight_TenantId_index",
                schema: "web",
                table: "OrdersFreight",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "OrdersRecv_TenantId_index",
                schema: "web",
                table: "OrdersRecv",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Ottawa_TenantId_index",
                schema: "web",
                table: "Ottawa",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Ottawa",
                schema: "web",
                table: "Ottawa",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Parker_TenantId_index",
                schema: "web",
                table: "Parker",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Parker",
                schema: "web",
                table: "Parker",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartNoAlias_TenantId_index",
                schema: "web",
                table: "PartNoAlias",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartNoAlias",
                schema: "web",
                table: "PartNoAlias",
                columns: new[] { "PartNo", "PartNoAlias", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Parts_TenantId_index",
                schema: "web",
                table: "Parts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PartsAltPricing_TenantId_index",
                schema: "web",
                table: "PartsAltPricing",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsAltPricing",
                schema: "web",
                table: "PartsAltPricing",
                columns: new[] { "CustomerNo", "PartsGroup", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsBinHistory_TenantId_index",
                schema: "web",
                table: "PartsBinHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsBinHistory",
                schema: "web",
                table: "PartsBinHistory",
                columns: new[] { "PartNo", "Warehouse", "CreationTime", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsBinTrips_TenantId_index",
                schema: "web",
                table: "PartsBinTrips",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsBinTrips",
                schema: "web",
                table: "PartsBinTrips",
                columns: new[] { "PartNo", "Warehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsCost_TenantId_index",
                schema: "web",
                table: "PartsCost",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsCost",
                schema: "web",
                table: "PartsCost",
                columns: new[] { "PartNo", "Warehouse", "CreationTime", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsCostChange_TenantId_index",
                schema: "web",
                table: "PartsCostChange",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsCostChange",
                schema: "web",
                table: "PartsCostChange",
                columns: new[] { "PartNo", "Warehouse", "CreationTime", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsCustAlias_TenantId_index",
                schema: "web",
                table: "PartsCustAlias",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsCustAlias",
                schema: "web",
                table: "PartsCustAlias",
                columns: new[] { "PartNo", "CustomerNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsDemand_TenantId_index",
                schema: "web",
                table: "PartsDemand",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsDemand",
                schema: "web",
                table: "PartsDemand",
                columns: new[] { "PartNo", "Warehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsImages_TenantId_index",
                schema: "web",
                table: "PartsImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PartsInquiryHistory_TenantId_index",
                schema: "web",
                table: "PartsInquiryHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PartsKit_TenantId_index",
                schema: "web",
                table: "PartsKit",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsKit",
                schema: "web",
                table: "PartsKit",
                columns: new[] { "KitNo", "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsLostSaleDetail_TenantId_index",
                schema: "web",
                table: "PartsLostSaleDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PartsLostSaleReason_TenantId_index",
                schema: "web",
                table: "PartsLostSaleReason",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsLostSaleReason",
                schema: "web",
                table: "PartsLostSaleReason",
                columns: new[] { "ReasonCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsLostSales_TenantId_index",
                schema: "web",
                table: "PartsLostSales",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsLostSales",
                schema: "web",
                table: "PartsLostSales",
                columns: new[] { "PartNo", "Warehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsOnHandChange_TenantId_index",
                schema: "web",
                table: "PartsOnHandChange",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsOnHandChange",
                schema: "web",
                table: "PartsOnHandChange",
                columns: new[] { "PartNo", "Warehouse", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsPriceFiles_TenantId_index",
                schema: "web",
                table: "PartsPriceFiles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsPriceFiles",
                schema: "web",
                table: "PartsPriceFiles",
                columns: new[] { "PartNo", "Supplier", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsSales_TenantId_index",
                schema: "web",
                table: "PartsSales",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsSales",
                schema: "web",
                table: "PartsSales",
                columns: new[] { "PartNo", "Warehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsSuppliers_TenantId_index",
                schema: "web",
                table: "PartsSuppliers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PartsTransfer_TenantId_index",
                schema: "web",
                table: "PartsTransfer",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsTransfer",
                schema: "web",
                table: "PartsTransfer",
                columns: new[] { "TransferDate", "PartNo", "FromWarehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsUserCross_TenantId_index",
                schema: "web",
                table: "PartsUserCross",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsUserCross",
                schema: "web",
                table: "PartsUserCross",
                columns: new[] { "PartNo", "MasterNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PartsVendorAlias_TenantId_index",
                schema: "web",
                table: "PartsVendorAlias",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PartsVendorAlias",
                schema: "web",
                table: "PartsVendorAlias",
                columns: new[] { "PartNo", "VendorNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Person_TenantId_index",
                schema: "web",
                table: "Person",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Person",
                schema: "web",
                table: "Person",
                columns: new[] { "Number", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PersonGroup_TenantId_index",
                schema: "web",
                table: "PersonGroup",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PM_TenantId_index",
                schema: "web",
                table: "PM",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PM",
                schema: "web",
                table: "PM",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PMName_TenantId_index",
                schema: "web",
                table: "PMName",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PMName",
                schema: "web",
                table: "PMName",
                columns: new[] { "PMName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PMParts_TenantId_index",
                schema: "web",
                table: "PMParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PMParts",
                schema: "web",
                table: "PMParts",
                columns: new[] { "SerialNo", "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PMSecondary_TenantId_index",
                schema: "web",
                table: "PMSecondary",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PMSecondary",
                schema: "web",
                table: "PMSecondary",
                columns: new[] { "SerialNo", "PMName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PMSignupHistory_TenantId_index",
                schema: "web",
                table: "PMSignupHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PMSignupHistory",
                schema: "web",
                table: "PMSignupHistory",
                columns: new[] { "SerialNo", "SignUpDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PMStatus_TenantId_index",
                schema: "web",
                table: "PMStatus",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PMStatus",
                schema: "web",
                table: "PMStatus",
                columns: new[] { "Status", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "POHeader_TenantId_index",
                schema: "web",
                table: "POHeader",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_POHeader",
                schema: "web",
                table: "POHeader",
                columns: new[] { "PONo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "POImages_TenantId_index",
                schema: "web",
                table: "POImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PORecent_TenantId_index",
                schema: "web",
                table: "PORecent",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "PowerBoss_TenantId_index",
                schema: "web",
                table: "PowerBoss",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PowerBoss",
                schema: "web",
                table: "PowerBoss",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PrimeMover_TenantId_index",
                schema: "web",
                table: "PrimeMover",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PrimeMover",
                schema: "web",
                table: "PrimeMover",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Princeton_TenantId_index",
                schema: "web",
                table: "Princeton",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Princeton",
                schema: "web",
                table: "Princeton",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PrinterSetup_TenantId_index",
                schema: "web",
                table: "PrinterSetup",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PrinterSetup",
                schema: "web",
                table: "PrinterSetup",
                columns: new[] { "EmployeeNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PrintInfoBar_TenantId_index",
                schema: "web",
                table: "PrintInfoBar",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_PrintInfoBar",
                schema: "web",
                table: "PrintInfoBar",
                columns: new[] { "Branch", "Dept", "FieldName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RapidParts_TenantId_index",
                schema: "web",
                table: "RapidParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_RapidParts",
                schema: "web",
                table: "RapidParts",
                columns: new[] { "OEMName", "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ReasonDelayCodes_TenantId_index",
                schema: "web",
                table: "ReasonDelayCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ReasonDelayCodes",
                schema: "web",
                table: "ReasonDelayCodes",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ReasonRepairCodes_TenantId_index",
                schema: "web",
                table: "ReasonRepairCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ReasonRepairCodes",
                schema: "web",
                table: "ReasonRepairCodes",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RecentCustomer_TenantId_index",
                schema: "web",
                table: "RecentCustomer",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "RentalContract_TenantId_index",
                schema: "web",
                table: "RentalContract",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_RentalContract",
                schema: "web",
                table: "RentalContract",
                columns: new[] { "RentalContractNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RentalContractLayout_TenantId_index",
                schema: "web",
                table: "RentalContractLayout",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_RentalContractLayout",
                schema: "web",
                table: "RentalContractLayout",
                columns: new[] { "TableName", "FieldName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RentalHistory_TenantId_index",
                schema: "web",
                table: "RentalHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_RentalHistory",
                schema: "web",
                table: "RentalHistory",
                columns: new[] { "SerialNo", "Year", "Month", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RentalImages_TenantId_index",
                schema: "web",
                table: "RentalImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "RentalRate_TenantId_index",
                schema: "web",
                table: "RentalRate",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_RentalRate",
                schema: "web",
                table: "RentalRate",
                columns: new[] { "RentalRateCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RepairCode_TenantId_index",
                schema: "web",
                table: "RepairCode",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_RepairCode",
                schema: "web",
                table: "RepairCode",
                columns: new[] { "RepairCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ReportDefinitions_TenantId_index",
                schema: "web",
                table: "ReportDefinitions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ReportGroups_TenantId_index",
                schema: "web",
                table: "ReportGroups",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ReportSecurity_TenantId_index",
                schema: "web",
                table: "ReportSecurity",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "ReportStyles_TenantId_index",
                schema: "web",
                table: "ReportStyles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "SaleCodes_TenantId_index",
                schema: "web",
                table: "SaleCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SaleCodes",
                schema: "web",
                table: "SaleCodes",
                columns: new[] { "Branch", "Dept", "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SaleCodesEQMake_TenantId_index",
                schema: "web",
                table: "SaleCodesEQMake",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SaleCodesEQMake",
                schema: "web",
                table: "SaleCodesEQMake",
                columns: new[] { "Branch", "Dept", "Code", "Make", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SaleCodesEquipment_TenantId_index",
                schema: "web",
                table: "SaleCodesEquipment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SaleCodesEquipment",
                schema: "web",
                table: "SaleCodesEquipment",
                columns: new[] { "Branch", "Dept", "Code", "ModelGroup", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SaleCodesParts_TenantId_index",
                schema: "web",
                table: "SaleCodesParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SaleCodesParts",
                schema: "web",
                table: "SaleCodesParts",
                columns: new[] { "Branch", "Dept", "Code", "PartsGroup", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Sales_TenantId_index",
                schema: "web",
                table: "Sales",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Sales",
                schema: "web",
                table: "Sales",
                columns: new[] { "CustomerNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Salesman_TenantId_index",
                schema: "web",
                table: "Salesman",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Salesman",
                schema: "web",
                table: "Salesman",
                columns: new[] { "Number", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SalesmanCommission_TenantId_index",
                schema: "web",
                table: "SalesmanCommission",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SalesmanCommission",
                schema: "web",
                table: "SalesmanCommission",
                columns: new[] { "Name", "AccountNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SalesTaxAccounts_TenantId_index",
                schema: "web",
                table: "SalesTaxAccounts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "SalesTaxIntegration_TenantId_index",
                schema: "web",
                table: "SalesTaxIntegration",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "SecureDept_TenantId_index",
                schema: "web",
                table: "SecureDept",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SecureDept",
                schema: "web",
                table: "SecureDept",
                columns: new[] { "SecureName", "SecureBranchLimit", "SecureDeptLimit", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SecureWarehouse_TenantId_index",
                schema: "web",
                table: "SecureWarehouse",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SecureWarehouse",
                schema: "web",
                table: "SecureWarehouse",
                columns: new[] { "SecureName", "Warehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceClaim_TenantId_index",
                schema: "web",
                table: "ServiceClaim",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServiceClaim",
                schema: "web",
                table: "ServiceClaim",
                columns: new[] { "DealerInvoiceNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceClaimRepairCode_TenantId_index",
                schema: "web",
                table: "ServiceClaimRepairCode",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServiceClaimRepairCode",
                schema: "web",
                table: "ServiceClaimRepairCode",
                columns: new[] { "RepairCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceClaimRepairType_TenantId_index",
                schema: "web",
                table: "ServiceClaimRepairType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServiceClaimRepairType",
                schema: "web",
                table: "ServiceClaimRepairType",
                columns: new[] { "RepairType", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceClaimReturnCode_TenantId_index",
                schema: "web",
                table: "ServiceClaimReturnCode",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServiceClaimReturnCode",
                schema: "web",
                table: "ServiceClaimReturnCode",
                columns: new[] { "ReturnCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServicePriorities_TenantId_index",
                schema: "web",
                table: "ServicePriorities",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServicePriorities",
                schema: "web",
                table: "ServicePriorities",
                columns: new[] { "ServicePriority", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceVanReplenishment_TenantId_index",
                schema: "web",
                table: "ServiceVanReplenishment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServiceVanReplenishment",
                schema: "web",
                table: "ServiceVanReplenishment",
                columns: new[] { "CreationTime", "PartNo", "Warehouse", "FromWarehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceVanTemp_TenantId_index",
                schema: "web",
                table: "ServiceVanTemp",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ServiceVanTemp",
                schema: "web",
                table: "ServiceVanTemp",
                columns: new[] { "CreationTime", "PartNo", "Warehouse", "FromWarehouse", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Settings_TenantId_index",
                schema: "web",
                table: "Settings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Settings",
                schema: "web",
                table: "Settings",
                columns: new[] { "SecureName", "ProgramName", "FormName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ShipVia_TenantId_index",
                schema: "web",
                table: "ShipVia",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ShipVia",
                schema: "web",
                table: "ShipVia",
                columns: new[] { "ShipVia", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ShopStatusTable_TenantId_index",
                schema: "web",
                table: "ShopStatusTable",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ShopStatusTable",
                schema: "web",
                table: "ShopStatusTable",
                columns: new[] { "ShopStatus", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SMH_TenantId_index",
                schema: "web",
                table: "SMH",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SMH",
                schema: "web",
                table: "SMH",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SMHCross_TenantId_index",
                schema: "web",
                table: "SMHCross",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SMHCross",
                schema: "web",
                table: "SMHCross",
                columns: new[] { "PartNo", "MasterNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Snapper_TenantId_index",
                schema: "web",
                table: "Snapper",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Snapper",
                schema: "web",
                table: "Snapper",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SoftbaseLicense_TenantId_index",
                schema: "web",
                table: "SoftbaseLicense",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "SpecStatus_TenantId_index",
                schema: "web",
                table: "SpecStatus",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SpecStatus",
                schema: "web",
                table: "SpecStatus",
                columns: new[] { "SpecStatus", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SprayerSystems_TenantId_index",
                schema: "web",
                table: "SprayerSystems",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SprayerSystems",
                schema: "web",
                table: "SprayerSystems",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StarLiftCross_TenantId_index",
                schema: "web",
                table: "StarLiftCross",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_StarLiftCross",
                schema: "web",
                table: "StarLiftCross",
                columns: new[] { "OEMCode", "NonToyotaPartNo", "ToyotaPartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StateTaxCodes_TenantId_index",
                schema: "web",
                table: "StateTaxCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_StateTaxCodes",
                schema: "web",
                table: "StateTaxCodes",
                columns: new[] { "TaxCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Stihl_TenantId_index",
                schema: "web",
                table: "Stihl",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Stihl",
                schema: "web",
                table: "Stihl",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SurveyHeader_TenantId_index",
                schema: "web",
                table: "SurveyHeader",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SurveyHeader",
                schema: "web",
                table: "SurveyHeader",
                columns: new[] { "Survey", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SurveyQuestion_TenantId_index",
                schema: "web",
                table: "SurveyQuestion",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SurveyQuestion",
                schema: "web",
                table: "SurveyQuestion",
                columns: new[] { "Survey", "QuestionNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SurveyResponse_TenantId_index",
                schema: "web",
                table: "SurveyResponse",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_SurveyResponse",
                schema: "web",
                table: "SurveyResponse",
                columns: new[] { "CustomerNo", "Survey", "SurveyDate", "QuestionNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Tailift_TenantId_index",
                schema: "web",
                table: "Tailift",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Tailift",
                schema: "web",
                table: "Tailift",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Tax_TenantId_index",
                schema: "web",
                table: "Tax",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Tax",
                schema: "web",
                table: "Tax",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TaylorDunn_TenantId_index",
                schema: "web",
                table: "TaylorDunn",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TaylorDunn",
                schema: "web",
                table: "TaylorDunn",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TCM_TenantId_index",
                schema: "web",
                table: "TCM",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TCM",
                schema: "web",
                table: "TCM",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TCMSub_TenantId_index",
                schema: "web",
                table: "TCMSub",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TCMSub",
                schema: "web",
                table: "TCMSub",
                columns: new[] { "OldPartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Tecumseh_TenantId_index",
                schema: "web",
                table: "Tecumseh",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Tecumseh",
                schema: "web",
                table: "Tecumseh",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TireTypes_TenantId_index",
                schema: "web",
                table: "TireTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TireTypes",
                schema: "web",
                table: "TireTypes",
                columns: new[] { "TireType", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Toro_TenantId_index",
                schema: "web",
                table: "Toro",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Toro",
                schema: "web",
                table: "Toro",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Toyota_TenantId_index",
                schema: "web",
                table: "Toyota",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Toyota",
                schema: "web",
                table: "Toyota",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ToyotaSub_TenantId_index",
                schema: "web",
                table: "ToyotaSub",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ToyotaSub",
                schema: "web",
                table: "ToyotaSub",
                columns: new[] { "PartNo", "ChangeSequenceCount", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TrailerCheckIn_TenantId_index",
                schema: "web",
                table: "TrailerCheckIn",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "TrailerSpecs_TenantId_index",
                schema: "web",
                table: "TrailerSpecs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TrailerSpecs",
                schema: "web",
                table: "TrailerSpecs",
                columns: new[] { "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Training_TenantId_index",
                schema: "web",
                table: "Training",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Training",
                schema: "web",
                table: "Training",
                columns: new[] { "CustomerNo", "Operator", "TrainingDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TrainingType_TenantId_index",
                schema: "web",
                table: "TrainingType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TrainingType",
                schema: "web",
                table: "TrainingType",
                columns: new[] { "TrainingType", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TransDetail_TenantId_index",
                schema: "web",
                table: "TransDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "TransHeader_TenantId_index",
                schema: "web",
                table: "TransHeader",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_TransHeader",
                schema: "web",
                table: "TransHeader",
                columns: new[] { "TrackingNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TransSignature_TenantId_index",
                schema: "web",
                table: "TransSignature",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "TrinDocsDetail_TenantId_index",
                schema: "web",
                table: "TrinDocsDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "TrinDocsHeader_TenantId_index",
                schema: "web",
                table: "TrinDocsHeader",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "TSHourMeter_TenantId_index",
                schema: "web",
                table: "TSHourMeter",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Tusk_TenantId_index",
                schema: "web",
                table: "Tusk",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "TVHCache_TenantId_index",
                schema: "web",
                table: "TVHCache",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Vendor_TenantId_index",
                schema: "web",
                table: "Vendor",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_VendorExpAccounts",
                schema: "web",
                table: "VendorExpAccounts",
                columns: new[] { "VendorNo", "ExpAccountNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "VendorExpAccounts_TenantId_index",
                schema: "web",
                table: "VendorExpAccounts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "VendorImages_TenantId_index",
                schema: "web",
                table: "VendorImages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "Warehouse_TenantId_index",
                schema: "web",
                table: "Warehouse",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WarrantyCodes_TenantId_index",
                schema: "web",
                table: "WarrantyCodes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WebPartsOrder_TenantId_index",
                schema: "web",
                table: "WebPartsOrder",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WO_TenantId_index",
                schema: "web",
                table: "WO",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOArrival_TenantId_index",
                schema: "web",
                table: "WOArrival",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOEq_TenantId_index",
                schema: "web",
                table: "WOEq",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOInspection_TenantId_index",
                schema: "web",
                table: "WOInspection",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_WOInspectionQuestion",
                schema: "web",
                table: "WOInspectionQuestion",
                columns: new[] { "WONo", "Name", "Section", "Question", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "WOInspectionQuestion_TenantId_index",
                schema: "web",
                table: "WOInspectionQuestion",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOInspectionSetup_TenantId_index",
                schema: "web",
                table: "WOInspectionSetup",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOLabor_TenantId_index",
                schema: "web",
                table: "WOLabor",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOLaborRemoved_TenantId_index",
                schema: "web",
                table: "WOLaborRemoved",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOLock_TenantId_index",
                schema: "web",
                table: "WOLock",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOMisc_TenantId_index",
                schema: "web",
                table: "WOMisc",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOMiscRemoved_TenantId_index",
                schema: "web",
                table: "WOMiscRemoved",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOParts_TenantId_index",
                schema: "web",
                table: "WOParts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOPartsHold_TenantId_index",
                schema: "web",
                table: "WOPartsHold",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOPartsRemoved_TenantId_index",
                schema: "web",
                table: "WOPartsRemoved",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_WOPartsSerialNo",
                schema: "web",
                table: "WOPartsSerialNo",
                columns: new[] { "WONo", "EntryDate", "SerialNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "WOPartsSerialNo_TenantId_index",
                schema: "web",
                table: "WOPartsSerialNo",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_WOPrint",
                schema: "web",
                table: "WOPrint",
                columns: new[] { "EmployeeNo", "WONo", "EntryDate", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "WOPrint_TenantId_index",
                schema: "web",
                table: "WOPrint",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_WOPrintFormat",
                schema: "web",
                table: "WOPrintFormat",
                columns: new[] { "Branch", "Dept", "Item", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "WOPrintFormat_TenantId_index",
                schema: "web",
                table: "WOPrintFormat",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOQuote_TenantId_index",
                schema: "web",
                table: "WOQuote",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WORental_TenantId_index",
                schema: "web",
                table: "WORental",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOReplicate_TenantId_index",
                schema: "web",
                table: "WOReplicate",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_WOSection",
                schema: "web",
                table: "WOSection",
                columns: new[] { "WONo", "SectionNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "WOSection_TenantId_index",
                schema: "web",
                table: "WOSection",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "WOSignatures_TenantId_index",
                schema: "web",
                table: "WOSignatures",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_Yale",
                schema: "web",
                table: "Yale",
                columns: new[] { "PartNo", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Yale_TenantId_index",
                schema: "web",
                table: "Yale",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UC_ZipCode",
                schema: "web",
                table: "ZipCode",
                columns: new[] { "ZipCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ZipCode_TenantId_index",
                schema: "web",
                table: "ZipCode",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalCharges",
                schema: "web");

            migrationBuilder.DropTable(
                name: "AdminDeletedRecords",
                schema: "web");

            migrationBuilder.DropTable(
                name: "AdTrack",
                schema: "web");

            migrationBuilder.DropTable(
                name: "AdTrackDef",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Advance",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Allianz",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APPaymentType",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APRepeat",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APRepeatDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APVoucher",
                schema: "web");

            migrationBuilder.DropTable(
                name: "APVoucherDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ARDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Ariens",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ARImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ARImagesDeleted",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ARTerms",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Barrett",
                schema: "web");

            migrationBuilder.DropTable(
                name: "BebQuotes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "BigJoe",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Bobcat",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Boss",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "web");

            migrationBuilder.DropTable(
                name: "BranchARCurrency",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Briggs",
                schema: "web");

            migrationBuilder.DropTable(
                name: "BTPrimeMover",
                schema: "web");

            migrationBuilder.DropTable(
                name: "BusinessCategory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CallReports",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CascadeParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CCTransactions",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CheckData",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CheckDataTemp",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CheckDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CheckDetailTemp",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CheckFormat",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CityTaxCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Clark",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CommentTemplate",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ComplaintCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ComponentCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ContactMailing",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CountyTaxCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Crown",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CurrencyHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CurrencyTypes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Cushman",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CustomerImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CustomerPartsPrice",
                schema: "web");

            migrationBuilder.DropTable(
                name: "CustomerPO",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Daewoo",
                schema: "web");

            migrationBuilder.DropTable(
                name: "DeliveryNoLog",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Depreciation",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Dept",
                schema: "web");

            migrationBuilder.DropTable(
                name: "DispatchNames",
                schema: "web");

            migrationBuilder.DropTable(
                name: "DispatchPriority",
                schema: "web");

            migrationBuilder.DropTable(
                name: "DispatchSecondary",
                schema: "web");

            migrationBuilder.DropTable(
                name: "DispatchStatusTable",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Dixon",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EFTData",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EFTDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EMailLog",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EMailLogError",
                schema: "web");

            migrationBuilder.DropTable(
                name: "eParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EQControlNoChange",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EQCustomFields",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EQCustomLabels",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipLocationChange",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipmentCost",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipmentHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipmentImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipmentPODetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipmentRemoved",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EquipmentYTD",
                schema: "web");

            migrationBuilder.DropTable(
                name: "eRentContactDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "eRentEquipmentDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "eRentFeesDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "eRentReservation",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EventLog",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ExpCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "EZGo",
                schema: "web");

            migrationBuilder.DropTable(
                name: "FactoryCat",
                schema: "web");

            migrationBuilder.DropTable(
                name: "FedExCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "FOB",
                schema: "web");

            migrationBuilder.DropTable(
                name: "FuelHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GL",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GLDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GLField",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GLGroup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GLQuarter",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GLSection",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Gravely",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GroundPower",
                schema: "web");

            migrationBuilder.DropTable(
                name: "GroupTable",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Hamech",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Helmar",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Henderson",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Hiab",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Honda",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Hyundai",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InspectionQuestion",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InternetLog",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Intrupa",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InvCategory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InvDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InvDetailBin",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InventoryCount",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InvHeader",
                schema: "web");

            migrationBuilder.DropTable(
                name: "InvoiceReg",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ItemDescription",
                schema: "web");

            migrationBuilder.DropTable(
                name: "JohnDeere",
                schema: "web");

            migrationBuilder.DropTable(
                name: "JournalDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "JournalHeader",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Kohler",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Komatsu",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Kubota",
                schema: "web");

            migrationBuilder.DropTable(
                name: "LaborQuote",
                schema: "web");

            migrationBuilder.DropTable(
                name: "LaborQuoteGroup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "LaborRate",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Linde",
                schema: "web");

            migrationBuilder.DropTable(
                name: "LocalTaxCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "web");

            migrationBuilder.DropTable(
                name: "LPM",
                schema: "web");

            migrationBuilder.DropTable(
                name: "LynxRite",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MailingCategory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Make",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MarketingSources",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MechanicImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MechanicLabor",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MechanicLaborSignature",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MiscPODetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MitCat",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MitCatReplacement",
                schema: "web");

            migrationBuilder.DropTable(
                name: "MobileHourMeter",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Model",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ModelGroup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Moffett",
                schema: "web");

            migrationBuilder.DropTable(
                name: "NationalParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Nissan",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "web");

            migrationBuilder.DropTable(
                name: "OrdersFreight",
                schema: "web");

            migrationBuilder.DropTable(
                name: "OrdersRecv",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Ottawa",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Parker",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartNoAlias",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Parts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsAltPricing",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsBinHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsBinTrips",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsCost",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsCostChange",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsCustAlias",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsDemand",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsInquiryHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsKit",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsLostSaleDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsLostSaleReason",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsLostSales",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsOnHandChange",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsPriceFiles",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsSales",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsSuppliers",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsTransfer",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsUserCross",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PartsVendorAlias",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PersonGroup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PM",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PMName",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PMParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PMSecondary",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PMSignupHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PMStatus",
                schema: "web");

            migrationBuilder.DropTable(
                name: "POHeader",
                schema: "web");

            migrationBuilder.DropTable(
                name: "POImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PORecent",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PowerBoss",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PrimeMover",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Princeton",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PrinterSetup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "PrintInfoBar",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RapidParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ReasonDelayCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ReasonRepairCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RecentCustomer",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RentalContract",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RentalContractLayout",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RentalHistory",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RentalImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RentalRate",
                schema: "web");

            migrationBuilder.DropTable(
                name: "RepairCode",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ReportDefinitions",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ReportGroups",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ReportSecurity",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ReportStyles",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SaleCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SaleCodesEQMake",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SaleCodesEquipment",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SaleCodesParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Salesman",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SalesmanCommission",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SalesTaxAccounts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SalesTaxIntegration",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SecureDept",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SecureWarehouse",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServiceClaim",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServiceClaimRepairCode",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServiceClaimRepairType",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServiceClaimReturnCode",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServicePriorities",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServiceVanReplenishment",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ServiceVanTemp",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ShipVia",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ShopStatusTable",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SMH",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SMHCross",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Snapper",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SoftbaseLicense",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SpecStatus",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SprayerSystems",
                schema: "web");

            migrationBuilder.DropTable(
                name: "StarLiftCross",
                schema: "web");

            migrationBuilder.DropTable(
                name: "StateTaxCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Stihl",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SurveyHeader",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SurveyQuestion",
                schema: "web");

            migrationBuilder.DropTable(
                name: "SurveyResponse",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Tailift",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Tax",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TaylorDunn",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TCM",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TCMSub",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Tecumseh",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TireTypes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Toro",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Toyota",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ToyotaSub",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TrailerCheckIn",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TrailerSpecs",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Training",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TrainingType",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TransDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TransHeader",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TransSignature",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TrinDocsDetail",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TrinDocsHeader",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TSHourMeter",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Tusk",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TVHCache",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "web");

            migrationBuilder.DropTable(
                name: "VendorExpAccounts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "VendorImages",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WarrantyCodes",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WebPartsOrder",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WO",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOArrival",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOEq",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOInspection",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOInspectionQuestion",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOInspectionSetup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOLabor",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOLaborRemoved",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOLock",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOMisc",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOMiscRemoved",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOParts",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOPartsHold",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOPartsRemoved",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOPartsSerialNo",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOPrint",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOPrintFormat",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOQuote",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WORental",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOReplicate",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOSection",
                schema: "web");

            migrationBuilder.DropTable(
                name: "WOSignatures",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Yale",
                schema: "web");

            migrationBuilder.DropTable(
                name: "ZipCode",
                schema: "web");
        }
    }
}
