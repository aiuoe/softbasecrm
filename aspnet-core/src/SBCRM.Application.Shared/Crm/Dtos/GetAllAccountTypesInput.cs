using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllAccountTypesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}