using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Global search information
    /// </summary>
    public interface IGlobalSearchAppService : IApplicationService
    {
        /// <summary>
        /// Get all global search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetGlobalSearchItemDto>> GetAll(GetGlobalSearchInput input);
    }
}