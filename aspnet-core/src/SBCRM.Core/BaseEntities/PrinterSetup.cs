using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PrinterSetup", Schema = "web")]
    [Index(nameof(TenantId), Name = "PrinterSetup_TenantId_index")]
    [Index(nameof(EmployeeNo), nameof(TenantId), Name = "UC_PrinterSetup", IsUnique = true)]
    public class PrinterSetup : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int EmployeeNo { get; set; }
        [StringLength(100)]
        public string SecureName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }
        [Column("BData", TypeName = "image")]
        public byte[] Bdata { get; set; }
        public bool IsMigrated { get; set; }
    }
}
