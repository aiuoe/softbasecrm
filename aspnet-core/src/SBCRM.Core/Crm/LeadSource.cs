using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SBCRM.Crm
{
    /// <summary>
    /// Lead Source entity
    /// </summary>
    [Table("LeadSources")]
    public class LeadSource : FullAuditedEntity
    {
        [Required]
        [StringLength(LeadSourceConsts.MaxDescriptionLength, MinimumLength = LeadSourceConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }
    }
}