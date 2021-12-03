using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface ILeadSourcesAppService : IApplicationService
    {
        Task<PagedResultDto<GetLeadSourceForViewDto>> GetAll(GetAllLeadSourcesInput input);

        Task<GetLeadSourceForViewDto> GetLeadSourceForView(int id);

        Task<GetLeadSourceForEditOutput> GetLeadSourceForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLeadSourceDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetLeadSourcesToExcel(GetAllLeadSourcesForExcelInput input);

    }
}