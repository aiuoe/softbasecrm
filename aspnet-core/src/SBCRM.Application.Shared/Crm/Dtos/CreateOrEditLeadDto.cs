using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Lead dto used by the ui to create or edit a lead
    /// </summary>
    public class CreateOrEditLeadDto : EntityDto<int?>, ICustomValidate
    {

        [Required]
        [StringLength(LeadConsts.MaxCompanyNameLength)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxContactNameLength)]
        public string ContactName { get; set; }

        [StringLength(LeadConsts.MaxContactPositionLength)]
        public string ContactPosition { get; set; }

        [StringLength(LeadConsts.MaxWebSiteLength)]
        public string WebSite { get; set; }

        [StringLength(LeadConsts.MaxAddressLength)]
        public string Address { get; set; }

        [StringLength(LeadConsts.MaxCountryLength)]
        public string Country { get; set; }

        [StringLength(LeadConsts.MaxStateLength)]
        public string State { get; set; }

        [StringLength(LeadConsts.MaxCityLength)]
        public string City { get; set; }

        [StringLength(LeadConsts.MaxNotesLength)]
        public string Notes { get; set; }


        [StringLength(LeadConsts.MaxCompanyPhoneLength)]
        public string CompanyPhone { get; set; }

        [StringLength(LeadConsts.MaxCompanyEmailLength)]
        public string CompanyEmail { get; set; }

        [StringLength(LeadConsts.MaxPoBoxLength)]
        public string PoBox { get; set; }

        [StringLength(LeadConsts.MaxZipCodeLength)]
        public string ZipCode { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneLength)]
        public string ContactPhone { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneExtensionLength)]
        public string ContactPhoneExtension { get; set; }

        [StringLength(LeadConsts.MaxContactCellPhoneLength)]
        public string ContactCellPhone { get; set; }

        [StringLength(LeadConsts.MaxContactFaxNumberLength)]
        public string ContactFaxNumber { get; set; }

        [StringLength(LeadConsts.MaxPagerNumberLength)]
        public string PagerNumber { get; set; }

        [StringLength(LeadConsts.MaxContactEmailLength)]
        public string ContactEmail { get; set; }

        public int? LeadSourceId { get; set; }

        public int? LeadStatusId { get; set; }

        public int? PriorityId { get; set; }

        /// <summary>
        /// Custom validator to check the lead either has  CompanyPhone or a CompanyEmail
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(CompanyPhone) && string.IsNullOrWhiteSpace(CompanyEmail))
            {
                context.Results.Add(new ValidationResult("Email or Phone should be provided"));
            }
        }
    }

}