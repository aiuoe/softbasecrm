using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface ILeadUsersAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadUserForViewDto>> GetAll(GetAllLeadUsersInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetLeadUserForEditOutput> GetLeadUserForEdit(EntityDto input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadUserDto input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<LeadUserLeadLookupTableDto>> GetAllLeadForTableDropdown();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<LeadUserUserLookupTableDto>> GetAllUserForTableDropdown();

        /// <summary>
        /// This method save a list of users connected with an specific Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateMultipleLeadUsers(List<CreateOrEditLeadUserDto> input);

    }
}