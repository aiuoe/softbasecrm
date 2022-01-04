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
    /// Branch entity from legacy schema
    /// </summary>
    [Table("Branch", Schema = "dbo")]
    public class Branch
    {

        [Key]
        public short Number { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Receivable { get; set; }
        public string FinanceCharge { get; set; }
        public Single? FinanceRate { get; set; }
        public short? FinanceDays { get; set; }
        public string StateTaxLabel { get; set; }
        public string CountyTaxLabel { get; set; }
        public short? ShowSplitSalesTax { get; set; }
        public string CityTaxLabel { get; set; }
        public string LocalTaxLabel { get; set; }
        public string DefaultWarehouse { get; set; }
        public string ClarkPartsCode { get; set; }
        public string ClarkDealerAccessCode { get; set; }
        public short? UseStateTaxCodeDescription { get; set; }
        public short? UseCountyTaxCodeDescription { get; set; }
        public short? UseCityTaxCodeDescription { get; set; }
        public short? UseLocalTaxCodeDescription { get; set; }
        public DateTime? RentalDeliveryDefaultTime { get; set; }
        public string StateTaxCode { get; set; }
        public string CountyTaxCode { get; set; }
        public string CityTaxCode { get; set; }
        public string LocalTaxCode { get; set; }
        public string TaxCode { get; set; }
        public bool? UseAbsoluteTaxCodes { get; set; }
        public string SmallSubName { get; set; }
        public string AddedBy { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateChanged { get; set; }
        public string ShopID { get; set; }
        public byte[] Image { get; set; }
        public short? UseImage { get; set; }
        public string LogoFile { get; set; }
        public string VendorID { get; set; }
        public string PrintFinalCC { get; set; }
        public string PrintFinalBCC { get; set; }
        public string StoreName { get; set; }
        public string CreditCardAccountNo { get; set; }
        public string TVHAccountNo { get; set; }
        public string TVHKey { get; set; }
        public string TVHCountry { get; set; }
        public string TVHWarehouse { get; set; }
    }
}
