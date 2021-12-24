using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle opportunity stage information
    /// </summary>
    public interface IOpportunityStagesAppService : IApplicationService
    {
        /// <summary>
        /// Get all opportunity stages
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetOpportunityStageForViewDto>> GetAll(GetAllOpportunityStagesInput input);

        /// <summary>
        /// Get opportunity stage for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOpportunityStageForViewDto> GetOpportunityStageForView(int id);

        /// <summary>
        /// Get opportunity stage for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetOpportunityStageForEditOutput> GetOpportunityStageForEdit(EntityDto input);

        /// <summary>
        /// Create or edit opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditOpportunityStageDto input);

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateOrder(List<UpdateOrderOpportunityStageDto> input);

        /// <summary>
        /// Delete opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Method that gets the rows to export to Excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetOpportunityStagesToExcel(GetAllOpportunityStagesForExcelInput input);
    }
}