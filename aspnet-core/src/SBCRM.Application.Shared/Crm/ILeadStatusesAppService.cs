using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle lead status information
    /// </summary>
    public interface ILeadStatusesAppService : IApplicationService
    {
        /// <summary>
        /// Get all lead statuses
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadStatusForViewDto>> GetAll(GetAllLeadStatusesInput input);

        /// <summary>
        /// Get lead status for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetLeadStatusForViewDto> GetLeadStatusForView(int id);

        /// <summary>
        /// Get lead status for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadStatusForEditOutput> GetLeadStatusForEdit(EntityDto input);

        /// <summary>
        /// Create or edit lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadStatusDto input);

        /// <summary>
        /// Get leads statuses to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}