using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface ILeadsAppService : IApplicationService
    {
        Task<PagedResultDto<GetLeadForViewDto>> GetAll(GetAllLeadsInput input);

        Task<GetLeadForViewDto> GetLeadForView(int id);

        Task<GetLeadForEditOutput> GetLeadForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLeadDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetLeadsToExcel(GetAllLeadsForExcelInput input);

        Task<List<LeadLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown();

        Task<List<LeadLeadStatusLookupTableDto>> GetAllLeadStatusForTableDropdown();

        Task<List<LeadPriorityLookupTableDto>> GetAllPriorityForTableDropdown();

        Task ImportLeadsFromFile(byte[] inputFile);

    }
}