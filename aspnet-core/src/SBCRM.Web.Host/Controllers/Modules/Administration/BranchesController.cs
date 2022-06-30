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

namespace SBCRM.Web.Controllers.Modules.Administration
{
    /// <summary>
    /// Branches controller
    /// </summary>
    //[AbpMvcAuthorize]
    //[AbpAuthorize(AppPermissions.Pages_Branches)]
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
        public async Task<BranchForEditDto> Create([FromBody] CreateBranchCommand input)
        {
            return await _mediator.Send(input);
        }

        /// <summary>
        /// Update branch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <see cref="UpdateBranchCommandHandler"/>
        /// <returns></returns>
        [Route("{id}")]
        [HttpPut]
        public async Task<BranchForEditDto> Update(
            [FromRoute] long id,
            [FromBody] UpdateBranchCommand input)
        {
            input.Id = id;
            return await _mediator.Send(input);
        }

        /// <summary>
        /// Delete branch
        /// </summary>
        /// <param name="id"></param>
        /// <see cref="DeleteBranchCommandHandler"/>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public async Task Delete([FromRoute] long id)
        {
            var input = new DeleteBranchCommand()
            {
                BranchId = id,
            };
            await _mediator.Send(input);
        }

        /// <summary>
        /// Retrieve branch currency type information by branch id and currency type id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currencyTypeId"></param>
        /// <see cref="GetBranchCurrencyTypeQueryHandler"/>
        /// <returns></returns>
        [Route("{id}/CurrencyType/{currencyTypeId}")]
        [HttpGet]
        public async Task<BranchCurrencyTypeDto> GetBranchCurrencyType(
            [FromRoute] long id,
            [FromRoute] long currencyTypeId)
        {
            var input = new GetBranchCurrencyTypeQuery()
            {
                BranchId = id,
                CurrencyTypeId = currencyTypeId,
            };
            return await _mediator.Send(input);
        }

        /// <summary>
        /// Patch branch currency type information by branch id and currency type id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currencyTypeId"></param>
        /// <param name="input"></param>
        /// <see cref="PatchBranchCurrencyTypeCommandHandler"/>
        /// <returns></returns>
        [Route("{id}/CurrencyType/{currencyTypeId}")]
        [HttpPatch]
        public async Task<BranchCurrencyTypeDto> PatchBranchCurrencyType(
            [FromRoute] long id,
            [FromRoute] long currencyTypeId, 
            [FromBody] PatchBranchCurrencyTypeCommand input)
        {
            input.BranchId = id;
            input.CurrencyTypeId = currencyTypeId;
            return await _mediator.Send(input);
        }

        /// <summary>
        /// Get initial dropdowns
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetBranchInitialDataDto> GetInitialData()
        {
            return await _mediator.Send(new GetBranchInitialDataQuery());
            
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
