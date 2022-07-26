using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("FuelHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "FuelHistory_TenantId_index")]
    [Index(nameof(SerialNo), nameof(EntryDate), nameof(TenantId), Name = "UC_FuelHistory", IsUnique = true)]
    public class FuelHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [StringLength(50)]
        public string EntryBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Odometer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FuelDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FuelAmount { get; set; }
        public short? Branch { get; set; }
        [StringLength(50)]
        public string PumpNo { get; set; }
        [StringLength(50)]
        public string FieldType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ValuePerUnit { get; set; }
        [StringLength(50)]
        public string UnitNo { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
