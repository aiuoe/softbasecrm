using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace SBCRM.Crm
{
    [Table("Priorities")]
    [Audited]
    public class Priority : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(PriorityConsts.MaxDescriptionLength, MinimumLength = PriorityConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual bool IsDefault { get; set; }

        [Required]
        [StringLength(PriorityConsts.MaxColorLength, MinimumLength = PriorityConsts.MinColorLength)]
        public virtual string Color { get; set; }

    }
}