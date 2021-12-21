using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SBCRM.Crm
{
    [Table("OpportunityStages")]
    public class OpportunityStage : FullAuditedEntity
    {
        /// <summary>
        /// Description Opportunity stage
        /// </summary>
        [Required]
        [StringLength(OpportunityStageConsts.MaxDescriptionLength,
            MinimumLength = OpportunityStageConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }
    }
}