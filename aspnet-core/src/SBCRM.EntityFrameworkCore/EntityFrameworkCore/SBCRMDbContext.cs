using SBCRM.Crm;
using SBCRM.Legacy;
using Abp.IdentityServer4vNext;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization.Delegation;
using SBCRM.Authorization.Roles;
using SBCRM.Authorization.Users;
using SBCRM.Chat;
using SBCRM.Editions;
using SBCRM.Friendships;
using SBCRM.MultiTenancy;
using SBCRM.MultiTenancy.Accounting;
using SBCRM.MultiTenancy.Payments;
using SBCRM.Storage;
using Branch = SBCRM.Legacy.Branch;
using Contact = SBCRM.Legacy.Contact;
using Customer = SBCRM.Legacy.Customer;

namespace SBCRM.EntityFrameworkCore
{
    public class SBCRMDbContext : AbpZeroDbContext<Tenant, Role, User, SBCRMDbContext>, IAbpPersistedGrantDbContext
    {        
        
        #region Schema 3.0 CRM

        public virtual DbSet<OpportunityAttachment> OpportunityAttachments { get; set; }

        public virtual DbSet<LeadAttachment> LeadAttachments { get; set; }

        public virtual DbSet<CustomerAttachment> CustomerAttachments { get; set; }

        public virtual DbSet<OpportunityUser> OpportunityUsers { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<ActivitySourceType> ActivitySourceTypes { get; set; }

        public virtual DbSet<ActivityPriority> ActivityPriorities { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<AccountUser> AccountUsers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<InvoiceRegList> InvoiceRegList { get; set; }
        public virtual DbSet<WIPList> WIPList { get; set; }
        public virtual DbSet<InvoiceReg> InvoiceReg { get; set; }
        public virtual DbSet<WO> WO { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EQCustomFields> EQCustomFields { get; set; }

        public virtual DbSet<Secure> Secure { get; set; }

        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<ActivityStatus> ActivityStatuses { get; set; }

        public virtual DbSet<ActivityTaskType> ActivityTaskTypes { get; set; }

        public virtual DbSet<Opportunity> Opportunities { get; set; }

        public virtual DbSet<OpportunityType> OpportunityTypes { get; set; }

        public virtual DbSet<OpportunityStage> OpportunityStages { get; set; }

        public virtual DbSet<LeadUser> LeadUsers { get; set; }

        public virtual DbSet<Priority> Priorities { get; set; }

        public virtual DbSet<Lead> Leads { get; set; }

        public virtual DbSet<LeadStatus> LeadStatuses { get; set; }

        public virtual DbSet<LeadSource> LeadSources { get; set; }

        public virtual DbSet<Industry> Industries { get; set; }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<AccountType> AccountTypes { get; set; }

        public virtual DbSet<ARTerms> ARTerms { get; set; }

        public virtual DbSet<ZipCode> ZipCodes { get; set; }

        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }

        public virtual DbSet<UserDelegation> UserDelegations { get; set; }

        public virtual DbSet<RecentPassword> RecentPasswords { get; set; }

        public virtual DbSet<Branch> Branch { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        #endregion


        #region Schema 4.0 SAAS

        public virtual DbSet<SBCRM.Core.BaseEntities.AdTrack> AdTracks { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.AdTrackDef> AdTrackDefs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.AdditionalCharge> AdditionalCharges { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.AdminDeletedRecord> AdminDeletedRecords { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Advance> Advances { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Allianz> Allianzs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApDetail> Apdetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApImage> Apimages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApPaymentType> AppaymentTypes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApRepeat> Aprepeats { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApRepeatDetail> AprepeatDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApVoucher> Apvouchers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ApVoucherDetail> ApvoucherDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ArDetail> Ardetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Arien> Ariens { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Arimage> Arimages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ArimagesDeleted> ArimagesDeleteds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Arterm> Arterms { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Barrett> Barretts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.BebQuote> BebQuotes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.BigJoe> BigJoes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Bobcat> Bobcats { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Boss> Bosses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Branch> Branches { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.BranchArcurrency> BranchArcurrencies { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Brigg> Briggs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.BtprimeMover> BtprimeMovers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.BusinessCategory> BusinessCategories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CallReport> CallReports { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CascadePart> CascadeParts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Cctransaction> Cctransactions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ChartOfAccount> ChartOfAccounts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CheckDataTemp> CheckDataTemps { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CheckDatum> CheckData { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CheckDetail> CheckDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CheckDetailTemp> CheckDetailTemps { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CheckFormat> CheckFormats { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CityTaxCode> CityTaxCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Clark> Clarks { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CommentTemplate> CommentTemplates { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Company> Companies { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ComplaintCode> ComplaintCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ComponentCode> ComponentCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Contact> Contacts2 { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ContactMailing> ContactMailings { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CountyTaxCode> CountyTaxCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Crown> Crowns { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CurrencyHistory> CurrencyHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CurrencyType> CurrencyTypes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Cushman> Cushmen { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Customer> Customers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CustomerImage> CustomerImages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CustomerPartsPrice> CustomerPartsPrices { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.CustomerPo> CustomerPos { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Daewoo> Daewoos { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.DeliveryNoLog> DeliveryNoLogs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Depreciation> Depreciations { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Dept> Depts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.DispatchName> DispatchNames { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.DispatchPriority> DispatchPriorities { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.DispatchSecondary> DispatchSecondaries { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.DispatchStatusTable> DispatchStatusTables { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Dixon> Diceson { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EPart> EParts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ERentContactDetail> ERentContactDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ERentEquipmentDetail> ERentEquipmentDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ERentFeesDetail> ERentFeesDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ERentReservation> ERentReservations { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Eftdatum> Eftdata { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Eftdetail> Eftdetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EmailLog> EmailLogs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EmailLogError> EmailLogErrors { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EqcontrolNoChange> EqcontrolNoChanges { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EqcustomField> EqcustomFields { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EqcustomLabel> EqcustomLabels { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipLocationChange> EquipLocationChanges { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Equipment> Equipment2 { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipmentCost> EquipmentCosts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipmentHistory> EquipmentHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipmentImage> EquipmentImages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipmentPodetail> EquipmentPodetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipmentRemoved> EquipmentRemoveds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EquipmentYtd> EquipmentYtds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.EventLog> EventLogs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ExpCode> ExpCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Ezgo> Ezgos { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.FactoryCat> FactoryCats { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.FedExCode> FedExCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Fob> Fobs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.FuelHistory> FuelHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Gl> Gls { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Gldetail> Gldetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Glfield> Glfields { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Glgroup> Glgroups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Glquarter> Glquarters { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Glsection> Glsections { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Gravely> Gravelies { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.GroundPower> GroundPowers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.GroupTable> GroupTables { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Hamech> Hameches { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Helmar> Helmars { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Henderson> Hendersons { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Hiab> Hiabs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Hondum> Honda { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Hyundai> Hyundais { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InspectionQuestion> InspectionQuestions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InternetLog> InternetLogs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Intrupa> Intrupas { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InvCategory> InvCategories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InvDetail> InvDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InvDetailBin> InvDetailBins { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InvHeader> InvHeaders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InventoryCount> InventoryCounts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.InvoiceReg> InvoiceRegs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ItemDescription> ItemDescriptions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.JohnDeere> JohnDeeres { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.JournalDetail> JournalDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.JournalHeader> JournalHeaders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Kohler> Kohlers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Komatsu> Komatsus { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Kubotum> Kubota { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.LaborQuote> LaborQuotes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.LaborQuoteGroup> LaborQuoteGroups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.LaborRate> LaborRates { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Language> Languages2 { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Linde> Lindes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.LocalTaxCode> LocalTaxCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Location> Locations { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Lpm> Lpms { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.LynxRite> LynxRites { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MailingCategory> MailingCategories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Make> Makes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MarketingSource> MarketingSources { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MechanicImage> MechanicImages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MechanicLabor> MechanicLabors { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MechanicLaborSignature> MechanicLaborSignatures { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MiscPodetail> MiscPodetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MitCat> MitCats { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MitCatReplacement> MitCatReplacements { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.MobileHourMeter> MobileHourMeters { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Model> Models { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ModelGroup> ModelGroups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Moffett> Moffetts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.NationalPart> NationalParts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Nissan> Nissans { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Order> Orders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.OrdersFreight> OrdersFreights { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.OrdersRecv> OrdersRecvs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Ottawa> Ottawas { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Parker> Parkers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Part> Parts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartNoAlias> PartNoAliases { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsAltPricing> PartsAltPricings { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsBinHistory> PartsBinHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsBinTrip> PartsBinTrips { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsCost> PartsCosts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsCostChange> PartsCostChanges { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsCustAlias> PartsCustAliases { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsDemand> PartsDemands { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsImage> PartsImages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsInquiryHistory> PartsInquiryHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsKit> PartsKits { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsLostSale> PartsLostSales { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsLostSaleDetail> PartsLostSaleDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsLostSaleReason> PartsLostSaleReasons { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsOnHandChange> PartsOnHandChanges { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsPriceFile> PartsPriceFiles { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsSale> PartsSales { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsSupplier> PartsSuppliers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsTransfer> PartsTransfers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsUserCross> PartsUserCrosses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PartsVendorAlias> PartsVendorAliases { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Person> People { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PersonGroup> PersonGroups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Pm> Pms { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Pmname> Pmnames { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Pmpart> Pmparts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Pmsecondary> Pmsecondaries { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PmsignupHistory> PmsignupHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Pmstatus> Pmstatuses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Poheader> Poheaders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Poimage> Poimages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Porecent> Porecents { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PowerBoss> PowerBosses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PrimeMover> PrimeMovers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Princeton> Princetons { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PrintInfoBar> PrintInfoBars { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.PrinterSetup> PrinterSetups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RapidPart> RapidParts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ReasonDelayCode> ReasonDelayCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ReasonRepairCode> ReasonRepairCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RecentCustomer> RecentCustomers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RentalContract> RentalContracts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RentalContractLayout> RentalContractLayouts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RentalHistory> RentalHistories { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RentalImage> RentalImages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RentalRate> RentalRates { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.RepairCode> RepairCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ReportDefinition> ReportDefinitions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ReportGroup> ReportGroups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ReportSecurity> ReportSecurities { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ReportStyle> ReportStyles { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Sale> Sales { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SaleCode> SaleCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SaleCodesEqmake> SaleCodesEqmakes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SaleCodesEquipment> SaleCodesEquipments { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SaleCodesPart> SaleCodesParts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SalesTaxAccount> SalesTaxAccounts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SalesTaxIntegration> SalesTaxIntegrations { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Salesman> Salesmen { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SalesmanCommission> SalesmanCommissions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SecureDept> SecureDepts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SecureWarehouse> SecureWarehouses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServiceClaim> ServiceClaims { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServiceClaimRepairCode> ServiceClaimRepairCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServiceClaimRepairType> ServiceClaimRepairTypes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServiceClaimReturnCode> ServiceClaimReturnCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServicePriority> ServicePriorities { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServiceVanReplenishment> ServiceVanReplenishments { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ServiceVanTemp> ServiceVanTemps { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Setting> Settings2 { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ShipVium> ShipVia { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ShopStatusTable> ShopStatusTables { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Smh> Smhs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Smhcross> Smhcrosses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Snapper> Snappers { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SoftbaseLicense> SoftbaseLicenses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SpecStatus> SpecStatuses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SprayerSystem> SprayerSystems { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.StarLiftCross> StarLiftCrosses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.StateTaxCode> StateTaxCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Stihl> Stihls { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SurveyHeader> SurveyHeaders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.SurveyResponse> SurveyResponses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tailift> Tailifts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tax> Taxes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TaylorDunn> TaylorDunns { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tcm> Tcms { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tcmsub> Tcmsubs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tecumseh> Tecumsehs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TireType> TireTypes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Toro> Toros { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ToyotaSub> ToyotaSubs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Toyotum> Toyota { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TrailerCheckIn> TrailerCheckIns { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TrailerSpec> TrailerSpecs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TrainingType> TrainingTypes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TransDetail> TransDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TransHeader> TransHeaders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TransSignature> TransSignatures { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TrinDocsDetail> TrinDocsDetails { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TrinDocsHeader> TrinDocsHeaders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.TshourMeter> TshourMeters { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tusk> Tusks { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Tvhcache> Tvhcaches { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Vendor> Vendors { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.VendorExpAccount> VendorExpAccounts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.VendorImage> VendorImages { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Warehouse> Warehouses { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WarrantyCode> WarrantyCodes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WebPartsOrder> WebPartsOrders { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Wo> Wos { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Woarrival> Woarrivals { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Woeq> Woeqs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Woinspection> Woinspections { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WoinspectionQuestion> WoinspectionQuestions { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WoinspectionSetup> WoinspectionSetups { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Wolabor> Wolabors { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WolaborRemoved> WolaborRemoveds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Wolock> Wolocks { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Womisc> Womiscs { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WomiscRemoved> WomiscRemoveds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Wopart> Woparts { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WopartsHold> WopartsHolds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WopartsRemoved> WopartsRemoveds { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WopartsSerialNo> WopartsSerialNos { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Woprint> Woprints { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.WoprintFormat> WoprintFormats { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Woquote> Woquotes { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Worental> Worentals { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Woreplicate> Woreplicates { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Wosection> Wosections { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Wosignature> Wosignatures { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Yale> Yales { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.ZipCode> ZipCodes2 { get; set; }
        public virtual DbSet<SBCRM.Core.BaseEntities.Training> training { get; set; }

        #endregion


        public SBCRMDbContext(DbContextOptions<SBCRMDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(SBCRMConsts.DefaultSchemaName);

            modelBuilder.HasSequence<int>("CustomerNumberSequence");

            modelBuilder.Entity<Department>().HasKey(p => new { p.Branch, p.Dept });

            modelBuilder
                .Entity<InvoiceRegList>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("InvoiceRegList", "dbo");
                });

            modelBuilder
                .Entity<WIPList>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("WIPList", "dbo");
                });

            modelBuilder.Entity<Department>().Ignore(c => c.Id);
            modelBuilder.Entity<Branch>().Ignore(c => c.Id);
            modelBuilder.Entity<Customer>().Ignore(c => c.Id);
            modelBuilder.Entity<Contact>().Ignore(c => c.Id);

            modelBuilder.Entity<BinaryObject>(b =>
                                             {
                                                 b.HasIndex(e => new { e.TenantId });
                                             });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}