using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllLeadsForExcelInput
    {
        public string Filter { get; set; }

        public string CompanyNameFilter { get; set; }

        public string FirstNameFilter { get; set; }

        public string LastNameFilter { get; set; }

        public string TitleFilter { get; set; }

        public string WebSiteFilter { get; set; }

        public string AddressFilter { get; set; }

        public string CountryFilter { get; set; }

        public string StateFilter { get; set; }

        public string DescriptionFilter { get; set; }

        public string IndustryDescriptionFilter { get; set; }

        public string LeadSourceDescriptionFilter { get; set; }

        public string LeadStatusDescriptionFilter { get; set; }

    }
}