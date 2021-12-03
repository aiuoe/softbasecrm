using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("AccountTypes")]
    public class AccountType : FullAuditedEntity
    {

        [Required]
        [StringLength(AccountTypeConsts.MaxDescriptionLength, MinimumLength = AccountTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

    }
}