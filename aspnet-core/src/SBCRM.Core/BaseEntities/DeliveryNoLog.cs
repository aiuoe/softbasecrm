using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("DeliveryNoLog", Schema = "web")]
    [Index(nameof(TenantId), Name = "DeliveryNoLog_TenantId_index")]
    [Index(nameof(DeliveryNo), nameof(TenantId), Name = "UC_DeliveryNoLog", IsUnique = true)]
    public class DeliveryNoLog : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int DeliveryNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        [StringLength(100)]
        public string SerialNo { get; set; }
        public int? RentalDays { get; set; }
        public int? TransportationHours { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DeliveryCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ReturnCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DeliveryHourMeter { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
