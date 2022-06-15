using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ChartOfAccounts", Schema = "web")]
    [Index(nameof(TenantId), Name = "ChartOfAccounts_TenantId_index")]
    [Index(nameof(AccountNo), nameof(TenantId), Name = "UC_ChartOfAccounts", IsUnique = true)]
    public class ChartOfAccount : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [Column("GPAccountNo")]
        [StringLength(50)]
        public string GpaccountNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool? Controlled { get; set; }
        public bool? AccountsRecievable { get; set; }
        public bool? AccountsPayable { get; set; }
        public bool? CashAccount { get; set; }
        [StringLength(50)]
        public string ReportType { get; set; }
        [StringLength(50)]
        public string Branch { get; set; }
        [StringLength(50)]
        public string Department { get; set; }
        [StringLength(50)]
        public string Section { get; set; }
        [StringLength(50)]
        public string SectionGroup { get; set; }
        [StringLength(50)]
        public string Item { get; set; }
        [StringLength(50)]
        public string ItemDescription { get; set; }
        [StringLength(50)]
        public string Sort1 { get; set; }
        [StringLength(50)]
        public string Sort2 { get; set; }
        [StringLength(50)]
        public string Sort3 { get; set; }
        [StringLength(50)]
        public string Sort4 { get; set; }
        [StringLength(50)]
        public string Sort5 { get; set; }
        [StringLength(50)]
        public string Sort6 { get; set; }
        [StringLength(50)]
        public string OldAccountNo { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(50)]
        public string CurrencyExchangeAccount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        public bool? Inactive { get; set; }
        [Column("WIPAccount")]
        [StringLength(50)]
        public string Wipaccount { get; set; }
        [Column("AccruedPOAccount")]
        [StringLength(50)]
        public string AccruedPoaccount { get; set; }
        public bool? TaxFlag { get; set; }
        [StringLength(50)]
        public string PaidTaxAccount { get; set; }
        [StringLength(50)]
        public string PaidTaxProfitAccount { get; set; }
        [StringLength(50)]
        public string PaidTaxLossAccount { get; set; }
        [Column("PSCompany")]
        [StringLength(50)]
        public string Pscompany { get; set; }
        [Column("PSAccount")]
        [StringLength(50)]
        public string Psaccount { get; set; }
        [Column("PSLocation")]
        [StringLength(50)]
        public string Pslocation { get; set; }
        [Column("PSDept")]
        [StringLength(50)]
        public string Psdept { get; set; }
        [Column("PSProduct")]
        [StringLength(50)]
        public string Psproduct { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
