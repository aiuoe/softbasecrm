using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IActivitySourceTypesAppService : IApplicationService
    {
        Task<PagedResultDto<GetActivitySourceTypeForViewDto>> GetAll(GetAllActivitySourceTypesInput input);

        Task<GetActivitySourceTypeForViewDto> GetActivitySourceTypeForView(int id);

        Task<GetActivitySourceTypeForEditOutput> GetActivitySourceTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditActivitySourceTypeDto input);

        Task Delete(EntityDto input);

    }
}