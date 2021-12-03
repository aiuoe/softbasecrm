using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface ILeadStatusesAppService : IApplicationService
    {
        Task<PagedResultDto<GetLeadStatusForViewDto>> GetAll(GetAllLeadStatusesInput input);

        Task<GetLeadStatusForViewDto> GetLeadStatusForView(int id);

        Task<GetLeadStatusForEditOutput> GetLeadStatusForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLeadStatusDto input);

        Task Delete(EntityDto input);

    }
}