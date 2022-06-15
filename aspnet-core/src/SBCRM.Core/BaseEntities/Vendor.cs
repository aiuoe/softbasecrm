using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Vendor", Schema = "web")]
    [Index(nameof(TenantId), Name = "Vendor_TenantId_index")]
    public class Vendor : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string VendorGroup { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SubName { get; set; }
        [StringLength(50)]
        public string MailingAddress { get; set; }
        [StringLength(50)]
        public string MailingCity { get; set; }
        [StringLength(50)]
        public string MailingState { get; set; }
        [StringLength(50)]
        public string MailingZipCode { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [StringLength(50)]
        public string StreetCity { get; set; }
        [StringLength(50)]
        public string StreetState { get; set; }
        [StringLength(50)]
        public string StreetZipCode { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Extention { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [Column("EMail")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("WWWAddress")]
        [StringLength(100)]
        public string Wwwaddress { get; set; }
        [StringLength(100)]
        public string ParentCompany { get; set; }
        [StringLength(50)]
        public string ParentCompanyNo { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        public bool? UseDays { get; set; }
        public short? DaysDue { get; set; }
        public bool? UseDayOfMonth { get; set; }
        public short? DayOfMonthDue { get; set; }
        public short? Vendor1099 { get; set; }
        [Column("FID")]
        [StringLength(50)]
        public string Fid { get; set; }
        public bool? AllowDiscounts { get; set; }
        public short? DiscountDays { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DiscountPercent { get; set; }
        public bool? AllowDiscountDayOfMonth { get; set; }
        public short? DiscountDayOfMonth { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DiscountPercentDayOfMonth { get; set; }
        public short? DiscountFreight { get; set; }
        public short? DiscountTax { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastInvoiceDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastCheckDate { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [StringLength(4000)]
        public string Comments { get; set; }
        [Column("APAccount")]
        [StringLength(50)]
        public string Apaccount { get; set; }
        [StringLength(50)]
        public string ExpenseAccount { get; set; }
        [StringLength(50)]
        public string Phone2 { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        public bool? SoleProprietor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SoleProprietorReported { get; set; }
        [Column("SSNo")]
        [StringLength(50)]
        public string Ssno { get; set; }
        [StringLength(50)]
        public string TaxCode { get; set; }
        [StringLength(50)]
        public string MailingCountry { get; set; }
        [StringLength(50)]
        public string StreetCountry { get; set; }
        [StringLength(50)]
        public string OldNumber { get; set; }
        [StringLength(100)]
        public string OldName { get; set; }
        [StringLength(50)]
        public string InsuranceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsuranceNoDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsuranceNoRecvDate { get; set; }
        [StringLength(50)]
        public string VendorAccountNo { get; set; }
        public short? ReportToState { get; set; }
        public bool? W9 { get; set; }
        [StringLength(100)]
        public string CheckMemo { get; set; }
        [StringLength(50)]
        public string PaymentType { get; set; }
        public int? LegacyId { get; set; }
        public bool? Inactive { get; set; }
        public bool IsMigrated { get; set; }
    }
}
