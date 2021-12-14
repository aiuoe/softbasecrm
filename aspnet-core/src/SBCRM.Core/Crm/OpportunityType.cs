using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("OpportunityTypes")]
    public class OpportunityType : FullAuditedEntity
    {

        [Required]
        [StringLength(OpportunityTypeConsts.MaxDescriptionLength, MinimumLength = OpportunityTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

    }
}