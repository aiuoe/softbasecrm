using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using SBCRM.Crm.Support;

namespace SBCRM.Crm
{
    [Table("OpportunityStages")]
    [Audited]
    public class OpportunityStage : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(OpportunityStageConsts.MaxDescriptionLength, MinimumLength = OpportunityStageConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        [Required]
        [StringLength(OpportunityStageConsts.MaxColorLength, MinimumLength = OpportunityStageConsts.MinColorLength)]
        public virtual string Color { get; set; }
    }
}