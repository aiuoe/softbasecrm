using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle lead sources information
    /// </summary>
    public interface ILeadSourcesAppService : IApplicationService
    {
        /// <summary>
        /// Get all lead sources
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadSourceForViewDto>> GetAll(GetAllLeadSourcesInput input);

        /// <summary>
        /// Get lead source for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetLeadSourceForViewDto> GetLeadSourceForView(int id);

        /// <summary>
        /// Get lead source for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadSourceForEditOutput> GetLeadSourceForEdit(EntityDto input);

        /// <summary>
        /// Create or edit lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadSourceDto input);

        /// <summary>
        /// Delete lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get leads sources to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetLeadSourcesToExcel(GetAllLeadSourcesForExcelInput input);

    }
}