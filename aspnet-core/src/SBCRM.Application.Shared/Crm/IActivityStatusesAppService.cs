using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IActivityStatusesAppService : IApplicationService
    {
        Task<PagedResultDto<GetActivityStatusForViewDto>> GetAll(GetAllActivityStatusesInput input);

        Task<GetActivityStatusForViewDto> GetActivityStatusForView(int id);

        Task<GetActivityStatusForEditOutput> GetActivityStatusForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditActivityStatusDto input);

        Task Delete(EntityDto input);

    }
}