using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SBCRM.Crm
{
    /// <summary>
    /// Table wich storages the activity types used on the Activities Module, this table belongs to Configuration module
    /// </summary>
    [Table("ActivityTaskTypes")]
    public class ActivityTaskType : FullAuditedEntity
    {

        [StringLength(ActivityTaskTypeConsts.MaxDescriptionLength, MinimumLength = ActivityTaskTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        public string Color { get; set; }
        
        public virtual bool IsDefault { get; set; }

        [StringLength(ActivityTaskTypeConsts.MaxCodeLength, MinimumLength = ActivityTaskTypeConsts.MinCodeLength)]
        public virtual string Code { get; set; }

    }
}