using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Interface for lead source service
    /// </summary>
    public interface ILeadSourcesAppService : IApplicationService
    {
        /// <summary>
        /// Method that get all rows lead sources
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List lead sources</returns>
        Task<PagedResultDto<GetLeadSourceForViewDto>> GetAll(GetAllLeadSourcesInput input);

        /// <summary>
        /// Method that get lead sources for main view by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetLeadSourceForViewDto> GetLeadSourceForView(int id);

        /// <summary>
        /// Get lead sources for edit information
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadSourceForEditOutput> GetLeadSourceForEdit(EntityDto input);

        /// <summary>
        /// Method that create a new lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadSourceDto input);

        /// <summary>
        /// Method that delete a row in database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Method that get all rows lead sources for export to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List lead sources</returns>
        Task<FileDto> GetLeadSourcesToExcel(GetAllLeadSourcesForExcelInput input);

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateOrder(List<UpdateOrderleadSourceDto> input);
    }
}