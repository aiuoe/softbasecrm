using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOArrival", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOArrival_TenantId_index")]
    public class Woarrival : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [StringLength(50)]
        public string DispatchName { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Longitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Altitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Heading { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Speed { get; set; }
        public bool? TravelFlag { get; set; }
        public bool? LostTimeFlag { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DepartureLatitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DepartureLongitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DepartureAltitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DepartureHeading { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DepartureSpeed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OriginalArrivalDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OriginalDepartureDateTime { get; set; }
        [StringLength(100)]
        public string Section { get; set; }
        public bool? ImportFlag { get; set; }
        public int? LegacyId { get; set; }
        [Column("LaborTypeROP")]
        [StringLength(50)]
        public string LaborTypeRop { get; set; }
        public bool IsMigrated { get; set; }
    }
}
