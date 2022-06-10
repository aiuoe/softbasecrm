using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SalesmanCommission", Schema = "web")]
    [Index(nameof(TenantId), Name = "SalesmanCommission_TenantId_index")]
    [Index(nameof(Name), nameof(AccountNo), nameof(TenantId), Name = "UC_SalesmanCommission", IsUnique = true)]
    public class SalesmanCommission : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Commission { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
