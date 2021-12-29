using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SBCRM.Legacy;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// Lead entity
    /// </summary>
    [Table("Leads")]
    [Audited]
    public class Lead : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(LeadConsts.MaxCompanyNameLength)]
        public virtual string CompanyName { get; set; }

        [StringLength(LeadConsts.MaxContactNameLength)]
        public virtual string ContactName { get; set; }

        [StringLength(LeadConsts.MaxContactPositionLength)]
        public virtual string ContactPosition { get; set; }

        [StringLength(LeadConsts.MaxWebSiteLength)]
        public virtual string WebSite { get; set; }

        [StringLength(LeadConsts.MaxAddressLength)]
        public virtual string Address { get; set; }

        [StringLength(LeadConsts.MaxCountryLength)]
        public virtual string Country { get; set; }

        [StringLength(LeadConsts.MaxStateLength)]
        public virtual string State { get; set; }


        [StringLength(LeadConsts.MaxCityLength)]
        public virtual string City { get; set; }

        public virtual string Notes { get; set; }

        [Phone]
        public virtual string CompanyPhone { get; set; }

        [EmailAddress]
        public virtual string CompanyEmail { get; set; }

        [StringLength(LeadConsts.MaxPoBoxLength)]
        public virtual string PoBox { get; set; }

        [StringLength(LeadConsts.MaxZipCodeLength)]
        public virtual string ZipCode { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneLength)]
        public virtual string ContactPhone { get; set; }

        [StringLength(LeadConsts.MaxContactPhoneExtensionLength)]
        public virtual string ContactPhoneExtension { get; set; }

        [StringLength(LeadConsts.MaxContactCellPhoneLength)]
        public virtual string ContactCellPhone { get; set; }

        [StringLength(LeadConsts.MaxContactFaxNumberLength)]
        public virtual string ContactFaxNumber { get; set; }

        [StringLength(LeadConsts.MaxPagerNumberLength)]
        public virtual string PagerNumber { get; set; }

        [StringLength(LeadConsts.MaxContactEmailLength)]
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

        public List<LeadUser> Users { get; set; }
        
    }
}