using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ExpCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "ExpCodes_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(Code), nameof(TenantId), Name = "UC_ExpCodes", IsUnique = true)]
    public class ExpCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public short Branch { get; set; }
        public short Dept { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Account { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string InternalCustomerNo { get; set; }
        public short? CustomerBatch { get; set; }
        public bool Taxable { get; set; }
        [Column("OverRideInvCOG")]
        public bool OverRideInvCog { get; set; }
        public bool BuildPart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Added { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
