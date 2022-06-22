using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Crm.Dtos;
using SBCRM.Modules.Administration;

namespace SBCRM.Web.Controllers.Modules.Administration
{
    /// <summary>
    /// Branches controller
    /// </summary>
    [AbpMvcAuthorize]
    public class BranchesController : SBERPControllerBase
    {
        private readonly IBranchesAppService _branchesAppService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchesAppService"></param>
        public BranchesController(IBranchesAppService branchesAppService)
        {
            _branchesAppService = branchesAppService;
        }


        /// <summary>
        /// Retrieve all branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<GetLeadForViewDto>> GetAll()
        {
            return await _branchesAppService.GetAll();
        }

        /// <summary>
        /// Retrieve paged branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<GetLeadForViewDto>> GetAllPaged()
        {
            return await _branchesAppService.GetAllPaged();
        }

        /// <summary>
        /// Retrieve branch by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<GetLeadForEditOutput> Get([FromRoute] long id)
        {
            return await _branchesAppService.Get(new EntityDto<long>(id));
        }

        /// <summary>
        /// Create branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<GetLeadForEditOutput> Insert([FromBody] CreateOrEditLeadDto input)
        {
            return await _branchesAppService.Insert(input);
        }

        /// <summary>
        /// Update branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<GetLeadForEditOutput> Update([FromBody] CreateOrEditLeadDto input)
        {
            return await _branchesAppService.Update(input);
        }

        /// <summary>
        /// Delete branch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public async Task Delete([FromRoute] long id)
        {
            await _branchesAppService.Delete(new EntityDto<long>(id));
        }

    }
}
