using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle priorities information
    /// </summary>
    public interface IPrioritiesAppService : IApplicationService
    {
        /// <summary>
        /// Get all priorities
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetPriorityForViewDto>> GetAll(GetAllPrioritiesInput input);

        /// <summary>
        /// Get priority for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetPriorityForViewDto> GetPriorityForView(int id);

        /// <summary>
        /// Get priority for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPriorityForEditOutput> GetPriorityForEdit(EntityDto input);

        /// <summary>
        /// Create or edit priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditPriorityDto input);

        /// <summary>
        /// Delete priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get priorities to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetPrioritiesToExcel(GetAllPrioritiesForExcelInput input);

    }
}