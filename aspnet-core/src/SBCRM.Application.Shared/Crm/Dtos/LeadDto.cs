using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class LeadDto : EntityDto
    {
        public string CompanyName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string WebSite { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string Description { get; set; }

        public int IndustryId { get; set; }

        public int LeadSourceId { get; set; }

        public int LeadStatusId { get; set; }

    }
}