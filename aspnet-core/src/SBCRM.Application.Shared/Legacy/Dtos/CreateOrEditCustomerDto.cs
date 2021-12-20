using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object for creation/edition customer
    /// </summary>
    public class CreateOrEditCustomerDto : ICustomValidate
    {
        [StringLength(CustomerConsts.MaxNumberLength, MinimumLength = CustomerConsts.MinNumberLength)]
        public string Number { get; set; }

        [StringLength(CustomerConsts.MaxBillToLength, MinimumLength = CustomerConsts.MinBillToLength)]
        public string BillTo { get; set; }

        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public string Name { get; set; }

        [StringLength(CustomerConsts.MaxPhoneLength, MinimumLength = CustomerConsts.MinPhoneLength)]
        public string Phone { get; set; }

        [StringLength(CustomerConsts.MaxEMailLength, MinimumLength = CustomerConsts.MinEMailLength)]
        public string EMail { get; set; }

        [StringLength(CustomerConsts.MaxWWWAddressLength, MinimumLength = CustomerConsts.MinWWWAddressLength)]
        public string WWWAddress { get; set; }

        [StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
        public string Address { get; set; }

        [StringLength(CustomerConsts.MaxPOBoxLength, MinimumLength = CustomerConsts.MinPOBoxLength)]
        public string POBox { get; set; }

        [StringLength(CustomerConsts.MaxCountryLength, MinimumLength = CustomerConsts.MinCountryLength)]
        public string Country { get; set; }

        [StringLength(CustomerConsts.MaxCityLength, MinimumLength = CustomerConsts.MinCityLength)]
        public string City { get; set; }

        [StringLength(CustomerConsts.MaxStateLength, MinimumLength = CustomerConsts.MinStateLength)]
        public string State { get; set; }

        [StringLength(CustomerConsts.MaxZipCodeLength, MinimumLength = CustomerConsts.MinZipCodeLength)]
        public string ZipCode { get; set; }

        public int? AccountTypeId { get; set; }
        public int? LeadSourceId { get; set; }

        [StringLength(CustomerConsts.MaxDunsCodeLength, MinimumLength = CustomerConsts.MinDunsCodeLength)]
        public string DunsCode { get; set; }

        [StringLength(CustomerConsts.MaxSICCodeLength, MinimumLength = CustomerConsts.MinSICCodeLength)]
        public string SICCode { get; set; }

        [StringLength(CustomerConsts.MaxSICCode2Length, MinimumLength = CustomerConsts.MinSICCode2Length)]
        public string SICCode2 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode3Length, MinimumLength = CustomerConsts.MinSICCode3Length)]
        public string SICCode3 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode4Length, MinimumLength = CustomerConsts.MinSICCode4Length)]
        public string SICCode4 { get; set; }

        public string BusinessDescription { get; set; }


        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                context.Results.Add(new ValidationResult("Company name should be provided"));
            }

            if (string.IsNullOrWhiteSpace(Phone) && string.IsNullOrWhiteSpace(EMail))
            {
                context.Results.Add(new ValidationResult("Email or Phone should be provided"));
            }
        }
    }
}