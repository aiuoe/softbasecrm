using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("OrdersFreight", Schema = "web")]
    [Index(nameof(TenantId), Name = "OrdersFreight_TenantId_index")]
    public class OrdersFreight : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int OrderNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Freight { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Customs { get; set; }
        [StringLength(100)]
        public string RecvBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
