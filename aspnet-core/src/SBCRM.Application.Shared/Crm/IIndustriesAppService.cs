using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IIndustriesAppService : IApplicationService
    {
        Task<PagedResultDto<GetIndustryForViewDto>> GetAll(GetAllIndustriesInput input);

        Task<GetIndustryForEditOutput> GetIndustryForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditIndustryDto input);

        Task Delete(EntityDto input);

    }
}