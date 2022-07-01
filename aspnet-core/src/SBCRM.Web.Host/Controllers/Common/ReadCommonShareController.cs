using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Authorization;
using SBCRM.Modules.Accounting.ChartOfAccounts.Queries;
using SBCRM.Modules.Accounting.Dtos;
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

    }
}
