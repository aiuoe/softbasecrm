using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage filter object to get paged result from customers
    /// </summary>
    public class GetAllCustomerInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public List<int?> AccountTypeId { get; set; } = new List<int?>();
    }
}