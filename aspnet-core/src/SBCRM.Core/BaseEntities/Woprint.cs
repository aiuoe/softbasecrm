using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOPrint", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOPrint_TenantId_index")]
    [Index(nameof(EmployeeNo), nameof(Wono), nameof(EntryDate), nameof(TenantId), Name = "UC_WOPrint", IsUnique = true)]
    public class Woprint : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int EmployeeNo { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [StringLength(50)]
        public string ShipTo { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string MapLocation { get; set; }
        [Column("PMDueDate", TypeName = "datetime")]
        public DateTime? PmdueDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
