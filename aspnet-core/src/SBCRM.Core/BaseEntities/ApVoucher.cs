using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("APVoucher", Schema = "web")]
    [Index(nameof(TenantId), Name = "APVoucher_TenantId_index")]
    [Index(nameof(Journal), nameof(ApinvoiceNo), nameof(VendorNo), nameof(EntryDate), nameof(TenantId), Name = "UC_APVoucher", IsUnique = true)]
    public class ApVoucher : FullAuditedEntity<long>, IMustHaveTenant
    {
        public bool? Posted { get; set; }
        [Required]
        [StringLength(50)]
        public string Journal { get; set; }
        [Required]
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [StringLength(50)]
        public string VendorName { get; set; }
        [Column("APInvoiceDate", TypeName = "datetime")]
        public DateTime? ApinvoiceDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscountDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DiscountAmount { get; set; }
        [Column("PONo")]
        public int? Pono { get; set; }
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string Comments { get; set; }
        public bool? HoldOnPost { get; set; }
        public bool? Reoccurring { get; set; }
        public short? TotalRepeats { get; set; }
        public short? FrequencyMethod { get; set; }
        public short? Frequency { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConvertedAmount { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        public int? CheckNo { get; set; }
        [StringLength(50)]
        public string CashAccountNo { get; set; }
        public bool? WriteCheckFlag { get; set; }
        [Column("ApplyToAPInvoiceNo")]
        [StringLength(50)]
        public string ApplyToApinvoiceNo { get; set; }
        [Column("WriteCCFlag")]
        public int? WriteCcflag { get; set; }
        [Column("CCVendorNo")]
        [StringLength(50)]
        public string CcvendorNo { get; set; }
        [Column("CCAccountNo")]
        [StringLength(50)]
        public string CcaccountNo { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
