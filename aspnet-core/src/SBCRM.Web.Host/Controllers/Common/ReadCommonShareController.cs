using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Authorization;
using SBCRM.Modules.Accounting.ChartOfAccounts.Queries;
using SBCRM.Modules.Accounting.Dtos;
using SBCRM.Modules.Administration.Dtos;
using SBCRM.Modules.Common.AdditionalCharges.Commands;
using SBCRM.Modules.Common.AdditionalCharges.Dto;
using SBCRM.Modules.Common.ApCheckFormats.Dto;
using SBCRM.Modules.Common.ApCheckFormats.Queries;
using SBCRM.Modules.Common.ARTerms.Dto;
using SBCRM.Modules.Common.ARTerms.Queries;
using SBCRM.Modules.Common.Avalara.Dto;
using SBCRM.Modules.Common.Avalara.Handlers;
using SBCRM.Modules.Common.Avalara.Queries;
using SBCRM.Modules.Common.GetBranches.Commands;
using SBCRM.Modules.Common.SalesTaxIntegration.Dto;
using SBCRM.Modules.Common.SalesTaxIntegration.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Web.Controllers.Common
{
    /// <summary>
    /// ReadCommonShareController controller
    /// </summary>
    //[AbpMvcAuthorize]
    //[AbpAuthorize(AppPermissions.Pages_ReadCommonShare)]
    public class ReadCommonShareController : SBERPControllerBase
    {
        private readonly IMediator _mediator;

        public ReadCommonShareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve ChartOfAccount by AccountNo
        /// </summary>
        /// <param name="branchNo"></param>
        /// <returns></returns>
        [Route("{accountNo}")]
        [HttpGet]
        public async Task<GetChartOfAccountDetailsDto> GetChartOfAccountByAcNo([FromRoute] string accountNo)
        {
            return await _mediator.Send(new GetChartOfAccountQuery(accountNo.Trim()));
        }

        [HttpPost]
        public async Task<CreatedAdditionalChargeResponseDto> CreateAdditionalCharge([FromBody] AdditionalChargeDto input)
        {
            return await _mediator.Send(new CreateAdditionalChargesCommand(input));
        }

        [Route("{additionalChargeId}")]
        [HttpPatch]
        public async Task<Unit> UpdateAdditionalCharge([FromBody] AdditionalChargeDto input, [FromRoute] long additionalChargeId)
        {
            return await _mediator.Send(new UpdateAdditionalChargesCommand(input, additionalChargeId));
        }

        [Route("{additionalChargeId}")]
        [HttpDelete]
        public async Task<Unit> DeleteAdditionalCharge([FromRoute] long additionalChargeId)
        {
            return await _mediator.Send(new DeleteAdditionalChargesCommand(additionalChargeId));
        }

        /// <summary>
        /// Retrieve AdditionalCharges by branch & Dept #
        /// </summary>
        /// <param name="branchNo"></param>
        /// <returns></returns>
        [Route("{branchNo}/{departmentNo}")]
        [HttpGet]
        public async Task<List<AdditionalChargeDto>> GetAdditionalChargesByBranchAndDepartment([FromRoute] int branchNo, [FromRoute] int departmentNo)
        {
            return await _mediator.Send(new GetAdditionalChargesByBranchAndDepartmentCommand(branchNo,departmentNo));
        }


        /// API to Get List of Branch details (Name & Subname)  <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<BranchForDepartmentDto>> GetAllBranches()
        {
            return await _mediator.Send(new GetAllBranchesQuery());
        }

        [HttpGet]
        public async Task<SalesTaxIntegrationDto> GetSalesTaxIntegration()
        {
            return await _mediator.Send(new SalesTaxIntegrationQuery());
        }

        [HttpGet]
        public async Task<List<ARTermDto>> GetARTerms()
        {
            return await _mediator.Send(new ARTermsQuery());
        }

        /// <summary>
        /// Api to get the ApCheckFormats (Grouped by Format Name)
        /// </summary>
        /// <returns>List of ApCheckFormats</returns>
        [HttpGet]
        public async Task<List<ApCheckFormatDto>> GetApCheckFormats()
        {
            return await _mediator.Send(new ApCheckFormatsQuery());
        }

        /// <summary>
        /// Get verified address from avalara
        /// </summary>
        /// <param name="address"></param>
        /// <returns>verified address</returns>
        [HttpPost]
        public async Task<GetVerifyAddressDto> GetVerifyAddress([FromBody] GetVerifyAddressInputDto address)
        {
            var getVerifyAddressQuery = ObjectMapper.Map<GetVerifyAddressQuery>(address);
            return await _mediator.Send(getVerifyAddressQuery);
        }

        #region Avalara Connection

        /// <summary>
        /// Api to get Tax Codes List
        /// </summary>
        /// <param name="taxCodeType">Type of Tax Code (Single Letter)</param>
        /// <param name="taxCode">Partial Tax Code</param>
        /// <param name="parentTaxCode">Parent Tax Code</param>
        /// <param name="description">Partial Description</param>
        /// <returns>Tax Code List</returns>
        /// <see cref="GetTaxCodesQueryHandler"/>
        [Route("{skip}/{max?}/{taxCodeType?}/{taxCode?}/{parentTaxCode?}/{description?}")]
        [HttpGet]
        public async Task<PagedResultDto<TaxCodeDto>> GetTaxCodes([FromRoute] int skip, [FromRoute] int max = 10,[FromRoute] string taxCodeType = "", [FromRoute] string taxCode = "", [FromRoute] string parentTaxCode = "", [FromRoute] string description = "")
        {
            return await _mediator.Send(new GetTaxCodesQuery(skip,max,taxCodeType,taxCode,parentTaxCode,description));
        }

        /// <summary>
        /// Api to get the Tax Code Types List
        /// </summary>
        /// <returns>Tax Code Types List</returns>
        /// <see cref="GetTaxCodeTypesQueryHandler"/>
        [HttpGet]
        public async Task<List<TaxCodeTypeDto>> GetTaxCodeTypes()
        {
            return await _mediator.Send(new GetTaxCodeTypesQuery());
        }

        #endregion
    }
}
