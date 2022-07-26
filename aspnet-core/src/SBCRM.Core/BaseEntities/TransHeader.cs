using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TransHeader", Schema = "web")]
    [Index(nameof(TenantId), Name = "TransHeader_TenantId_index")]
    [Index(nameof(TrackingNo), nameof(TenantId), Name = "UC_TransHeader", IsUnique = true)]
    public class TransHeader : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int TrackingNo { get; set; }
        [StringLength(50)]
        public string TruckNo { get; set; }
        [StringLength(50)]
        public string OriginCustomerNo { get; set; }
        [StringLength(100)]
        public string OriginName { get; set; }
        [StringLength(100)]
        public string OriginAddress { get; set; }
        [StringLength(50)]
        public string OriginCity { get; set; }
        [StringLength(50)]
        public string OriginState { get; set; }
        [StringLength(50)]
        public string OriginZipCode { get; set; }
        [StringLength(50)]
        public string OriginPhone { get; set; }
        [StringLength(50)]
        public string DestCustomerNo { get; set; }
        [StringLength(100)]
        public string DestName { get; set; }
        [StringLength(100)]
        public string DestAddress { get; set; }
        [StringLength(50)]
        public string DestCity { get; set; }
        [StringLength(50)]
        public string DestState { get; set; }
        [StringLength(50)]
        public string DestZipCode { get; set; }
        [StringLength(50)]
        public string DestPhone { get; set; }
        [StringLength(50)]
        public string HaulerVendorNo { get; set; }
        [StringLength(100)]
        public string HaulerName { get; set; }
        [StringLength(100)]
        public string HaulerAddress { get; set; }
        [StringLength(50)]
        public string HaulerCity { get; set; }
        [StringLength(50)]
        public string HaulerState { get; set; }
        [StringLength(50)]
        public string HaulerZipCode { get; set; }
        [StringLength(50)]
        public string HaulerPhone { get; set; }
        [Column("HaulerPONo")]
        public int? HaulerPono { get; set; }
        public string PublicComments { get; set; }
        public string PrivateComments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(100)]
        public string LastUpdatedBy { get; set; }
        public string Comments { get; set; }
        public int? TinnacityStatus { get; set; }
        public bool IsMigrated { get; set; }
    }
}
