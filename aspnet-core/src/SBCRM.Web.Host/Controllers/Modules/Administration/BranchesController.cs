using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Authorization;
using SBCRM.Crm.Dtos;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Handlers;
using SBCRM.Modules.Administration.Branch.Queries;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Web.Controllers.Modules.Administration
{
    /// <summary>
    /// Branches controller
    /// </summary>
/*    [AbpMvcAuthorize]
    [AbpAuthorize(AppPermissions.Pages_Branches)]*/
    public class BranchesController : SBERPControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="mediator"></param>
        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Retrieve all branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<GetLeadForViewDto>> GetAll()
        {
            return await Task.FromResult(new List<GetLeadForViewDto>());
        }

        /// <summary>
        /// Retrieve paged branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<GetLeadForViewDto>> GetAllPaged()
        {
            return await Task.FromResult(new PagedResultDto<GetLeadForViewDto>());
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
            return await Task.FromResult(new GetLeadForEditOutput());
        }

        /// <summary>
        /// Create branch
        /// </summary>
        /// <param name="input"></param>
        /// <see cref="CreateBranchCommandHandler"/>
        /// <returns></returns>
        [HttpPost]
        public async Task<GetBranchForEditDto> Create([FromBody] CreateBranchCommand input)
        {
            return await _mediator.Send(input);
        }

        /// <summary>
        /// Update branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<GetLeadForEditOutput> Update([FromBody] CreateOrEditLeadDto input)
        {
            return await Task.FromResult(new GetLeadForEditOutput());
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
        }

        /// <summary>
        /// Get initial values for dropdowns
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetInitialValuesForBranchDropdownDto> GetInitialValuesForDropdown()
        {
            return await _mediator.Send(new GetInitialValuesBranchDropdownQuery());
            
        }
        /// <summary>
        /// Get initial values for dropdowns in Tax Setup tabs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetTaxTabInitialDataDto> GetTaxTabInitialData()
        {
            return await _mediator.Send(new GetTaxTabInitialDataQuery());
        }
    }
}
