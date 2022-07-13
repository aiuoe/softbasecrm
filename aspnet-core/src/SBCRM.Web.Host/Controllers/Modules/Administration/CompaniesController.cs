using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Avalara;
using SBCRM.Base;
using SBCRM.Dto;
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
            return await _mediator.Send(new GetZipCodeQuery(zipCode));
        }


        /// <summary>
        /// Get verified address from avalara
        /// </summary>
        /// <param name="address"></param>
        /// <returns>verified address</returns>
        [HttpPost]
        public async Task<GetVerifyAddressDto> GetVerifyAddress([FromBody] GetVerifyAddressInputDto address )
        {
            var getVerifyAddressQuery = ObjectMapper.Map<GetVerifyAddressQuery>(address);
            return await _mediator.Send(getVerifyAddressQuery);
        }





    }
}
