using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOPartsSerialNo", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOPartsSerialNo_TenantId_index")]
    [Index(nameof(Wono), nameof(EntryDate), nameof(SerialNo), nameof(TenantId), Name = "UC_WOPartsSerialNo", IsUnique = true)]
    public class WopartsSerialNo : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
