using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IActivityTaskTypesAppService : IApplicationService
    {
        Task<PagedResultDto<GetActivityTaskTypeForViewDto>> GetAll(GetAllActivityTaskTypesInput input);

        Task<GetActivityTaskTypeForViewDto> GetActivityTaskTypeForView(int id);

        Task<GetActivityTaskTypeForEditOutput> GetActivityTaskTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditActivityTaskTypeDto input);

        Task Delete(EntityDto input);

    }
}