using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Opportunity attachment filter model.
    /// </summary>
    public class GetAllOpportunityAttachmentsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string FilePathFilter { get; set; }

        public string OpportunityNameFilter { get; set; }

        public int OpportunityId { get; set; }

    }
}