using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

/// <summary>
/// DTO to manage the object filters to export excel
/// </summary>
namespace SBCRM.Crm.Dtos
{
    public class GetAllLeadsForExcelInput
    {
        public string Filter { get; set; }

        public string CompanyOrContactNameFilter { get; set; }

        public string ContactNameFilter { get; set; }

        public string ContactPositionFilter { get; set; }

        public string WebSiteFilter { get; set; }

        public string AddressFilter { get; set; }

        public string CountryFilter { get; set; }

        public string StateFilter { get; set; }

        public string CityFilter { get; set; }

        public string DescriptionFilter { get; set; }

        public string CompanyPhoneFilter { get; set; }

        public string CompanyEmailFilter { get; set; }

        public string PoBoxFilter { get; set; }

        public string ZipCodeFilter { get; set; }

        public string ContactPhoneFilter { get; set; }

        public string ContactPhoneExtensionFilter { get; set; }

        public string ContactCellPhoneFilter { get; set; }

        public string ContactFaxNumberFilter { get; set; }

        public string PagerNumberFilter { get; set; }

        public string ContactEmailFilter { get; set; }

        public string LeadSourceDescriptionFilter { get; set; }

        public string LeadStatusDescriptionFilter { get; set; }

        public string PriorityDescriptionFilter { get; set; }

        public int? LeadStatusId { get; set; }

        public int? PriorityId { get; set; }

        public List<long?> UserIds { get; set; } = new List<long?>();

    }
}