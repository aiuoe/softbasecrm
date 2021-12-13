using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IOpportunityTypesAppService : IApplicationService
    {
        Task<PagedResultDto<GetOpportunityTypeForViewDto>> GetAll(GetAllOpportunityTypesInput input);

        Task<GetOpportunityTypeForViewDto> GetOpportunityTypeForView(int id);

        Task<GetOpportunityTypeForEditOutput> GetOpportunityTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditOpportunityTypeDto input);

        Task Delete(EntityDto input);

    }
}