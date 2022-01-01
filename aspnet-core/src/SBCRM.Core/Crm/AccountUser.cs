using SBCRM.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using SBCRM.Crm.Support;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    /// <summary>
    /// This class stores Users connected to accounts
    /// </summary>
    [Table("AccountUsers")]
    [Audited]
    public class AccountUser : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

        public virtual string CustomerNumber { get; set; }
    }
}