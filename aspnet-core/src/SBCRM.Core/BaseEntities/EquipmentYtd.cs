using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EquipmentYTD", Schema = "web")]
    [Index(nameof(TenantId), Name = "EquipmentYTD_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_EquipmentYTD", IsUnique = true)]
    public class EquipmentYtd : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Column("ServiceYTD", TypeName = "decimal(19, 4)")]
        public decimal? ServiceYtd { get; set; }
        [Column("PartsYTD", TypeName = "decimal(19, 4)")]
        public decimal? PartsYtd { get; set; }
        [Column("LaborYTD", TypeName = "decimal(19, 4)")]
        public decimal? LaborYtd { get; set; }
        [Column("MiscYTD", TypeName = "decimal(19, 4)")]
        public decimal? MiscYtd { get; set; }
        [Column("IncomeYTD", TypeName = "decimal(19, 4)")]
        public decimal? IncomeYtd { get; set; }
        [Column("RentalYTD", TypeName = "decimal(19, 4)")]
        public decimal? RentalYtd { get; set; }
        [Column("ServiceYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? ServiceYtdcost { get; set; }
        [Column("PartsYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? PartsYtdcost { get; set; }
        [Column("LaborYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? LaborYtdcost { get; set; }
        [Column("MiscYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? MiscYtdcost { get; set; }
        [Column("IncomeYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? IncomeYtdcost { get; set; }
        [Column("InternalServiceYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalServiceYtd { get; set; }
        [Column("InternalPartsYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalPartsYtd { get; set; }
        [Column("InternalLaborYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalLaborYtd { get; set; }
        [Column("InternalMiscYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalMiscYtd { get; set; }
        [Column("InternalIncomeYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalIncomeYtd { get; set; }
        [Column("InternalRentalYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalRentalYtd { get; set; }
        [Column("InternalServiceYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalServiceYtdcost { get; set; }
        [Column("InternalPartsYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalPartsYtdcost { get; set; }
        [Column("InternalLaborYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalLaborYtdcost { get; set; }
        [Column("InternalMiscYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalMiscYtdcost { get; set; }
        [Column("InternalIncomeYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalIncomeYtdcost { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
