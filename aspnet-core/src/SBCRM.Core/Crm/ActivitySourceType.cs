using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// Activity Source Type table entity
    /// </summary>
    [Table("ActivitySourceTypes")]
    public class ActivitySourceType : FullAuditedEntity
    {

        [Required]
        [StringLength(ActivitySourceTypeConsts.MaxDescriptionLength, MinimumLength = ActivitySourceTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        public virtual int EnumValue { get; set; }

    }
}