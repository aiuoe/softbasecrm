using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Authorization;
using SBCRM.Modules.Administration.Company.Queries;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Web.Controllers.Modules.Administration
{

    [AbpMvcAuthorize]
    [AbpAuthorize(AppPermissions.Pages_Branches)]
    public class CompaniesController : SBERPControllerBase
    {
        private readonly IMediator _mediator;


        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get company all data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GetCompanyDto>> GetCompaniesData()
        {
            var response = await _mediator.Send(new GetCompanyQuery());
            return response;
        }
    }
}
