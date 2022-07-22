using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SalesTaxIntegration", Schema = "web")]
    [Index(nameof(TenantId), Name = "SalesTaxIntegration_TenantId_index")]
    public class SalesTaxIntegration : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [Required]
        [StringLength(50)]
        public string SalesTaxProvider { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string LicenseKey { get; set; }
        [Required]
        [Column("ServiceURL")]
        [StringLength(100)]
        public string ServiceUrl { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyCode { get; set; }
        public int RequestTimeout { get; set; }
        public bool? DisableAddressVerification { get; set; }
        public bool? DisableDocumentRecording { get; set; }
        public bool? EnableLogging { get; set; }
        [Column("EnableAvataxUPC")]
        public bool? EnableAvataxUpc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesParts { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesPartsDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesLabor { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesLaborDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesMisc { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesMiscDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesRental { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesRentalDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesEquip { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesEquipDesc { get; set; }
        public DateTime LastUpdatedDatetime { get; set; }
        [Required]
        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("DefaultGLTaxAccountNo")]
        [StringLength(50)]
        public string DefaultGlTaxAccountNo { get; set; }
        public bool IsMigrated { get; set; }
    }
}
