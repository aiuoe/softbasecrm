using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PMSecondary", Schema = "web")]
    [Index(nameof(TenantId), Name = "PMSecondary_TenantId_index")]
    [Index(nameof(SerialNo), nameof(Pmname), nameof(TenantId), Name = "UC_PMSecondary", IsUnique = true)]
    public class Pmsecondary : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EstLaborHours { get; set; }
        public short? PassCount { get; set; }
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Required]
        [Column("PMName")]
        [StringLength(50)]
        public string Pmname { get; set; }
        public short? Frequency { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLaborDate { get; set; }
        [Column("NextPMDate", TypeName = "datetime")]
        public DateTime? NextPmdate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FrequencyHours { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastHourMeter { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscCharge { get; set; }
        [StringLength(50)]
        public string MiscDescription { get; set; }
        [Column("PMCancelled")]
        public short? Pmcancelled { get; set; }
        [Column("PMCancelledDate", TypeName = "datetime")]
        public DateTime? PmcancelledDate { get; set; }
        public string Comments { get; set; }
        [Column("UpdateBasicPM")]
        public short? UpdateBasicPm { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
