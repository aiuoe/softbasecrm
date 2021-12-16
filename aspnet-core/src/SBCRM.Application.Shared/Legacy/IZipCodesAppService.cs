using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;

namespace SBCRM.Legacy
{
    public interface IZipCodesAppService : IApplicationService
    {
        Task<PagedResultDto<GetZipCodeForViewDto>> GetAll(GetAllZipCodesInput input);

        Task<PagedResultDto<GetZipCodeForViewDto>> GetAllZipCodesForTableDropdown();
    }
}