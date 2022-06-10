using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsVendorAlias", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsVendorAlias_TenantId_index")]
    [Index(nameof(PartNo), nameof(VendorNo), nameof(TenantId), Name = "UC_PartsVendorAlias", IsUnique = true)]
    public class PartsVendorAlias : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string VendorPartNo { get; set; }
        [StringLength(50)]
        public string VendorDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [StringLength(100)]
        public string LastUpdateBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
