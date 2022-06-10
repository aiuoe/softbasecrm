using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MechanicLabor", Schema = "web")]
    [Index(nameof(TenantId), Name = "MechanicLabor_TenantId_index")]
    public class MechanicLabor : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        public int? MechanicNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LaborDate { get; set; }
        [Column("WOArrivalID")]
        public int? WoarrivalId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ArrivalDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DepartureDateTime { get; set; }
        [StringLength(50)]
        public string DispatchName { get; set; }
        [StringLength(100)]
        public string Section { get; set; }
        public bool TravelFlag { get; set; }
        public bool LostTimeFlag { get; set; }
        public bool IsMigrated { get; set; }
    }
}
