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
using SBCRM.Modules.Common.GetBranches.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Web.Controllers.Common
{
    /// <summary>
    /// ReadCommonShareController controller
    /// </summary>
    [AbpMvcAuthorize]
    [AbpAuthorize(AppPermissions.Pages_ReadCommonShare)]
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
        public async Task<List<GetAdditionalChargeDto>> GetAdditionalChargesByBranchAndDepartment([FromRoute] int branchNo, [FromRoute] int departmentNo)
        {
            return await _mediator.Send(new GetAdditionalChargesByBranchAndDepartmentCommand(branchNo,departmentNo));
        }


        /// API to Get Branch details (Name & Subname) by Branch #.  <summary>
        /// </summary>
        /// <returns></returns>
        [Route("{branchNo}")]
        [HttpGet]
        public async Task<List<GetBranchDto>> GetBranchesByNo([FromRoute] short branchNo)
        {
            return await _mediator.Send(new GetBranchesByNoCommand(branchNo));
        }
    }
}
