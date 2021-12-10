using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllCustomerInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public int? AccountTypeId { get; set; }
    }
}