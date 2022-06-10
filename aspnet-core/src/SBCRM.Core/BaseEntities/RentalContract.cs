using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RentalContract", Schema = "web")]
    [Index(nameof(TenantId), Name = "RentalContract_TenantId_index")]
    [Index(nameof(RentalContractNo), nameof(TenantId), Name = "UC_RentalContract", IsUnique = true)]
    public class RentalContract : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int RentalContractNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerCalledForPickup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerWantsPickup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PickupCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DeliveryCharge { get; set; }
        public short? OpenEndedContract { get; set; }
        [StringLength(50)]
        public string PickupChargeText { get; set; }
        [StringLength(50)]
        public string DeliveryChargeText { get; set; }
        public string CommentsPublic { get; set; }
        public string CommentsPrivate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RentalDeliveryDateTime { get; set; }
        public short? UnassignedRentalContract { get; set; }
        [StringLength(50)]
        public string InsuranceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsuranceRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsuranceExpDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
