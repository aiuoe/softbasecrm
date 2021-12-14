using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllActivityStatusesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

    }
}