using System;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for fetching branch details
    /// </summary>
    public class GetBranchDetailsDto
    {
        public string Name { get; set; }
        public string SubName { get; set; }
        public string SmallSubName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Receivable { get; set; }
        public string FinanceCharge { get; set; }
        public Decimal? FinanceRate { get; set; }
        public short? FinanceDays { get; set; }
        public string StateTaxLabel { get; set; }
        public string CountyTaxLabel { get; set; }
        public bool? ShowSplitSalesTax { get; set; }
        public string CityTaxLabel { get; set; }
        public string LocalTaxLabel { get; set; }
        public string DefaultWarehouse { get; set; }
        public string ClarkPartsCode { get; set; }
        public string ClarkDealerAccessCode { get; set; }
        public bool? UseStateTaxCodeDescription { get; set; }
        public bool? UseCountyTaxCodeDescription { get; set; }
        public bool? UseCityTaxCodeDescription { get; set; }
        public bool? UseLocalTaxCodeDescription { get; set; }
        public DateTime? RentalDeliveryDefaultTime { get; set; }
        public string StateTaxCode { get; set; }
        public string CountyTaxCode { get; set; }
        public string CityTaxCode { get; set; }
        public string LocalTaxCode { get; set; }
        public string TaxCode { get; set; }
        public bool? UseAbsoluteTaxCodes { get; set; }
        public string ShopId { get; set; }
        public string Image { get; set; }
        public bool? UseImage { get; set; }
        public string LogoFile { get; set; }
        public string VendorId { get; set; }
        public string PrintFinalCc { get; set; }
        public string PrintFinalBcc { get; set; }
        public string StoreName { get; set; }
        public string CreditCardAccountNo { get; set; }
        public string TvhaccountNo { get; set; }
        public string Tvhkey { get; set; }
        public string Tvhcountry { get; set; }
        public string Tvhwarehouse { get; set; }
        public string AddedBy { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateChanged { get; set; }
    }
}
