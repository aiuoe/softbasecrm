using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy
{
    public interface IARTermsAppService : IApplicationService
    {
        Task<PagedResultDto<GetARTermsForViewDto>> GetAll(GetAllARTermsInput input);

    }
}