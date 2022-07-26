using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("BebQuotes", Schema = "web")]
    [Index(nameof(TenantId), Name = "BebQuotes_TenantId_index")]
    public class BebQuote : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(100)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [Column("BEBQuoteNo")]
        [StringLength(100)]
        public string BebquoteNo { get; set; }
        [StringLength(50)]
        public string Probability { get; set; }
        public short? Quantity { get; set; }
        [StringLength(256)]
        public string Models { get; set; }
        [StringLength(255)]
        public string QuoteLink { get; set; }
        [StringLength(255)]
        public string QuickLink { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiresDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
