using SBCRM.Crm;
using SBCRM.Crm;
using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    [Table("Leads")]
    public class Lead : FullAuditedEntity
    {

        [Required]
        [StringLength(LeadConsts.MaxCompanyNameLength, MinimumLength = LeadConsts.MinCompanyNameLength)]
        public virtual string CompanyName { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxFirstNameLength, MinimumLength = LeadConsts.MinFirstNameLength)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxLastNameLength, MinimumLength = LeadConsts.MinLastNameLength)]
        public virtual string LastName { get; set; }

        [StringLength(LeadConsts.MaxTitleLength, MinimumLength = LeadConsts.MinTitleLength)]
        public virtual string Title { get; set; }

        [StringLength(LeadConsts.MaxWebSiteLength, MinimumLength = LeadConsts.MinWebSiteLength)]
        public virtual string WebSite { get; set; }

        [StringLength(LeadConsts.MaxAddressLength, MinimumLength = LeadConsts.MinAddressLength)]
        public virtual string Address { get; set; }

        [StringLength(LeadConsts.MaxCountryLength, MinimumLength = LeadConsts.MinCountryLength)]
        public virtual string Country { get; set; }

        [StringLength(LeadConsts.MaxStateLength, MinimumLength = LeadConsts.MinStateLength)]
        public virtual string State { get; set; }

        public virtual string Description { get; set; }

        public virtual int IndustryId { get; set; }

        [ForeignKey("IndustryId")]
        public Industry IndustryFk { get; set; }

        public virtual int LeadSourceId { get; set; }

        [ForeignKey("LeadSourceId")]
        public LeadSource LeadSourceFk { get; set; }

        public virtual int LeadStatusId { get; set; }

        [ForeignKey("LeadStatusId")]
        public LeadStatus LeadStatusFk { get; set; }


        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

        public virtual string CustomerNumber { get; set; }

    }
}