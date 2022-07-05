using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Company.Queries;
using SBCRM.Modules.Administration.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Company.Handlers
{
    /// <summary>
    /// Get Zip Code Query Handler
    /// </summary>
    public class GetZipCodeQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetZipCodeQuery, List<GetZipCodeDto>>
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="zipCodeRepository"></param>
        public GetZipCodeQueryHandler(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }


        /// <summary>
        /// Get State & City of the requested zipCode
        /// </summary>
        /// <param name="request">Contains _zipCode to return State & City </param>
        /// <param name="cancellationToken"></param>
        /// <returns>Filtered search result using _zipCode</returns>
        public async Task<List<GetZipCodeDto>> Handle(GetZipCodeQuery request, CancellationToken cancellationToken)
        {
            var zipCodeInfo = await _zipCodeRepository.GetZipCode(request.ZipCode);
            return ObjectMapper.Map<List<GetZipCodeDto>>(zipCodeInfo); ;
        }

       



    }
}
