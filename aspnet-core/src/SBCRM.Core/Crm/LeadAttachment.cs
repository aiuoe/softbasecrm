using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("LeadAttachments")]
    public class LeadAttachment : FullAuditedEntity
    {

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string FilePath { get; set; }

        public virtual int? LeadId { get; set; }

        [ForeignKey("LeadId")]
        public Lead LeadFk { get; set; }

    }
}