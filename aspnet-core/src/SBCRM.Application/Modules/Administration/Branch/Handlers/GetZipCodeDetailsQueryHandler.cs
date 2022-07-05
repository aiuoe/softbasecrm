using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get zip code details query handler
    /// </summary>
    public class GetZipCodeDetailsQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetZipCodeDetailsQuery, GetZipCodeDetailsDto>
    {
        private readonly IZipCodeRepository _zipCodeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="zipCodeRepository"></param>
        public GetZipCodeDetailsQueryHandler(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        /// <summary>
        /// Handles query for getting zip code details
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetZipCodeDetailsDto> Handle(GetZipCodeDetailsQuery query, CancellationToken cancellationToken)
        {
            var zipCode = await _zipCodeRepository.FirstOrDefaultAsync(zc => zc.ZipCode1 == query.ZipCode);
            return ObjectMapper.Map<GetZipCodeDetailsDto>(zipCode);
        }
    }
}
