using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle Account Types information
    /// </summary>
    public interface IAccountTypesAppService : IApplicationService
    {
        /// <summary>
        /// Get all account types without paging
        /// </summary>
        /// <returns></returns>
        Task<List<GetAccountTypeForViewDto>> GetAllWithoutPaging();

        /// <summary>
        /// Get all account types
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetAccountTypeForViewDto>> GetAll(GetAllAccountTypesInput input);

        /// <summary>
        /// Get account type for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetAccountTypeForEditOutput> GetAccountTypeForEdit(EntityDto input);

        /// <summary>
        /// Create or Edit account type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditAccountTypeDto input);

        /// <summary>
        /// Delete account type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}