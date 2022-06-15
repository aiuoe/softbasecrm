using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TrailerCheckIn", Schema = "web")]
    [Index(nameof(TenantId), Name = "TrailerCheckIn_TenantId_index")]
    public class TrailerCheckIn : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("UniqueID")]
        public int? UniqueId { get; set; }
        [Required]
        [StringLength(50)]
        public string Customer { get; set; }
        [Required]
        [StringLength(50)]
        public string Unit { get; set; }
        [StringLength(100)]
        public string Comments { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public short? Disposition { get; set; }
        public DateTime? EntryDate { get; set; }
        [StringLength(150)]
        public string EntryWho { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResolutionDate { get; set; }
        public short? Branch { get; set; }
        [StringLength(50)]
        public string Spot { get; set; }
        [Column("zSpotDate")]
        public DateTime? ZSpotDate { get; set; }
        public DateTime? LastChangedDate { get; set; }
        [StringLength(150)]
        public string LastChangedWho { get; set; }
        public bool IsMigrated { get; set; }
    }
}
