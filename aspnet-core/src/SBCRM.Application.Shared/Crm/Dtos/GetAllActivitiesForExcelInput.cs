using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllActivitiesForExcelInput
    {
        public string Filter { get; set; }

        public string OpportunityNameFilter { get; set; }

        public string LeadCompanyNameFilter { get; set; }

        public string UserNameFilter { get; set; }

        public string ActivitySourceTypeDescriptionFilter { get; set; }

        public string ActivityTaskTypeDescriptionFilter { get; set; }

        public string ActivityStatusDescriptionFilter { get; set; }

        public string ActivityPriorityDescriptionFilter { get; set; }

        public string CustomerNameFilter { get; set; }
    }
}