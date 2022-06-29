using MediatR;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Administration.Company.Queries;
using SBCRM.Modules.Administration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Company.Handlers
{
    public class GetZipCodeQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetZipCodeQuery, List<GetZipCodeDto>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetZipCodeQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        /// <summary>
        /// Get State & City of the requested zipCode
        /// </summary>
        /// <param name="request">Contains _zipCode to return State & City </param>
        /// <param name="cancellationToken"></param>
        /// <returns>Filtered search result using _zipCode</returns>
        public async Task<List<GetZipCodeDto>> Handle(GetZipCodeQuery request, CancellationToken cancellationToken)
        {
            var zipCodeInfo = await _companyRepository.GetZipCode(request._zipCode);
            var result = ObjectMapper.Map<List<GetZipCodeDto>>(zipCodeInfo);
            return result;
        }



    }
}
