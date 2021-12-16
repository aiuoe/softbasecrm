using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO used as input for the get all leads method that includes filters
    /// </summary>
    public class GetAllLeadSourcesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

        public int? IsDefaultFilter { get; set; }

    }
}