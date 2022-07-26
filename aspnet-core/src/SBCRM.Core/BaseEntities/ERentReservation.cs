using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("eRentReservation", Schema = "web")]
    [Index(nameof(TenantId), Name = "eRentReservation_TenantId_index")]
    public class ERentReservation : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public long? DocumentNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        [Required]
        [Column("CustomerPO")]
        [StringLength(50)]
        public string CustomerPo { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        public string Comments { get; set; }
        [StringLength(25)]
        public string MimeType { get; set; }
        [Column(TypeName = "image")]
        public byte[] Insurance { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public bool Booked { get; set; }
        public DateTime? DateBooked { get; set; }
        [StringLength(50)]
        public string WhoBooked { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
