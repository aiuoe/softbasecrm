﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("LocalTaxCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "LocalTaxCodes_TenantId_index")]
    [Index(nameof(TaxCode), nameof(TenantId), Name = "UC_LocalTaxCodes", IsUnique = true)]
    public class LocalTaxCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string TaxCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaxAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRateEquip { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRate { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string TaxAccount { get; set; }
        [StringLength(50)]
        public string LocalCode { get; set; }
        public bool PartsNonTaxable { get; set; }
        public bool LaborNonTaxable { get; set; }
        public bool MiscNonTaxable { get; set; }
        public bool RentalNonTaxable { get; set; }
        public bool EquipmentNonTaxable { get; set; }
        public bool IsMigrated { get; set; }
    }
}
