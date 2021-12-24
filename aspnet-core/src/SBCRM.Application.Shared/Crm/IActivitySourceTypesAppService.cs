using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service interface for handling CRUD operations of Activity Source Types
    /// </summary>
    public interface IActivitySourceTypesAppService : IApplicationService
    {
        /// <summary>
        /// Get all activity source types
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetActivitySourceTypeForViewDto>> GetAll(GetAllActivitySourceTypesInput input);

        /// <summary>
        /// Get an activity source type for viewing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetActivitySourceTypeForViewDto> GetActivitySourceTypeForView(int id);

        /// <summary>
        /// Get activity source type for editing
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetActivitySourceTypeForEditOutput> GetActivitySourceTypeForEdit(EntityDto input);

        /// <summary>
        /// Create or edit an activity source type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditActivitySourceTypeDto input);

        /// <summary>
        /// Delete an activity source type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}