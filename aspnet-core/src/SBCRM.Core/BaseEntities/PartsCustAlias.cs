using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsCustAlias", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsCustAlias_TenantId_index")]
    [Index(nameof(PartNo), nameof(CustomerNo), nameof(TenantId), Name = "UC_PartsCustAlias", IsUnique = true)]
    public class PartsCustAlias : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string CustomerPartNo { get; set; }
        [StringLength(50)]
        public string CustomerDescription { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string LastUpdateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
