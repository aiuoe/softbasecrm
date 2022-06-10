using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CCTransactions", Schema = "web")]
    [Index(nameof(TenantId), Name = "CCTransactions_TenantId_index")]
    public class Cctransaction : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("TransID")]
        [StringLength(40)]
        public string TransId { get; set; }
        [StringLength(30)]
        public string TransactionType { get; set; }
        public DateTime? Created { get; set; }
        [Column("TransactionID")]
        public long? TransactionId { get; set; }
        [Column("smartTerminalID")]
        [StringLength(40)]
        public string SmartTerminalId { get; set; }
        [Column("RequestPaymentID")]
        [StringLength(40)]
        public string RequestPaymentId { get; set; }
        [Column("CustomerID")]
        [StringLength(10)]
        public string CustomerId { get; set; }
        public int? InvoiceNo { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public bool? Processed { get; set; }
        public DateTime? LastModified { get; set; }
        [Column("eRentResNum")]
        public long? ERentResNum { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
