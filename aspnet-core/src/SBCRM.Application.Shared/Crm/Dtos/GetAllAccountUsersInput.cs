using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllAccountUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string UserNameFilter { get; set; }

        public string CustomerNumber { get; set; }

    }
}