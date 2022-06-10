using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GroupTable", Schema = "web")]
    [Index(nameof(TenantId), Name = "GroupTable_TenantId_index")]
    [Index(nameof(PartsGroup), nameof(TenantId), Name = "UC_GroupTable", IsUnique = true)]
    public class GroupTable : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string InventoryAccount { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string PriceDisk { get; set; }
        [StringLength(50)]
        public string Cost { get; set; }
        [StringLength(50)]
        public string Discount { get; set; }
        [StringLength(50)]
        public string List { get; set; }
        [StringLength(50)]
        public string Internal { get; set; }
        [StringLength(50)]
        public string Warranty { get; set; }
        [StringLength(50)]
        public string Wholesale { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MarkupCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MarkupDiscount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MarkupList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MarkupInternal { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MarkupWarranty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MarkupWholesale { get; set; }
        public short? MinDays { get; set; }
        public short? MaxDays { get; set; }
        public short? AvgMonths { get; set; }
        public short? RatingA { get; set; }
        public short? RatingB { get; set; }
        public short? RatingC { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RatingD { get; set; }
        public short? RatingMonths { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PhaseInDemand { get; set; }
        public int? PhaseInBinTrips { get; set; }
        public short? PhaseInMonths { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PhaseOutDemand { get; set; }
        public int? PhaseOutBinTrips { get; set; }
        public short? PhaseOutMonths { get; set; }
        public short? NoCostReprice { get; set; }
        public short? NoListReprice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LandedPercent { get; set; }
        public short? UseCurrencyCost { get; set; }
        public short? DefaultGroup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EmergencyMarkup { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
