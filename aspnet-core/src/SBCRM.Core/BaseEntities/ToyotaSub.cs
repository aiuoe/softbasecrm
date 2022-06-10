using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ToyotaSub", Schema = "web")]
    [Index(nameof(TenantId), Name = "ToyotaSub_TenantId_index")]
    [Index(nameof(PartNo), nameof(ChangeSequenceCount), nameof(TenantId), Name = "UC_ToyotaSub", IsUnique = true)]
    public class ToyotaSub : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(50)]
        public string RecordType { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        public short ChangeSequenceCount { get; set; }
        public short? ChangeSequenceTotal { get; set; }
        [StringLength(50)]
        public string NewPartNo { get; set; }
        [StringLength(1)]
        public string SubstitutionCode { get; set; }
        public short? QuantityPerAssy { get; set; }
        [Column("PartNoWDash")]
        [StringLength(50)]
        public string PartNoWdash { get; set; }
        [Column("NewPartNoWDash")]
        [StringLength(50)]
        public string NewPartNoWdash { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
