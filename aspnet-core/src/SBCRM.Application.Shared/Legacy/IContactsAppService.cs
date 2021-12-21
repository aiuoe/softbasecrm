using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Contacts information
    /// </summary>
    public interface IContactsAppService : IApplicationService
    {
        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetContactForViewDto>> GetAll(GetAllContactsInput input);

        /// <summary>
        /// Get contact for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetContactForEditOutput> GetContactForEdit(EntityDto input);

        /// <summary>
        /// Create or edit contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditContactDto input);

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}