using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EquipmentHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "EquipmentHistory_TenantId_index")]
    public class EquipmentHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Required]
        [StringLength(50)]
        public string EntryType { get; set; }
        public string Item { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sell { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string SaleCode { get; set; }
        [StringLength(50)]
        public string SaleAccount { get; set; }
        [StringLength(50)]
        public string CostAccount { get; set; }
        [StringLength(50)]
        public string InvAccount { get; set; }
        public bool Customer { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
