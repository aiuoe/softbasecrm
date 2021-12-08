using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("Industries")]
    public class Industry : FullAuditedEntity
    {

        [Required]
        [StringLength(IndustryConsts.MaxDescriptionLength, MinimumLength = IndustryConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

    }
}