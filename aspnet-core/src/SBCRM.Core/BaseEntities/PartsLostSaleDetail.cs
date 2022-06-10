using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsLostSaleDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsLostSaleDetail_TenantId_index")]
    public class PartsLostSaleDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Warehouse { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        public int? EmployeeNo { get; set; }
        [StringLength(100)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [StringLength(50)]
        public string ReasonCode { get; set; }
        public short? NoDemand { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
