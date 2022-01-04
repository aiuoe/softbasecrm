using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Departmen(Dept) entity from legacy schema
    /// </summary>
    [Table("Dept", Schema = "dbo")]
    public class Department
    {
		[Key]
		public short Dept { get; set; }

		public short Branch { get; set; }

		public string Title { get; set; }
		public short? SaleGroup { get; set; }
		public short? MechGroup { get; set; }
		public string InvoiceType { get; set; }
		public string InvoiceName { get; set; }
		public string LaborAccount { get; set; }
		public string EquipmentAccount { get; set; }
		public string InternalCustomer { get; set; }
		public int? NextInvoice { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public string MiscDescription { get; set; }
		public Single? MiscPercent { get; set; }
		public string MiscSaleAccount { get; set; }
		public decimal? MiscLimit { get; set; }
		public short? MiscLaborOnly { get; set; }
		public string DeptGroup { get; set; }
		public string TermsOverRide { get; set; }
		public short? PartsPricing { get; set; }
		public short? InitialComments { get; set; }
		public short? MiscPartsOnly { get; set; }
		public Single? HoursInDay { get; set; }
		public short? DaysInWeek { get; set; }
		public short? DaysIn4Week { get; set; }
		public short? DaysInMonth { get; set; }
		public short? DaysInQuarter { get; set; }
		public int? NextPONo { get; set; }
		public int? NextQuote { get; set; }
		public string QuoteComments { get; set; }
		public string CashAccount { get; set; }
		public int? NextRentalContract { get; set; }
		public short? SuppressLaborHours { get; set; }
		public Single? AdditionalLaborHours { get; set; }
		public int? AdditionalLaborMech { get; set; }
		public string AdditionalLaborAccountNo { get; set; }
		public string RentalReturnStatus { get; set; }
		public short? SuppressPartsPricing { get; set; }
		public short? QuoteExpirationDays { get; set; }
		public string InvoiceComments { get; set; }
		public string OpenWOWatermark { get; set; }
		public short? BOPriority { get; set; }
		public short? StockPriority { get; set; }
		public short? EmergencyCostPriority { get; set; }
		public bool TaxAtDealer { get; set; }
		public string QuoteVerbiage { get; set; }
		public string AddedBy { get; set; }
		public DateTime? DateAdded { get; set; }
		public string ChangedBy { get; set; }
		public DateTime? DateChanged { get; set; }
		public short? NoCreditOnQuote { get; set; }
		public string InvoiceNameFrench { get; set; }
		public string QuoteVerbiageFrench { get; set; }
		public string MobileDisclaimer { get; set; }
		public string MobileSignatureDisclaimer { get; set; }
		public string InternalTopText { get; set; }
		public string CreditCardAccountNo { get; set; }
		public short? NoCC { get; set; }
		public string PartsRecvEmail { get; set; }
	}
}
