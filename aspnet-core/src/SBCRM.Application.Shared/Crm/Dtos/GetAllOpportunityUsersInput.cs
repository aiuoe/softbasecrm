using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllOpportunityUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string UserNameFilter { get; set; }

        public string OpportunityNameFilter { get; set; }

    }
}