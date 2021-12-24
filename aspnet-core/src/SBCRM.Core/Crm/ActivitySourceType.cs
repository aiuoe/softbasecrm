using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("ActivitySourceTypes")]
    public class ActivitySourceType : FullAuditedEntity
    {

        [Required]
        [StringLength(ActivitySourceTypeConsts.MaxDescriptionLength, MinimumLength = ActivitySourceTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

    }
}