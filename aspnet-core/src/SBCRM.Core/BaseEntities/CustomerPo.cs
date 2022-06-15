using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CustomerPO", Schema = "web")]
    [Index(nameof(TenantId), Name = "CustomerPO_TenantId_index")]
    public class CustomerPo : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LimitAmount { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChangedDate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
