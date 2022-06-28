using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Modules.Administration.Comapny.Queries;

namespace SBCRM.Web.Controllers.Modules.Administration
{

    [AbpMvcAuthorize]
    //[AbpAuthorize(AppPermissions.Pages_Companies)]
    public class CompaniesController : SBERPControllerBase
    {
        private readonly IMediator _mediator;


        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompaniesData()
        {
            var products = await _mediator.Send(new GetCompanyQuery());
            return Ok(products);
        }


    }
}
