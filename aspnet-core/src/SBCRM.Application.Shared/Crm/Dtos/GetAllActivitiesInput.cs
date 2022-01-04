using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Dto for Viewing Input
    /// </summary>
    public class GetAllActivitiesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string OpportunityNameFilter { get; set; }

        public string LeadCompanyNameFilter { get; set; }

        public string UserNameFilter { get; set; }

        public string CustomerNameFilter { get; set; }

        public List<long> UserIds { get; set; } = new List<long>();

        public bool ExcludeCompleted { get; set; }

        public int? ActivitySourceTypeId { get; set; }

        public int? ActivityTaskTypeId { get; set; }

        public int? ActivityStatusId { get; set; }

        public bool IsUnassignedSelected { get; set; }
    }
}