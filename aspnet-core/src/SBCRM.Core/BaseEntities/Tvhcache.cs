using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TVHCache", Schema = "web")]
    [Index(nameof(TenantId), Name = "TVHCache_TenantId_index")]
    public class Tvhcache : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InquiryDate { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Quantity { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ItemPrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ListPrice { get; set; }
        public int? Available { get; set; }
        public int? InquiryCount { get; set; }
        [StringLength(100)]
        public string SecureName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
