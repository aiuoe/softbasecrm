using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO used as input for the get all lead status method that includes filters
    /// </summary>
    public class GetAllLeadStatusesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

        public int? IsLeadConversionValidFilter { get; set; }

        public int? IsDefaultFilter { get; set; }

    }
}