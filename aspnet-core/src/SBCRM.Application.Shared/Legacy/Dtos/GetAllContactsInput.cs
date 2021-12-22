using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage filter object to get paged result from contacts
    /// </summary>
    public class GetAllContactsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string CustomerNumber { get; set; }

    }
}