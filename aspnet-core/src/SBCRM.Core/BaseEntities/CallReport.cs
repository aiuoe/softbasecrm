using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CallReports", Schema = "web")]
    [Index(nameof(TenantId), Name = "CallReports_TenantId_index")]
    public class CallReport : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CallDate { get; set; }
        [StringLength(50)]
        public string Salesman { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public string Comments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FollowupDate { get; set; }
        public short? Complete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BillableHours { get; set; }
        public short? ScheduleFollowup { get; set; }
        public int LegacyId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
