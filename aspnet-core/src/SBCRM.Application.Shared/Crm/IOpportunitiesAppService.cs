using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IOpportunitiesAppService : IApplicationService
    {
        Task<PagedResultDto<GetOpportunityForViewDto>> GetAll(GetAllOpportunitiesInput input);

        Task<GetOpportunityForViewDto> GetOpportunityForView(int id);

        Task<GetOpportunityForEditOutput> GetOpportunityForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditOpportunityDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetOpportunitiesToExcel(GetAllOpportunitiesForExcelInput input);

        Task<PagedResultDto<OpportunityOpportunityStageLookupTableDto>> GetAllOpportunityStageForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<OpportunityLeadSourceLookupTableDto>> GetAllLeadSourceForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<OpportunityOpportunityTypeLookupTableDto>> GetAllOpportunityTypeForLookupTable(GetAllForLookupTableInput input);

    }
}