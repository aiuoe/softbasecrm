using System;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Commands
{
    /// <summary>
    /// Update branch command
    /// </summary>
    public class UpdateBranchCommand : IRequest<UpsertBranchDto>, ICustomValidate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public long? CountryId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Receivable { get; set; }
        public string FinanceCharge { get; set; }
        public decimal? FinanceRate { get; set; }
        public short? FinanceDays { get; set; }
        public string StateTaxLabel { get; set; }
        public string CountyTaxLabel { get; set; }
        public bool? ShowSplitSalesTax { get; set; }
        public string CityTaxLabel { get; set; }
        public string LocalTaxLabel { get; set; }
        public long? DefaultWarehouseId { get; set; }
        public string ClarkPartsCode { get; set; }
        public string ClarkDealerAccessCode { get; set; }
        public bool? UseStateTaxCodeDescription { get; set; }
        public bool? UseCountyTaxCodeDescription { get; set; }
        public bool? UseCityTaxCodeDescription { get; set; }
        public bool? UseLocalTaxCodeDescription { get; set; }
        public DateTime? RentalDeliveryDefaultTime { get; set; }
        public long? StateTaxCodeId { get; set; }
        public long? CountyTaxCodeId { get; set; }
        public long? CityTaxCodeId { get; set; }
        public long? LocalTaxCodeId { get; set; }
        public long? TaxCodeId { get; set; }
        public bool? UseAbsoluteTaxCodes { get; set; }
        public string SmallSubName { get; set; }
        public string ShopId { get; set; }
        public string Image { get; set; }
        public bool? UseImage { get; set; }
        public string LogoFile { get; set; }
        public string VendorId { get; set; }
        public string PrintFinalCc { get; set; }
        public string PrintFinalBcc { get; set; }
        public string StoreName { get; set; }
        public string CreditCardAccountNo { get; set; }
        public string TvhAccountNo { get; set; }
        public string TvhKey { get; set; }
        public long? TvhCountryId { get; set; }
        public long? TvhWarehouseId { get; set; }
        public string FileType { get; set; }
        public byte[] BinaryLogoFile { get; set; }

        /// <summary>
        /// Validation command
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("BranchNameRequired")));
            }
        }
    }
}
