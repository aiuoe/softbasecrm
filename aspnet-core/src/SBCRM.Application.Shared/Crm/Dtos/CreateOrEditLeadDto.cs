using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditLeadDto : EntityDto<int?>
    {

        [Required]
        [StringLength(LeadConsts.MaxCompanyNameLength, MinimumLength = LeadConsts.MinCompanyNameLength)]
        public string CompanyName { get; set; }

        [StringLength(LeadConsts.MaxContactNameLength, MinimumLength = LeadConsts.MinContactNameLength)]
        public string ContactName { get; set; }

        [StringLength(LeadConsts.MaxContactPositionLength, MinimumLength = LeadConsts.MinContactPositionLength)]
        public string ContactPosition { get; set; }

        [StringLength(LeadConsts.MaxWebSiteLength, MinimumLength = LeadConsts.MinWebSiteLength)]
        public string WebSite { get; set; }

        [StringLength(LeadConsts.MaxAddressLength, MinimumLength = LeadConsts.MinAddressLength)]
        public string Address { get; set; }

        [StringLength(LeadConsts.MaxCountryLength, MinimumLength = LeadConsts.MinCountryLength)]
        public string Country { get; set; }

        [StringLength(LeadConsts.MaxStateLength, MinimumLength = LeadConsts.MinStateLength)]
        public string State { get; set; }

        [StringLength(LeadConsts.MaxCityLength, MinimumLength = LeadConsts.MinCityLength)]
        public string City { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxCompanyPhoneLength, MinimumLength = LeadConsts.MinCompanyPhoneLength)]
        public string CompanyPhone { get; set; }

        [StringLength(LeadConsts.MaxCompanyEmailLength, MinimumLength = LeadConsts.MinCompanyEmailLength)]
        public string CompanyEmail { get; set; }

        [StringLength(LeadConsts.MaxPoBoxLength, MinimumLength = LeadConsts.MinPoBoxLength)]
        public string PoBox { get; set; }

        [StringLength(LeadConsts.MaxZipCodeLength, MinimumLength = LeadConsts.MinZipCodeLength)]
        public string ZipCode { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneLength, MinimumLength = LeadConsts.MinContactPhoneLength)]
        public string ContactPhone { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneExtensionLength, MinimumLength = LeadConsts.MinContactPhoneExtensionLength)]
        public string ContactPhoneExtension { get; set; }

        [StringLength(LeadConsts.MaxContactCellPhoneLength, MinimumLength = LeadConsts.MinContactCellPhoneLength)]
        public string ContactCellPhone { get; set; }

        [StringLength(LeadConsts.MaxContactFaxNumberLength, MinimumLength = LeadConsts.MinContactFaxNumberLength)]
        public string ContactFaxNumber { get; set; }

        [StringLength(LeadConsts.MaxPagerNumberLength, MinimumLength = LeadConsts.MinPagerNumberLength)]
        public string PagerNumber { get; set; }

        [StringLength(LeadConsts.MaxContactEmailLength, MinimumLength = LeadConsts.MinContactEmailLength)]
        public string ContactEmail { get; set; }

        public int? LeadSourceId { get; set; }

        public int? LeadStatusId { get; set; }

        public int? PriorityId { get; set; }

    }
}