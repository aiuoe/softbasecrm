using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Modules.Accounting.ChartOfAccounts.Handlers;
using SBCRM.Modules.Accounting.ChartOfAccounts.Queries;
using SBCRM.Modules.Accounting.Dtos;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Handlers;
using SBCRM.Modules.Administration.Branch.Queries;
using SBCRM.Web.Common;
using SBCRM.Web.Dto.Modules.Administration;

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
        public async Task<List<BranchListItemDto>> GetAll()
        {
            return await Task.FromResult(new List<BranchListItemDto>());
        }

        /// <summary>
        /// Retrieve paged branches
        /// </summary>
        /// <see cref="GetAllPagedBranchQueryHandler"/>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<BranchListItemDto>> GetAllPaged([FromQuery] GetAllPagedBranchQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Get branch details by branch id.
        /// </summary>
        /// <param name="id"></param>
        /// <see cref="GetBranchByIdQueryHandler"/>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<UpsertBranchDto> Get([FromRoute] long id)
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
        [Consumes("multipart/form-data")]
        public async Task<UpsertBranchDto> Create([FromForm] UpsertBranchWrapperDto input)
        {
            var createBranchCommand = ObjectMapper.Map<CreateBranchCommand>(input.UpsertBranchDto);
            createBranchCommand.BinaryLogoFile = await input.File.GetBytes();
            createBranchCommand.FileType = input.File.ContentType;
            createBranchCommand.LogoFile = input.File.FileName;
            return await _mediator.Send(createBranchCommand);
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
        [Consumes("multipart/form-data")]
        public async Task<UpsertBranchDto> Update(
            [FromRoute] long id,
            [FromForm] UpsertBranchWrapperDto input)
        {
            var updateBranchCommand = ObjectMapper.Map<UpdateBranchCommand>(input.UpsertBranchDto);
            updateBranchCommand.Id = id;
            updateBranchCommand.BinaryLogoFile = await input.File.GetBytes();
            updateBranchCommand.FileType = input.File.ContentType;
            updateBranchCommand.LogoFile = input.File.FileName;
            return await _mediator.Send(updateBranchCommand);
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
        [Route("{id}/{currencyTypeId}")]
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
        [Route("{id}/{currencyTypeId}")]
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
        /// <see cref="GetBranchInitialDataQueryHandler"/>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetBranchInitialDataDto> GetInitialData()
        {
            return await _mediator.Send(new GetBranchInitialDataQuery());
        }

        /// <summary>
        /// Get initial values for dropdowns in Tax Setup tabs
        /// </summary>
        /// <see cref="GetTaxTabInitialDataQueryHandler"/>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetTaxTabInitialDataDto> GetTaxTabInitialData()
        {
            return await _mediator.Send(new GetTaxTabInitialDataQuery());
        }

        /// <summary>
        /// Get ChartOfAccount details by account No
        /// </summary>
        /// <param name="accountNo"></param>
        /// <see cref="GetChartOfAccountQueryHandler"/>
        /// <returns></returns>
        [Route("{accountNo}")]
        [HttpGet]
        public async Task<GetChartOfAccountDetailsDto> GetChartOfAccountDetails([FromRoute] string accountNo)
        {
            return await _mediator.Send(new GetChartOfAccountQuery(accountNo));
        }

        /// <summary>
        /// Get zip code details
        /// </summary>
        /// <param name="zipCode"></param>
        /// <see cref="GetZipCodeDetailsQueryHandler"/>
        /// <returns></returns>
        [Route("{zipCode}")]
        [HttpGet]
        public async Task<GetZipCodeDetailsDto> GetZipCodeDetails([FromRoute] string zipCode)
        {
            return await _mediator.Send(new GetZipCodeDetailsQuery(zipCode));
        }
    }
}
