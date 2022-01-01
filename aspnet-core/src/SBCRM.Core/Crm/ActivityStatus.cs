using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using SBCRM.Crm.Support;

namespace SBCRM.Crm
{
    /// <summary>
    /// Table wich storages the activity statutes used on the Activities Module, this table belongs to Configuration module
    /// </summary>
    [Table("ActivityStatuses")]
    [Audited]
    public class ActivityStatus : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(ActivityStatusConsts.MaxDescriptionLength, MinimumLength = ActivityStatusConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        [Required]
        [StringLength(ActivityStatusConsts.MaxColorLength, MinimumLength = ActivityStatusConsts.MinColorLength)]
        public virtual string Color { get; set; }

        public virtual bool IsCompletedStatus { get; set; }

        public virtual bool IsDefault { get; set; }
    }
}