using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ServiceVanTemp", Schema = "web")]
    [Index(nameof(TenantId), Name = "ServiceVanTemp_TenantId_index")]
    [Index(nameof(CreationTime), nameof(PartNo), nameof(Warehouse), nameof(FromWarehouse), nameof(TenantId), Name = "UC_ServiceVanTemp", IsUnique = true)]
    public class ServiceVanTemp : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(100)]
        public string Warehouse { get; set; }
        [Required]
        [StringLength(100)]
        public string FromWarehouse { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NeededQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(50)]
        public string ToAccount { get; set; }
        [StringLength(50)]
        public string FromAccount { get; set; }
        [StringLength(100)]
        public string ReplenishmentBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOnly { get; set; }
        [StringLength(50)]
        public string ToBinLocation { get; set; }
        [StringLength(50)]
        public string FromBinLocation { get; set; }
        public short? Branch { get; set; }
        public bool IsMigrated { get; set; }
    }
}
