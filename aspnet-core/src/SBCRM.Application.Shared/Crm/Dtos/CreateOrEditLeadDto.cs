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

        [Required]
        [StringLength(LeadConsts.MaxFirstNameLength, MinimumLength = LeadConsts.MinFirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxLastNameLength, MinimumLength = LeadConsts.MinLastNameLength)]
        public string LastName { get; set; }

        [StringLength(LeadConsts.MaxTitleLength, MinimumLength = LeadConsts.MinTitleLength)]
        public string Title { get; set; }

        [StringLength(LeadConsts.MaxWebSiteLength, MinimumLength = LeadConsts.MinWebSiteLength)]
        public string WebSite { get; set; }

        [StringLength(LeadConsts.MaxAddressLength, MinimumLength = LeadConsts.MinAddressLength)]
        public string Address { get; set; }

        [StringLength(LeadConsts.MaxCountryLength, MinimumLength = LeadConsts.MinCountryLength)]
        public string Country { get; set; }

        [StringLength(LeadConsts.MaxStateLength, MinimumLength = LeadConsts.MinStateLength)]
        public string State { get; set; }

        public string Description { get; set; }

        public int IndustryId { get; set; }

        public int LeadSourceId { get; set; }

        public int LeadStatusId { get; set; }

    }
}