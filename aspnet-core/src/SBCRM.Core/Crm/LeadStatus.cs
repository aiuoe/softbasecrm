using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("LeadStatuses")]
    [Audited]
    public class LeadStatus : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(LeadStatusConsts.MaxDescriptionLength, MinimumLength = LeadStatusConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        [Required]
        [StringLength(LeadStatusConsts.MaxColorLength, MinimumLength = LeadStatusConsts.MinColorLength)]
        public virtual string Color { get; set; }

        [StringLength(LeadStatusConsts.MaxCodeLength)]
        public virtual string Code { get; set; }

        public virtual bool IsLeadConversionValid { get; set; }

        public virtual bool IsDefault { get; set; }

        public virtual int Order { get; set; }
    }
}