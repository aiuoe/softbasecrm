using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EFTData", Schema = "web")]
    [Index(nameof(TenantId), Name = "EFTData_TenantId_index")]
    [Index(nameof(Eftno), nameof(TenantId), Name = "UC_EFTData", IsUnique = true)]
    public class Eftdatum : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("EFTNo")]
        public int Eftno { get; set; }
        [Column("EFTDate", TypeName = "datetime")]
        public DateTime? Eftdate { get; set; }
        [Column("EFTAmount", TypeName = "decimal(19, 4)")]
        public decimal? Eftamount { get; set; }
        [StringLength(50)]
        public string CashAccount { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        public int? Posted { get; set; }
        [StringLength(100)]
        public string PostedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedDate { get; set; }
        public bool Cleared { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCleared { get; set; }
        [StringLength(100)]
        public string ClearedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ClearedEntryDate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
