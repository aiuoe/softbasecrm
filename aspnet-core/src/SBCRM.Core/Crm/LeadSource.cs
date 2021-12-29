using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Crm
{
    [Table("LeadSources")]
    public class LeadSource : FullAuditedEntity
    {
        [Required]
        [StringLength(LeadSourceConsts.MaxDescriptionLength, MinimumLength = LeadSourceConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        public virtual bool IsDefault { get; set; }
    }
}