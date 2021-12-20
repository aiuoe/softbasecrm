using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object contact
    /// </summary>
    public class ContactDto : EntityDto
    {
        public string CustomerNo { get; set; }

        public string Contact { get; set; }

        public string Parent { get; set; }

        public short? IndexPointer { get; set; }

        public string Position { get; set; }

        public string Phone { get; set; }

        public string Extention { get; set; }

        public string Fax { get; set; }

        public string Pager { get; set; }

        public string Cellular { get; set; }

        public string EMail { get; set; }

        public string wwwHomePage { get; set; }

        public short? SalesGroup1 { get; set; }

        public short? SalesGroup2 { get; set; }

        public short? SalesGroup3 { get; set; }

        public string Comments { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateChanged { get; set; }

        public short? SalesGroup4 { get; set; }

        public short? SalesGroup5 { get; set; }

        public short? SalesGroup6 { get; set; }

        public short? MailingList { get; set; }

        public string AddedBy { get; set; }

        public string ChangedBy { get; set; }

        public int ID { get; set; }

    }
}