using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface ILeadUsersAppService : IApplicationService
    {
        Task<PagedResultDto<GetLeadUserForViewDto>> GetAll(GetAllLeadUsersInput input);

        Task<GetLeadUserForEditOutput> GetLeadUserForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLeadUserDto input);

        Task Delete(EntityDto input);

        Task<List<LeadUserLeadLookupTableDto>> GetAllLeadForTableDropdown();

        Task<List<LeadUserUserLookupTableDto>> GetAllUserForTableDropdown();

    }
}