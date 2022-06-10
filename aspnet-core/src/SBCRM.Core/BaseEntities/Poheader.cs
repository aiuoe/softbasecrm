using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("POHeader", Schema = "web")]
    [Index(nameof(TenantId), Name = "POHeader_TenantId_index")]
    [Index(nameof(Pono), nameof(TenantId), Name = "UC_POHeader", IsUnique = true)]
    public class Poheader : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("PONo")]
        public int Pono { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string VendorName { get; set; }
        [StringLength(50)]
        public string VendorSubName { get; set; }
        [StringLength(50)]
        public string VendorAddress { get; set; }
        [StringLength(50)]
        public string VendorCity { get; set; }
        [StringLength(50)]
        public string VendorState { get; set; }
        [StringLength(50)]
        public string VendorZip { get; set; }
        [StringLength(50)]
        public string VendorPhone { get; set; }
        [StringLength(50)]
        public string VendorFax { get; set; }
        [StringLength(50)]
        public string ShipVia { get; set; }
        [Column("FOB")]
        [StringLength(50)]
        public string Fob { get; set; }
        [Column("APAccount")]
        [StringLength(50)]
        public string Apaccount { get; set; }
        public short? Disposition { get; set; }
        public string Comments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [StringLength(50)]
        public string ShipToVendorNo { get; set; }
        [StringLength(50)]
        public string ShipToName { get; set; }
        [StringLength(50)]
        public string ShipToAddress { get; set; }
        [StringLength(50)]
        public string ShipToCity { get; set; }
        [StringLength(50)]
        public string ShipToState { get; set; }
        [StringLength(50)]
        public string ShipToZip { get; set; }
        [StringLength(50)]
        public string ShipToAttn { get; set; }
        [StringLength(50)]
        public string Terms { get; set; }
        [StringLength(50)]
        public string Reference { get; set; }
        [StringLength(50)]
        public string ShipToSubName { get; set; }
        [Column("POBranch")]
        public short? Pobranch { get; set; }
        [Column("PODept")]
        public short? Podept { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? VendorPromiseDate { get; set; }
        [StringLength(50)]
        public string ShipToPhone { get; set; }
        [Column(TypeName = "text")]
        public string PrivateComments { get; set; }
        public bool IsMigrated { get; set; }
    }
}
