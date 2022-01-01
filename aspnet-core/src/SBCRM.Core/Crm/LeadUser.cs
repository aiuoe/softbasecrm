using SBCRM.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// This class stores Users connected to leads
    /// </summary>
    [Table("LeadUsers")]
    [Audited]
    public class LeadUser : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public virtual int? LeadId { get; set; }

        [ForeignKey("LeadId")]
        public Lead LeadFk { get; set; }

        public virtual long? UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }
    }
}