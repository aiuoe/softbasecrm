using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("eRentContactDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "eRentContactDetail_TenantId_index")]
    public class ERentContactDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public long? DocumentNumber { get; set; }
        [StringLength(200)]
        public string EmailAddress { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string JobTitle { get; set; }
        [StringLength(14)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        [StringLength(200)]
        public string Address1 { get; set; }
        [StringLength(200)]
        public string Address2 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string State { get; set; }
        [StringLength(25)]
        public string PostalCode { get; set; }
        public bool? ContactMe { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
