using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface IActivitiesAppService : IApplicationService
    {
        Task<PagedResultDto<GetActivityForViewDto>> GetAll(GetAllActivitiesInput input);

        Task<GetActivityForViewDto> GetActivityForView(long id);

        Task<GetActivityForEditOutput> GetActivityForEdit(EntityDto<long> input);

        Task CreateOrEdit(CreateOrEditActivityDto input);

        Task Delete(EntityDto<long> input);

        Task<FileDto> GetActivitiesToExcel(GetAllActivitiesForExcelInput input);

        Task<List<ActivityOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown();

        Task<List<ActivityLeadLookupTableDto>> GetAllLeadForTableDropdown();

        Task<List<ActivityUserLookupTableDto>> GetAllUserForTableDropdown();

        Task<List<ActivityActivitySourceTypeLookupTableDto>> GetAllActivitySourceTypeForTableDropdown();

        Task<List<ActivityActivityTaskTypeLookupTableDto>> GetAllActivityTaskTypeForTableDropdown();

        Task<List<ActivityActivityStatusLookupTableDto>> GetAllActivityStatusForTableDropdown();

        Task<List<ActivityActivityPriorityLookupTableDto>> GetAllActivityPriorityForTableDropdown();

    }
}