using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WebPartsOrder", Schema = "web")]
    [Index(nameof(TenantId), Name = "WebPartsOrder_TenantId_index")]
    public class WebPartsOrder : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("CustomerPONo")]
        [StringLength(50)]
        public string CustomerPono { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string RequestedPartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        public short? ImportFlag { get; set; }
        [StringLength(100)]
        public string EnteredBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ImportDate { get; set; }
        [StringLength(100)]
        public string ImportedBy { get; set; }
        [Column("ImportedToWONo")]
        public int? ImportedToWono { get; set; }
        [StringLength(50)]
        public string ShipVia { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [StringLength(50)]
        public string Warehouse { get; set; }
        [StringLength(100)]
        public string Section { get; set; }
        public int UniqueField { get; set; }
        public bool IsMigrated { get; set; }
    }
}
