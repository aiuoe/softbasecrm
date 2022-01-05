using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Department(Dept) entity from legacy schema
    /// </summary>
    [Table("Dept", Schema = "dbo")]
    public class Department : Entity
	{
		public virtual short Dept { get; set; }
		public virtual short Branch { get; set; }
		public virtual string Title { get; set; }
		public virtual short? SaleGroup { get; set; }
		public virtual short? MechGroup { get; set; }
		public virtual string InvoiceType { get; set; }
		public virtual string InvoiceName { get; set; }
		public virtual string LaborAccount { get; set; }
		public virtual string EquipmentAccount { get; set; }
		public virtual string InternalCustomer { get; set; }
		public virtual int? NextInvoice { get; set; }
		public virtual DateTime? FromDate { get; set; }
		public virtual DateTime? ToDate { get; set; }
		public virtual string MiscDescription { get; set; }
		public virtual Single? MiscPercent { get; set; }
		public virtual string MiscSaleAccount { get; set; }
		public virtual decimal? MiscLimit { get; set; }
		public virtual short? MiscLaborOnly { get; set; }
		public virtual string DeptGroup { get; set; }
		public virtual string TermsOverRide { get; set; }
		public virtual short? PartsPricing { get; set; }
		public virtual short? InitialComments { get; set; }
		public virtual short? MiscPartsOnly { get; set; }
		public virtual Single? HoursInDay { get; set; }
		public virtual short? DaysInWeek { get; set; }
		public virtual short? DaysIn4Week { get; set; }
		public virtual short? DaysInMonth { get; set; }
		public virtual short? DaysInQuarter { get; set; }
		public virtual int? NextPONo { get; set; }
		public virtual int? NextQuote { get; set; }
		public virtual string QuoteComments { get; set; }
		public virtual string CashAccount { get; set; }
		public virtual int? NextRentalContract { get; set; }
		public virtual short? SuppressLaborHours { get; set; }
		public virtual Single? AdditionalLaborHours { get; set; }
		public virtual int? AdditionalLaborMech { get; set; }
		public virtual string AdditionalLaborAccountNo { get; set; }
		public virtual string RentalReturnStatus { get; set; }
		public virtual short? SuppressPartsPricing { get; set; }
		public virtual short? QuoteExpirationDays { get; set; }
		public virtual string InvoiceComments { get; set; }
		public virtual string OpenWOWatermark { get; set; }
		public virtual short? BOPriority { get; set; }
		public virtual short? StockPriority { get; set; }
		public virtual short? EmergencyCostPriority { get; set; }
		public virtual bool TaxAtDealer { get; set; }
		public virtual string QuoteVerbiage { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual DateTime? DateAdded { get; set; }
		public virtual string ChangedBy { get; set; }
		public virtual DateTime? DateChanged { get; set; }
		public virtual short? NoCreditOnQuote { get; set; }
		public virtual string InvoiceNameFrench { get; set; }
		public virtual string QuoteVerbiageFrench { get; set; }
		public virtual string MobileDisclaimer { get; set; }
		public virtual string MobileSignatureDisclaimer { get; set; }
		public virtual string InternalTopText { get; set; }
		public virtual string CreditCardAccountNo { get; set; }
		public virtual short? NoCC { get; set; }
		public virtual string PartsRecvEmail { get; set; }

        public virtual short BranchNumber { get; set; }

		[ForeignKey("BranchNumber")]
        public Branch BranchFk { get; set; }
	}
}
