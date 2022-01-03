using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using SBCRM.Crm.Support;

namespace SBCRM.Crm
{
    [Table("OpportunityTypes")]
    [Audited]
    public class OpportunityType : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(OpportunityTypeConsts.MaxDescriptionLength, MinimumLength = OpportunityTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

    }
}