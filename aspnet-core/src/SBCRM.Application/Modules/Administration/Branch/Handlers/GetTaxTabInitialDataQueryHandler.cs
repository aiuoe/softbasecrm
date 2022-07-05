using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get initial tax tab data query handler
    /// </summary>
    public class GetTaxTabInitialDataQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetTaxTabInitialDataQuery, GetTaxTabInitialDataDto>
    {
        private readonly ICountyTaxCodeRepository _countyTaxCodeRepository;
        private readonly IStateTaxCodeRepository _stateTaxCodeRepository;
        private readonly ICityTaxCodeRepository _cityTaxCodeRepository;
        private readonly ILocalTaxCodeRepository _localTaxCodeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="countyTaxCodeRepository"></param>
        /// <param name="stateTaxCodeRepository"></param>
        /// <param name="cityTaxCodeRepository"></param>
        /// <param name="localTaxCodeRepository"></param>
        public GetTaxTabInitialDataQueryHandler(
            ICountyTaxCodeRepository countyTaxCodeRepository,
            IStateTaxCodeRepository stateTaxCodeRepository,
            ICityTaxCodeRepository cityTaxCodeRepository,
            ILocalTaxCodeRepository localTaxCodeRepository)
        {
            _countyTaxCodeRepository = countyTaxCodeRepository;
            _stateTaxCodeRepository = stateTaxCodeRepository;
            _cityTaxCodeRepository = cityTaxCodeRepository;
            _localTaxCodeRepository = localTaxCodeRepository;
        }

        /// <summary>
        /// Handles request for getting initial data for tax tab dropdowns in branch module
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetTaxTabInitialDataDto> Handle(GetTaxTabInitialDataQuery query, CancellationToken cancellationToken)
        {
            var stateTaxCodes = await _stateTaxCodeRepository.GetAllListAsync();
            stateTaxCodes = stateTaxCodes.OrderBy(stc => stc.TaxCode).ToList();
            var cityTaxCodes = await _cityTaxCodeRepository.GetAllListAsync();
            cityTaxCodes = cityTaxCodes.OrderBy(ctc => ctc.TaxCode).ToList();
            var localTaxCodes = await _localTaxCodeRepository.GetAllListAsync();
            localTaxCodes = localTaxCodes.OrderBy(ltc => ltc.TaxCode).ToList();
            var countyTaxCodes = await _countyTaxCodeRepository.GetAllListAsync();
            countyTaxCodes = countyTaxCodes.OrderBy(ctc => ctc.TaxCode).ToList();

            return new GetTaxTabInitialDataDto()
            {
                StateTaxCodes = ObjectMapper.Map<List<StateTaxCodeInBranchDto>>(stateTaxCodes),
                LocalTaxCodes = ObjectMapper.Map<List<LocalTaxCodeInBranchDto>>(localTaxCodes),
                CountyTaxCodes = ObjectMapper.Map<List<CountyTaxCodeInBranchDto>>(countyTaxCodes),
                CityTaxCodes = ObjectMapper.Map<List<CityTaxCodeInBranchDto>>(cityTaxCodes)
            };
        }
    }
}
