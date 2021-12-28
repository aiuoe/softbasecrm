using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using SBCRM.Auditing.Dto;
using SBCRM.Crm.Dtos;

namespace SBCRM.Legacy
{
    //Interface of global search
    public interface IGlobalSearchAppService:IApplicationService
    {
        Task<PagedResultDto<GetGlobalSearchDto>> GetAccounts(GetGlobalSearchInput input);
    }
}
