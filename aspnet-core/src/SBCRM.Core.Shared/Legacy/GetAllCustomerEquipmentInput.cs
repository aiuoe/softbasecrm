using Abp.Application.Services.Dto;

namespace SBCRM.Legacy
{
    /// <summary>
    /// DTO to manage the filter object to get customer equipments
    /// </summary>
    public class GetAllCustomerEquipmentInput : PagedAndSortedResultRequestDto
    {
        public string CustomerNumber { get; set; }
    }
}
