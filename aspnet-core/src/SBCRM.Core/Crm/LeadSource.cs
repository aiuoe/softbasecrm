using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using SBCRM.Crm.Support;

namespace SBCRM.Crm
{
    [Table("LeadSources")]
    [Audited]
    public class LeadSource : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(LeadSourceConsts.MaxDescriptionLength, MinimumLength = LeadSourceConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        public virtual bool IsDefault { get; set; }
    }
}