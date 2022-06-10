using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PM", Schema = "web")]
    [Index(nameof(TenantId), Name = "PM_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_PM", IsUnique = true)]
    public class Pm : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string SaleCode { get; set; }
        public short? ExpBranch { get; set; }
        public short? ExpDept { get; set; }
        [StringLength(50)]
        public string ExpCode { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [StringLength(50)]
        public string ShipTo { get; set; }
        [StringLength(50)]
        public string MapLocation { get; set; }
        [StringLength(50)]
        public string CustomerContact { get; set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; set; }
        [Column("OpenPmWO")]
        public bool OpenPmWo { get; set; }
        [Column("WONo", TypeName = "decimal(19, 4)")]
        public decimal? Wono { get; set; }
        public short? Frequency { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FrequencyHours { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLaborDate { get; set; }
        [Column("NextPMDate", TypeName = "datetime")]
        public DateTime? NextPmdate { get; set; }
        public int? DaysRented { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscCharge { get; set; }
        [StringLength(50)]
        public string MiscDescription { get; set; }
        [StringLength(50)]
        public string Salesman { get; set; }
        [StringLength(50)]
        public string Mechanic { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CurrentHourMeter { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastHourMeter { get; set; }
        public bool Automatic { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SignUpDate { get; set; }
        public string Comments { get; set; }
        public string Notes { get; set; }
        [Column("PMCancelled")]
        public bool Pmcancelled { get; set; }
        [Column("PMCancelledDate", TypeName = "datetime")]
        public DateTime? PmcancelledDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EstLaborHours { get; set; }
        public short? PassCount { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string ContactPhone { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [StringLength(100)]
        public string ContactEmail { get; set; }
        [StringLength(200)]
        public string ContactEmailSubject { get; set; }
        [StringLength(1024)]
        public string ContactEmailBody { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
