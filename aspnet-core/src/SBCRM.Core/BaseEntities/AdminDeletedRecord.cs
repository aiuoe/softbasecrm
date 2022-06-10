using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("AdminDeletedRecords", Schema = "web")]
    [Index(nameof(TenantId), Name = "AdminDeletedRecords_TenantId_index")]
    public class AdminDeletedRecord : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(100)]
        public string TableName { get; set; }
        public int? Branch { get; set; }
        public int? Dept { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChangedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemovedDate { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [StringLength(100)]
        public string RemovedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
