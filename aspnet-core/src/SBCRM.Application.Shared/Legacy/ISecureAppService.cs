using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Secure entity repository interface
    /// </summary>
    public interface ISecureAppService : IApplicationService
    {

        /// <summary>
        /// Gets all the secure records and applies filters if needed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetSecureForViewDto>> GetAll(GetAllSecureInput input);

        /// <summary>
        /// Getts a record to be edited
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetSecureForEditOutput> GetSecureForEdit(EntityDto input);

        /// <summary>
        /// Creates or edits a secure record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>ns></returns>
        Task CreateOrEdit(CreateOrEditSecureDto input);

        /// <summary>
        /// Deletes a secure record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}