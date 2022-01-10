using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    [Table("CustomerAttachments")]
    public class CustomerAttachment : FullAuditedEntity
    {

        [Required]
        [StringLength(CustomerAttachmentConsts.MaxNameLength, MinimumLength = CustomerAttachmentConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(CustomerAttachmentConsts.MaxFilePathLength, MinimumLength = CustomerAttachmentConsts.MinFilePathLength)]
        public virtual string FilePath { get; set; }

        [Required]
        public virtual string CustomerNumber { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

    }
}