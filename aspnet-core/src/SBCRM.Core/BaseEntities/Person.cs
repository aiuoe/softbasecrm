using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Person", Schema = "web")]
    [Index(nameof(TenantId), Name = "Person_TenantId_index")]
    [Index(nameof(Number), nameof(TenantId), Name = "UC_Person", IsUnique = true)]
    public class Person : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int Number { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleInit { get; set; }
        [StringLength(50)]
        public string NickName { get; set; }
        public bool MaleFemale { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string ZipCode { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Extention { get; set; }
        public bool ExtentionList { get; set; }
        public bool Mechanic { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourlyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MonthlyRate { get; set; }
        public short? Branch { get; set; }
        public short? Dept { get; set; }
        public bool UseDefaults { get; set; }
        [StringLength(50)]
        public string ServiceVan { get; set; }
        [StringLength(50)]
        public string PictureFile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReviewDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NextReviewDate { get; set; }
        [StringLength(50)]
        public string Position { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PositionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TerminationDate { get; set; }
        public bool Active { get; set; }
        [Column("SSNo")]
        [StringLength(50)]
        public string Ssno { get; set; }
        [Column("DLNo")]
        [StringLength(50)]
        public string Dlno { get; set; }
        [Column("DLExpirationDate", TypeName = "datetime")]
        public DateTime? DlexpirationDate { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string MaritalStatus { get; set; }
        [Column(TypeName = "image")]
        public byte[] PersonImage { get; set; }
        [StringLength(50)]
        public string PersonGroup { get; set; }
        [Column("EMailAddress")]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [Column("AutomaticEmailBCC")]
        public bool AutomaticEmailBcc { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
