using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CheckData", Schema = "web")]
    [Index(nameof(TenantId), Name = "CheckData_TenantId_index")]
    [Index(nameof(CheckNo), nameof(TenantId), Name = "UC_CheckData", IsUnique = true)]
    public class CheckDatum : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int CheckNo { get; set; }
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
        public bool Posted { get; set; }
        [StringLength(50)]
        public string PostedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedDate { get; set; }
        public bool Cleared { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCleared { get; set; }
        [StringLength(50)]
        public string ClearedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ClearedEntryDate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
