using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("ActivityTaskTypes")]
    public class ActivityTaskType : FullAuditedEntity
    {

        [StringLength(ActivityTaskTypeConsts.MaxDescriptionLength, MinimumLength = ActivityTaskTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

    }
}