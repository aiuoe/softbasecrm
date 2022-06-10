using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CheckDataTemp", Schema = "web")]
    [Index(nameof(TenantId), Name = "CheckDataTemp_TenantId_index")]
    public class CheckDataTemp : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int SequenceNo { get; set; }
        public long? CheckNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CheckDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CheckAmount { get; set; }
        [StringLength(50)]
        public string CashAccount { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        public bool Printed { get; set; }
        [StringLength(50)]
        public string PrintedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PrintedDate { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
