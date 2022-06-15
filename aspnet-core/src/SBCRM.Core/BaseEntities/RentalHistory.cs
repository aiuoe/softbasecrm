using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RentalHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "RentalHistory_TenantId_index")]
    [Index(nameof(SerialNo), nameof(Year), nameof(Month), nameof(TenantId), Name = "UC_RentalHistory", IsUnique = true)]
    public class RentalHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public int? DaysRented { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentAmount { get; set; }
        public bool IsMigrated { get; set; }
    }
}
