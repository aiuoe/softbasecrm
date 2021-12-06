using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IPrioritiesAppService : IApplicationService
    {
        Task<PagedResultDto<GetPriorityForViewDto>> GetAll(GetAllPrioritiesInput input);

        Task<GetPriorityForViewDto> GetPriorityForView(int id);

        Task<GetPriorityForEditOutput> GetPriorityForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditPriorityDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetPrioritiesToExcel(GetAllPrioritiesForExcelInput input);

    }
}