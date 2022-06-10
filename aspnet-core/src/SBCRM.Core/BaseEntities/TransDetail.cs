using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TransDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "TransDetail_TenantId_index")]
    public class TransDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? TrackingNo { get; set; }
        public int? Waypoint { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [StringLength(100)]
        public string UnitNo { get; set; }
        [StringLength(50)]
        public string TransReason { get; set; }
        public int? RentalContractNo { get; set; }
        [Column("EquipmentSaleWONo")]
        public int? EquipmentSaleWono { get; set; }
        [Column("ServiceWONo")]
        public int? ServiceWono { get; set; }
        [Column("TransportChargeWONo")]
        public int? TransportChargeWono { get; set; }
        public short? Branch { get; set; }
        public short? Dept { get; set; }
        public string PublicComments { get; set; }
        public string PrivateComments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ScheduledPickup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ScheduledDelivery { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActualPickup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActualDelivery { get; set; }
        [Column("EQPONo")]
        public int? Eqpono { get; set; }
        public int? OriginAtDealer { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string ZipCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(100)]
        public string LastUpdatedBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AllocatedHours { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        public int? LegacyId { get; set; }
        public int? TinnacityShippingNo { get; set; }
        public bool IsMigrated { get; set; }
    }
}
