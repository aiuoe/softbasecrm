using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using SBCRM.Legacy.Dtos;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle leads information
    /// </summary>
    public interface ILeadsAppService : IApplicationService
    {
        /// <summary>
        /// Get all leads
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadForViewDto>> GetAll(GetAllLeadsInput input);

        /// <summary>
        /// Get lead for view mode by lead
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetLeadForViewDto> GetLeadForView(int id);

        /// <summary>
        /// Get lead for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadForEditOutput> GetLeadForEdit(EntityDto input);

        /// <summary>
        /// Create or edit lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadDto input);

        /// <summary>
        /// Delete lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get leads to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetLeadsToExcel(GetAllLeadsForExcelInput input);

        /// <summary>
        /// Get Lead Source type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<LeadLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown();

        /// <summary>
        /// Get Lead Status type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<LeadLeadStatusLookupTableDto>> GetAllLeadStatusForTableDropdown();

        /// <summary>
        /// Get Priorities type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<LeadPriorityLookupTableDto>> GetAllPriorityForTableDropdown();

        /// <summary>
        /// This method allows to upload imported leads from an excel file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="leadSourceId"></param>
        /// <param name="assignedUserId"></param>
        /// <returns></returns>
        Task<List<CreateOrEditLeadDto>> ImportLeadsFromFile(byte[] inputFile, int leadSourceId, int assignedUserId);

        Task<FileDto> GetDuplicatedLeadsToExcel(List<LeadDto> leads);


        /// <summary>
        /// Convert Lead in Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ConvertToAccount(ConvertLeadToAccountRequestDto input);

    }
}