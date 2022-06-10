using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsBinTrips", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsBinTrips_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(TenantId), Name = "UC_PartsBinTrips", IsUnique = true)]
    public class PartsBinTrip : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        public int? BinTrips1 { get; set; }
        public int? BinTrips2 { get; set; }
        public int? BinTrips3 { get; set; }
        public int? BinTrips4 { get; set; }
        public int? BinTrips5 { get; set; }
        public int? BinTrips6 { get; set; }
        public int? BinTrips7 { get; set; }
        public int? BinTrips8 { get; set; }
        public int? BinTrips9 { get; set; }
        public int? BinTrips10 { get; set; }
        public int? BinTrips11 { get; set; }
        public int? BinTrips12 { get; set; }
        public int? BinTripsLast1 { get; set; }
        public int? BinTripsLast2 { get; set; }
        public int? BinTripsLast3 { get; set; }
        public int? BinTripsLast4 { get; set; }
        public int? BinTripsLast5 { get; set; }
        public int? BinTripsLast6 { get; set; }
        public int? BinTripsLast7 { get; set; }
        public int? BinTripsLast8 { get; set; }
        public int? BinTripsLast9 { get; set; }
        public int? BinTripsLast10 { get; set; }
        public int? BinTripsLast11 { get; set; }
        public int? BinTripsLast12 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRoll { get; set; }
        public bool IsMigrated { get; set; }
    }
}
