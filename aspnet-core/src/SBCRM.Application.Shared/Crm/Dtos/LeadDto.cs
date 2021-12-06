using SBCRM.Dto;

namespace SBCRM.Crm.Dtos
{
    public class LeadDto : AuditEntityDto
    {
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactPosition { get; set; }

        public string WebSite { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string Description { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }

        public string PoBox { get; set; }

        public string ZipCode { get; set; }

        public string ContactPhone { get; set; }

        public string ContactPhoneExtension { get; set; }

        public string ContactCellPhone { get; set; }

        public string ContactFaxNumber { get; set; }

        public string PagerNumber { get; set; }

        public string ContactEmail { get; set; }

        public int LeadSourceId { get; set; }

        public int LeadStatusId { get; set; }

        public int? PriorityId { get; set; }
    }
}