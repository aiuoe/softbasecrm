using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsTransfer", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsTransfer_TenantId_index")]
    [Index(nameof(TransferDate), nameof(PartNo), nameof(FromWarehouse), nameof(TenantId), Name = "UC_PartsTransfer", IsUnique = true)]
    public class PartsTransfer : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransferDate { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string FromWarehouse { get; set; }
        [StringLength(50)]
        public string ToWarehouse { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(50)]
        public string Bin { get; set; }
        [StringLength(50)]
        public string FromAccount { get; set; }
        [StringLength(50)]
        public string ToAccount { get; set; }
        [StringLength(50)]
        public string TransferedBy { get; set; }
        [Column("AssociatedWONo")]
        public int? AssociatedWono { get; set; }
        public string Comments { get; set; }
        [Column("TransferIDNo")]
        public int? TransferIdno { get; set; }
        public bool IsMigrated { get; set; }
    }
}
