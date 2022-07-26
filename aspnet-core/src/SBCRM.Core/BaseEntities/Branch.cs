using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Branch", Schema = "web")]
    [Index(nameof(TenantId), Name = "Branch_TenantId_index")]
    [Index(nameof(Number), nameof(TenantId), Name = "UC_Branch", IsUnique = true)]
    public class Branch : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public short Number { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SubName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(15)]
        public string State { get; set; }
        [StringLength(20)]
        public string ZipCode { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string Receivable { get; set; }
        [StringLength(50)]
        public string FinanceCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FinanceRate { get; set; }
        public short? FinanceDays { get; set; }
        [StringLength(50)]
        public string StateTaxLabel { get; set; }
        [StringLength(50)]
        public string CountyTaxLabel { get; set; }
        public bool? ShowSplitSalesTax { get; set; }
        [StringLength(50)]
        public string CityTaxLabel { get; set; }
        [StringLength(50)]
        public string LocalTaxLabel { get; set; }
        [StringLength(50)]
        public string DefaultWarehouse { get; set; }
        [StringLength(50)]
        public string ClarkPartsCode { get; set; }
        [StringLength(50)]
        public string ClarkDealerAccessCode { get; set; }
        public bool? UseStateTaxCodeDescription { get; set; }
        public bool? UseCountyTaxCodeDescription { get; set; }
        public bool? UseCityTaxCodeDescription { get; set; }
        public bool? UseLocalTaxCodeDescription { get; set; }
        public DateTime? RentalDeliveryDefaultTime { get; set; }
        [StringLength(50)]
        public string StateTaxCode { get; set; }
        [StringLength(50)]
        public string CountyTaxCode { get; set; }
        [StringLength(50)]
        public string CityTaxCode { get; set; }
        [StringLength(50)]
        public string LocalTaxCode { get; set; }
        [StringLength(50)]
        public string TaxCode { get; set; }
        public bool? UseAbsoluteTaxCodes { get; set; }
        [StringLength(100)]
        public string SmallSubName { get; set; }
        [Column("ShopID")]
        [StringLength(50)]
        public string ShopId { get; set; }
        public string Image { get; set; }
        public bool? UseImage { get; set; }
        [StringLength(200)]
        public string LogoFile { get; set; }
        [Column("VendorID")]
        [StringLength(50)]
        public string VendorId { get; set; }
        [Column("PrintFinalCC")]
        [StringLength(200)]
        public string PrintFinalCc { get; set; }
        [Column("PrintFinalBCC")]
        [StringLength(200)]
        public string PrintFinalBcc { get; set; }
        [StringLength(50)]
        public string StoreName { get; set; }
        [StringLength(50)]
        public string CreditCardAccountNo { get; set; }
        [Column("TVHAccountNo")]
        [StringLength(50)]
        public string TvhAccountNo { get; set; }
        [Column("TVHKey")]
        [StringLength(100)]
        public string TvhKey { get; set; }
        [Column("TVHCountry")]
        [StringLength(50)]
        public string TvhCountry { get; set; }
        [Column("TVHWarehouse")]
        [StringLength(50)]
        public string TvhWarehouse { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
