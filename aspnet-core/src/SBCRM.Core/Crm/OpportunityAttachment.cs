using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// Table to manage the attachments related to an Opportunity
    /// </summary>
    [Table("OpportunityAttachments")]
    public class OpportunityAttachment : FullAuditedEntity
    {

        [Required]
        [StringLength(OpportunityAttachmentConsts.MaxNameLength, MinimumLength = OpportunityAttachmentConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(OpportunityAttachmentConsts.MaxFilePathLength, MinimumLength = OpportunityAttachmentConsts.MinFilePathLength)]
        public virtual string FilePath { get; set; }

        public virtual int? OpportunityId { get; set; }

        [ForeignKey("OpportunityId")]
        public Opportunity OpportunityFk { get; set; }

    }
}