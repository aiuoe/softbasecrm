﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

/// <summary>
/// DTO to manage the object filters to view
/// </summary>
namespace SBCRM.Crm.Dtos
{
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

        public List<int?> OpportunityStageId { get; set; } = new List<int?>();
    }
}