using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Dto for Excel Input
    /// </summary>
    public class GetAllActivitiesForExcelInput : PagedAndSortedResultRequestDto
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

        public List<long> UserIds { get; set; } = new List<long>();

        public bool ExcludeCompleted { get; set; }
    }
}