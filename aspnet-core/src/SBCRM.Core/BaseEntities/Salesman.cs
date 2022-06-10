using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Salesman", Schema = "web")]
    [Index(nameof(TenantId), Name = "Salesman_TenantId_index")]
    [Index(nameof(Number), nameof(TenantId), Name = "UC_Salesman", IsUnique = true)]
    public class Salesman : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Key]
        public long Id { get; set; }
        public int TenantId { get; set; }
        public int Number { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? EmployeeNo { get; set; }
        public short? SalesGroup { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
