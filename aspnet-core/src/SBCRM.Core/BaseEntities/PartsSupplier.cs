using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsSuppliers", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsSuppliers_TenantId_index")]
    public class PartsSupplier : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Supplier { get; set; }
        [StringLength(50)]
        public string PrefixToAdd { get; set; }
        [Column("MFGCode")]
        [StringLength(50)]
        public string Mfgcode { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
