using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Branch entity from legacy schema
    /// </summary>
    [Table("Branch", Schema = "dbo")]
    public class Branch : Entity
    {
        [Key]
        public virtual short Number { get; set; }
        public virtual string Name { get; set; }
        public virtual string SubName { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Receivable { get; set; }
        public virtual string FinanceCharge { get; set; }
        public virtual Single? FinanceRate { get; set; }
        public virtual short? FinanceDays { get; set; }
        public virtual string StateTaxLabel { get; set; }
        public virtual string CountyTaxLabel { get; set; }
        public virtual short? ShowSplitSalesTax { get; set; }
        public virtual string CityTaxLabel { get; set; }
        public virtual string LocalTaxLabel { get; set; }
        public virtual string DefaultWarehouse { get; set; }
        public virtual string ClarkPartsCode { get; set; }
        public virtual string ClarkDealerAccessCode { get; set; }
        public virtual short? UseStateTaxCodeDescription { get; set; }
        public virtual short? UseCountyTaxCodeDescription { get; set; }
        public virtual short? UseCityTaxCodeDescription { get; set; }
        public virtual short? UseLocalTaxCodeDescription { get; set; }
        public virtual DateTime? RentalDeliveryDefaultTime { get; set; }
        public virtual string StateTaxCode { get; set; }
        public virtual string CountyTaxCode { get; set; }
        public virtual string CityTaxCode { get; set; }
        public virtual string LocalTaxCode { get; set; }
        public virtual string TaxCode { get; set; }
        public virtual bool? UseAbsoluteTaxCodes { get; set; }
        public virtual string SmallSubName { get; set; }
        public virtual string AddedBy { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual DateTime? DateAdded { get; set; }
        public virtual DateTime? DateChanged { get; set; }
        public virtual string ShopID { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual short? UseImage { get; set; }
        public virtual string LogoFile { get; set; }
        public virtual string VendorID { get; set; }
        public virtual string PrintFinalCC { get; set; }
        public virtual string PrintFinalBCC { get; set; }
        public virtual string StoreName { get; set; }
        public virtual string CreditCardAccountNo { get; set; }
        public virtual string TVHAccountNo { get; set; }
        public virtual string TVHKey { get; set; }
        public virtual string TVHCountry { get; set; }
        public virtual string TVHWarehouse { get; set; }
    }
}
