using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("BranchARCurrency", Schema = "web")]
    [Index(nameof(TenantId), Name = "BranchARCurrency_TenantId_index")]
    [Index(nameof(Branch), nameof(CurrencyType), nameof(TenantId), Name = "UC_BranchARCurrency", IsUnique = true)]
    public class BranchArcurrency : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int Branch { get; set; }
        [Required]
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column("ARAccountNo")]
        [StringLength(50)]
        public string AraccountNo { get; set; }
        [StringLength(50)]
        public string DebitAccount { get; set; }
        [StringLength(50)]
        public string CreditAccount { get; set; }
        [StringLength(50)]
        public string DebitAccountReevaluate { get; set; }
        [StringLength(50)]
        public string CreditAccountReevaluate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
