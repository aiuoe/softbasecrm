using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllZipCodesInput : PagedAndSortedResultRequestDto
    {
        public string ZipCodeFilter { get; set; }
    }
}