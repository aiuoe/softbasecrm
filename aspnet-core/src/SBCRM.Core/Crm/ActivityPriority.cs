using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using SBCRM.Crm.Support;

namespace SBCRM.Crm
{
    /// <summary>
    /// Activity Priority table entity
    /// </summary>
    [Table("ActivityPriorities")]
    [Audited]
    public class ActivityPriority : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(ActivityPriorityConsts.MaxDescriptionLength, MinimumLength = ActivityPriorityConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        [Required]
        [StringLength(ActivityPriorityConsts.MaxColorLength, MinimumLength = ActivityPriorityConsts.MinColorLength)]
        public virtual string Color { get; set; }

        public virtual int Order { get; set; }

        public virtual bool IsDefault { get; set; }
    }
}