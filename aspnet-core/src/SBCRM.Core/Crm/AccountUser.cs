using SBCRM.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    /// <summary>
    /// This class stores Users connected to accounts
    /// </summary>
    [Table("AccountUsers")]
    public class AccountUser : FullAuditedEntity
    {

        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

        public virtual string CustomerNumber { get; set; }

    }
}