using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace SBCRM.Crm
{
    /// <summary>
    /// Account Type entity
    /// </summary>
    [Table("AccountTypes")]
    public class AccountType : FullAuditedEntity
    {

        [Required]
        [StringLength(AccountTypeConsts.MaxDescriptionLength, MinimumLength = AccountTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

    }
}