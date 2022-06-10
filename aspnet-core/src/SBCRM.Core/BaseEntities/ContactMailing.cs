using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ContactMailing", Schema = "web")]
    [Index(nameof(TenantId), Name = "ContactMailing_TenantId_index")]
    [Index(nameof(CustomerNo), nameof(Contact), nameof(Category), nameof(TenantId), Name = "UC_ContactMailing", IsUnique = true)]
    public class ContactMailing : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string CustomerNo { get; set; }
        [Required]
        [StringLength(100)]
        public string Contact { get; set; }
        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
