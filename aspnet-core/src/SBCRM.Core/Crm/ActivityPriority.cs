using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// Activity Priority table entity
    /// </summary>
    [Table("ActivityPriorities")]
    public class ActivityPriority : FullAuditedEntity
    {

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