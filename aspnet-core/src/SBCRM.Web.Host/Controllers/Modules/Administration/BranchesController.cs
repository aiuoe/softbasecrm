﻿using System.Collections.Generic;
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
        /// Get branch details by branch id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<GetBranchDetailsDto> Get([FromRoute] long id)
        {
            return await _mediator.Send(new GetBranchByIdQuery(id));
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

        /// <summary>
        /// Get credit card account no details
        /// </summary>
        /// <param name="accountNo"></param>
        /// <returns></returns>
        [Route("{accountNo}")]
        [HttpGet]
        public async Task<GetChartOfAccountDetailsDto> GetCreditCardAccountDetails(string accountNo)
        {
            return await _mediator.Send(new GetCreditCardAccountQuery(accountNo));
        }

        /// <summary>
        /// Get zip code details
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        [Route("{zipCode}")]
        [HttpGet]
        public async Task<GetChartOfAccountDetailsDto> GetZipCodeDetails(string zipCode)
        {
            return await _mediator.Send(new GetCreditCardAccountQuery(accountNo));
        }
    }
}
