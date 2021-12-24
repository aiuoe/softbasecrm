using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IActivityPrioritiesAppService : IApplicationService
    {
        Task<PagedResultDto<GetActivityPriorityForViewDto>> GetAll(GetAllActivityPrioritiesInput input);

        Task<GetActivityPriorityForViewDto> GetActivityPriorityForView(int id);

        Task<GetActivityPriorityForEditOutput> GetActivityPriorityForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditActivityPriorityDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetActivityPrioritiesToExcel(GetAllActivityPrioritiesForExcelInput input);

    }
}