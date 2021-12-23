using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle opportunityies types information
    /// </summary>
    public interface IOpportunityTypesAppService : IApplicationService
    {
        /// <summary>
        /// Get all opportunity types
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetOpportunityTypeForViewDto>> GetAll(GetAllOpportunityTypesInput input);

        /// <summary>
        /// Get opportunity type for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOpportunityTypeForViewDto> GetOpportunityTypeForView(int id);

        /// <summary>
        /// Get opportunity type for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetOpportunityTypeForEditOutput> GetOpportunityTypeForEdit(EntityDto input);

        /// <summary>
        /// Create or edit opportunity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditOpportunityTypeDto input);

        /// <summary>
        /// Delete opportunity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}