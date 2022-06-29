using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get Credit card account data by accountno query handler
    /// </summary>
    public class GetCreditCardAccountQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetCreditCardAccountQuery, GetChartOfAccountDetailsDto>
    {
        private readonly IChartOfAccountRepository _chartOfAccountRepository;


        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="chartOfAccountRepository"></param>
        public GetCreditCardAccountQueryHandler(IChartOfAccountRepository chartOfAccountRepository)
        {
            _chartOfAccountRepository = chartOfAccountRepository;
        }


        /// <summary>
        /// Handles request for getting credit card account details data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetChartOfAccountDetailsDto> Handle(GetCreditCardAccountQuery query, CancellationToken cancellationToken)
        {
            var chartOfAccount= await _chartOfAccountRepository.FirstOrDefaultAsync(account=>account.AccountNo==query.AccountNo);
            return ObjectMapper.Map<GetChartOfAccountDetailsDto>(chartOfAccount);
        }
    }
}
