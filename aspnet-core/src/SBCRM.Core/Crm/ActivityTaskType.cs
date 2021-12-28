using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

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

        public virtual bool IsDefault { get; set; }

        public virtual int EnumValue { get; set; }

    }
}