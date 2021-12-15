using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("Priorities")]
    public class Priority : FullAuditedEntity
    {

        [Required]
        [StringLength(PriorityConsts.MaxDescriptionLength, MinimumLength = PriorityConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual bool IsDefault { get; set; }

    }
}