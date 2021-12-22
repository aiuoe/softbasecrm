using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object for creation/edition contact
    /// </summary>
    public class CreateOrEditContactDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(ContactConsts.MaxCustomerNoLength, MinimumLength = ContactConsts.MinCustomerNoLength)]
        public string CustomerNo { get; set; }

        [StringLength(ContactConsts.MaxContactLength, MinimumLength = ContactConsts.MinContactLength)]
        public string Contact { get; set; }

        [StringLength(ContactConsts.MaxParentLength, MinimumLength = ContactConsts.MinParentLength)]
        public string Parent { get; set; }

        public short? IndexPointer { get; set; }

        [StringLength(ContactConsts.MaxPositionLength, MinimumLength = ContactConsts.MinPositionLength)]
        public string Position { get; set; }

        [StringLength(ContactConsts.MaxPhoneLength, MinimumLength = ContactConsts.MinPhoneLength)]
        public string Phone { get; set; }

        [StringLength(ContactConsts.MaxExtentionLength, MinimumLength = ContactConsts.MinExtentionLength)]
        public string Extention { get; set; }

        [StringLength(ContactConsts.MaxFaxLength, MinimumLength = ContactConsts.MinFaxLength)]
        public string Fax { get; set; }

        [StringLength(ContactConsts.MaxPagerLength, MinimumLength = ContactConsts.MinPagerLength)]
        public string Pager { get; set; }

        [StringLength(ContactConsts.MaxCellularLength, MinimumLength = ContactConsts.MinCellularLength)]
        public string Cellular { get; set; }

        [StringLength(ContactConsts.MaxEMailLength, MinimumLength = ContactConsts.MinEMailLength)]
        public string EMail { get; set; }

        [StringLength(ContactConsts.MaxwwwHomePageLength, MinimumLength = ContactConsts.MinwwwHomePageLength)]
        public string wwwHomePage { get; set; }

        public short? SalesGroup1 { get; set; }

        public short? SalesGroup2 { get; set; }

        public short? SalesGroup3 { get; set; }

        public string Comments { get; set; }
        public short? SalesGroup4 { get; set; }

        public short? SalesGroup5 { get; set; }

        public short? SalesGroup6 { get; set; }

        public short? MailingList { get; set; }

    }
}