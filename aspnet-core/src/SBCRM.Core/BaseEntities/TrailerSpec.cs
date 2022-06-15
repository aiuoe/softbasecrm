using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TrailerSpecs", Schema = "web")]
    [Index(nameof(TenantId), Name = "TrailerSpecs_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_TrailerSpecs", IsUnique = true)]
    public class TrailerSpec : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        public int? ModelYear { get; set; }
        [StringLength(100)]
        public string Length { get; set; }
        [StringLength(100)]
        public string Width { get; set; }
        [StringLength(100)]
        public string Height { get; set; }
        [StringLength(100)]
        public string InternalHeight { get; set; }
        [StringLength(100)]
        public string Composition { get; set; }
        [Column("GVW")]
        public int? Gvw { get; set; }
        [Column("GVWR")]
        public int? Gvwr { get; set; }
        public int? PayloadCapacity { get; set; }
        [StringLength(100)]
        public string TypeofNeck { get; set; }
        public int? NumberofRearAxles { get; set; }
        [StringLength(100)]
        public string Doors { get; set; }
        public bool? Insulated { get; set; }
        public bool? LiftGate { get; set; }
        [StringLength(100)]
        public string Suspension { get; set; }
        [StringLength(100)]
        public string FloorType { get; set; }
        [StringLength(100)]
        public string Tires { get; set; }
        [StringLength(100)]
        public string Wheels { get; set; }
        [StringLength(100)]
        public string AxleType { get; set; }
        public bool? Skirts { get; set; }
        [StringLength(100)]
        public string SkirtType { get; set; }
        [StringLength(100)]
        public string ReeferSerialNo { get; set; }
        [StringLength(100)]
        public string ReeferMake { get; set; }
        [StringLength(100)]
        public string ReeferModel { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
