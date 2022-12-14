using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage filter object to get paged result from opportunities
    /// </summary>
    public class GetAllOpportunitiesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        
        public string NameFilter { get; set; }

        public decimal? MaxAmountFilter { get; set; }
        public decimal? MinAmountFilter { get; set; }

        public decimal? MaxProbabilityFilter { get; set; }
        public decimal? MinProbabilityFilter { get; set; }

        public DateTime? MaxCloseDateFilter { get; set; }
        public DateTime? MinCloseDateFilter { get; set; }

        public string DescriptionFilter { get; set; }

        public string BranchFilter { get; set; }

        public string DepartmentFilter { get; set; }

        public string OpportunityStageDescriptionFilter { get; set; }

        public string LeadSourceDescriptionFilter { get; set; }

        public string OpportunityTypeDescriptionFilter { get; set; }

        public string CustomerName { get; set; }

        public string ContactName { get; set; }

        public int? OpportunityStageId { get; set; }

        public List<long?> UserIds { get; set; } = new List<long?>();
    }
}