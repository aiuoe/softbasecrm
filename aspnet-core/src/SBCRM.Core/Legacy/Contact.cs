using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Auditing;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Contact entity from legacy schema
    /// </summary>
    [Table("Contacts", Schema = "dbo")]
    [Audited]
    public class Contact : Entity
    {
        [Key]
        [Column("ID")]
        public virtual int ContactId { get; set; }

        [StringLength(ContactConsts.MaxCustomerNoLength, MinimumLength = ContactConsts.MinCustomerNoLength)]
        public virtual string CustomerNo { get; set; }

        [Column("Contact")]
        [StringLength(ContactConsts.MaxContactLength, MinimumLength = ContactConsts.MinContactLength)]
        public virtual string ContactField { get; set; }

        [StringLength(ContactConsts.MaxParentLength, MinimumLength = ContactConsts.MinParentLength)]
        public virtual string Parent { get; set; }

        public virtual short? IndexPointer { get; set; }

        [StringLength(ContactConsts.MaxPositionLength, MinimumLength = ContactConsts.MinPositionLength)]
        public virtual string Position { get; set; }

        [StringLength(ContactConsts.MaxPhoneLength, MinimumLength = ContactConsts.MinPhoneLength)]
        public virtual string Phone { get; set; }

        [StringLength(ContactConsts.MaxExtentionLength, MinimumLength = ContactConsts.MinExtentionLength)]
        public virtual string Extention { get; set; }

        [StringLength(ContactConsts.MaxFaxLength, MinimumLength = ContactConsts.MinFaxLength)]
        public virtual string Fax { get; set; }

        [StringLength(ContactConsts.MaxPagerLength, MinimumLength = ContactConsts.MinPagerLength)]
        public virtual string Pager { get; set; }

        [StringLength(ContactConsts.MaxCellularLength, MinimumLength = ContactConsts.MinCellularLength)]
        public virtual string Cellular { get; set; }

        [StringLength(ContactConsts.MaxEMailLength, MinimumLength = ContactConsts.MinEMailLength)]
        public virtual string EMail { get; set; }

        [StringLength(ContactConsts.MaxwwwHomePageLength, MinimumLength = ContactConsts.MinwwwHomePageLength)]
        public virtual string wwwHomePage { get; set; }

        public virtual short? SalesGroup1 { get; set; }

        public virtual short? SalesGroup2 { get; set; }

        public virtual short? SalesGroup3 { get; set; }

        public virtual string Comments { get; set; }

        public virtual DateTime? DateAdded { get; set; }

        public virtual DateTime? DateChanged { get; set; }

        public virtual short? SalesGroup4 { get; set; }

        public virtual short? SalesGroup5 { get; set; }

        public virtual short? SalesGroup6 { get; set; }

        public virtual short? MailingList { get; set; }

        [StringLength(ContactConsts.MaxAddedByLength, MinimumLength = ContactConsts.MinAddedByLength)]
        public virtual string AddedBy { get; set; }

        [StringLength(ContactConsts.MaxChangedByLength, MinimumLength = ContactConsts.MinChangedByLength)]
        public virtual string ChangedBy { get; set; }

        

    }
}