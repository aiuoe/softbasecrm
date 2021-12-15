using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("LeadStatuses")]
    public class LeadStatus : FullAuditedEntity
    {

        [Required]
        [StringLength(LeadStatusConsts.MaxDescriptionLength, MinimumLength = LeadStatusConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        [Required]
        [StringLength(LeadStatusConsts.MaxColorLength, MinimumLength = LeadStatusConsts.MinColorLength)]
        public virtual string Color { get; set; }

        public virtual bool IsLeadConversionValid { get; set; }

        public virtual bool IsDefault { get; set; }

    }
}