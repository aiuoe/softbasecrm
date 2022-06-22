using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;

namespace SBCRM.Modules.Administration
{
    /// <summary>
    /// Branches app service
    /// </summary>
    public interface IBranchesAppService : IApplicationService
    {
        /// <summary>
        /// Retrieve all branches
        /// </summary>
        /// <returns></returns>
        Task<IList<GetLeadForViewDto>> GetAll();

        /// <summary>
        /// Retrieve paged branches
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadForViewDto>> GetAllPaged();

        /// <summary>
        /// Retrieve branch by id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadForEditOutput> Get(EntityDto<long> input);

        /// <summary>
        /// Create branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadForEditOutput> Insert(CreateOrEditLeadDto input);

        /// <summary>
        /// Update branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadForEditOutput> Update(CreateOrEditLeadDto input);

        /// <summary>
        /// Delete branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);
    }
}