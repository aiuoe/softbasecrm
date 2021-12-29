using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// DTO to manage the object query lead information
    /// </summary>
    public class LeadQueryDto : FullAuditedEntity
    {
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactPosition { get; set; }

        public string WebSite { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Notes { get; set; }

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

        public string LeadSourceDescription { get; set; }

        public string LeadStatusDescription { get; set; }

        public string LeadStatusColor { get; set; }

        public string PriorityDescription { get; set; }

        public bool LeadCanBeConvert { get; set; }

        public string PriorityColor { get; set; }

        public string FirstUserAssignedName { get; set; }

        public List<LeadUser> Users { get; set; }

    }
}

