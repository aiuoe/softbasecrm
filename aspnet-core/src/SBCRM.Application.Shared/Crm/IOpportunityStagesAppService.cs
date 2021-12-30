using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IOpportunityStagesAppService : IApplicationService
    {
        Task<PagedResultDto<GetOpportunityStageForViewDto>> GetAll(GetAllOpportunityStagesInput input);

        Task<GetOpportunityStageForViewDto> GetOpportunityStageForView(int id);

        Task<GetOpportunityStageForEditOutput> GetOpportunityStageForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditOpportunityStageDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetOpportunityStagesToExcel(GetAllOpportunityStagesForExcelInput input);

    }
}