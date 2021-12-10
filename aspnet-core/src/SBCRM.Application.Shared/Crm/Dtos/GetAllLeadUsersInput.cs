using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllLeadUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string LeadCompanyNameFilter { get; set; }

        public string UserNameFilter { get; set; }

    }
}