using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Contacts", Schema = "web")]
    [Index(nameof(TenantId), Name = "Contacts_TenantId_index")]
    public class Contact : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Column("Contact")]
        [StringLength(50)]
        public string Contact1 { get; set; }
        [StringLength(50)]
        public string Parent { get; set; }
        public short? IndexPointer { get; set; }
        [StringLength(50)]
        public string Position { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Extention { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string Pager { get; set; }
        [StringLength(50)]
        public string Cellular { get; set; }
        [Column("EMail")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("wwwHomePage")]
        [StringLength(50)]
        public string WwwHomePage { get; set; }
        public bool SalesGroup1 { get; set; }
        public bool SalesGroup2 { get; set; }
        public bool SalesGroup3 { get; set; }
        public string Comments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool SalesGroup4 { get; set; }
        public bool SalesGroup5 { get; set; }
        public bool SalesGroup6 { get; set; }
        public bool MailingList { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
