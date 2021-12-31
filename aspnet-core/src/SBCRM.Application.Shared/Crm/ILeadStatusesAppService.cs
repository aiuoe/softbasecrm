using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Interface that contains the methods for manage lead status module
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
        /// Get lead statusfor view mode
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
        /// Delete a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateOrder(List<UpdateOrderLeadStatusDto> input);
    }
}