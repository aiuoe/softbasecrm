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

        [StringLength(LeadConsts.MaxContactNameLength, MinimumLength = LeadConsts.MinContactNameLength)]
        public virtual string ContactName { get; set; }

        [StringLength(LeadConsts.MaxContactPositionLength, MinimumLength = LeadConsts.MinContactPositionLength)]
        public virtual string ContactPosition { get; set; }

        [StringLength(LeadConsts.MaxWebSiteLength, MinimumLength = LeadConsts.MinWebSiteLength)]
        public virtual string WebSite { get; set; }

        [StringLength(LeadConsts.MaxAddressLength, MinimumLength = LeadConsts.MinAddressLength)]
        public virtual string Address { get; set; }

        [StringLength(LeadConsts.MaxCountryLength, MinimumLength = LeadConsts.MinCountryLength)]
        public virtual string Country { get; set; }

        [StringLength(LeadConsts.MaxStateLength, MinimumLength = LeadConsts.MinStateLength)]
        public virtual string State { get; set; }

        public virtual string Description { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxCompanyPhoneLength, MinimumLength = LeadConsts.MinCompanyPhoneLength)]
        public virtual string CompanyPhone { get; set; }

        [StringLength(LeadConsts.MaxCompanyEmailLength, MinimumLength = LeadConsts.MinCompanyEmailLength)]
        public virtual string CompanyEmail { get; set; }

        [StringLength(LeadConsts.MaxPoBoxLength, MinimumLength = LeadConsts.MinPoBoxLength)]
        public virtual string PoBox { get; set; }

        [StringLength(LeadConsts.MaxZipCodeLength, MinimumLength = LeadConsts.MinZipCodeLength)]
        public virtual string ZipCode { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneLength, MinimumLength = LeadConsts.MinContactPhoneLength)]
        public virtual string ContactPhone { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneExtensionLength, MinimumLength = LeadConsts.MinContactPhoneExtensionLength)]
        public virtual string ContactPhoneExtension { get; set; }

        [StringLength(LeadConsts.MaxContactCellPhoneLength, MinimumLength = LeadConsts.MinContactCellPhoneLength)]
        public virtual string ContactCellPhone { get; set; }

        [StringLength(LeadConsts.MaxContactFaxNumberLength, MinimumLength = LeadConsts.MinContactFaxNumberLength)]
        public virtual string ContactFaxNumber { get; set; }

        [StringLength(LeadConsts.MaxPagerNumberLength, MinimumLength = LeadConsts.MinPagerNumberLength)]
        public virtual string PagerNumber { get; set; }

        [StringLength(LeadConsts.MaxContactEmailLength, MinimumLength = LeadConsts.MinContactEmailLength)]
        public virtual string ContactEmail { get; set; }

        public virtual int? LeadSourceId { get; set; }

        [ForeignKey("LeadSourceId")]
        public LeadSource LeadSourceFk { get; set; }

        public virtual int? LeadStatusId { get; set; }

        [ForeignKey("LeadStatusId")]
        public LeadStatus LeadStatusFk { get; set; }

        public virtual int? PriorityId { get; set; }

        [ForeignKey("PriorityId")]
        public Priority PriorityFk { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

        public virtual string CustomerNumber { get; set; }

    }
}