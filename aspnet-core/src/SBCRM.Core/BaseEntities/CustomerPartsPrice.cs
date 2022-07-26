using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CustomerPartsPrice", Schema = "web")]
    [Index(nameof(TenantId), Name = "CustomerPartsPrice_TenantId_index")]
    [Index(nameof(CustomerNo), nameof(PartNo), nameof(TenantId), Name = "UC_CustomerPartsPrice", IsUnique = true)]
    public class CustomerPartsPrice : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
