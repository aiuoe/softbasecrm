using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Authorization;
using SBCRM.Core.BaseEntities;
using SBCRM.Legacy.Dtos;
using SBCRM.Modules.Administration.Company.Queries;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Web.Controllers.Modules.Administration
{
    /// <summary>
    /// Company Controller
    /// </summary>
  /*  [AbpMvcAuthorize]
    [AbpAuthorize(AppPermissions.Pages_Companies)]*/
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

        /// <summary>
        /// Get City & State using ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns>City & State of the zip code</returns>
        [HttpGet("{zipCode}")]
        public async Task<List<GetZipCodeDto>> GetZipCodeInfo(string zipCode)
        {
            var response = await _mediator.Send(new GetZipCodeQuery(zipCode));
            return response;
        }





    }
}
