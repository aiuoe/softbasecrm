using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto used to populate data tables for Activities Widget
    /// </summary>
    public class GetAllActivitiesForWidget: PagedAndSortedResultRequestDto
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

        public string IdToFilter { get; set; }
    }
}
