using SBCRM.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace SBCRM.Crm
{
    /// <summary>
    /// This class stores Users connected to opportunities
    /// </summary>
    [Table("OpportunityUsers")]
    [Audited]
    public class OpportunityUser : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

        public virtual int OpportunityId { get; set; }

        [ForeignKey("OpportunityId")]
        public Opportunity OpportunityFk { get; set; }
    }
}