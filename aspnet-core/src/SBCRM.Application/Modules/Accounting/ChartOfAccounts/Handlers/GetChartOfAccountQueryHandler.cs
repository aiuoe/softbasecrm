using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Accounting.ChartOfAccounts.Queries;
using SBCRM.Modules.Accounting.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Accounting.ChartOfAccounts.Handlers
{
    /// <summary>
    /// Get Credit card account data by accountno query handler
    /// </summary>
    public class GetChartOfAccountQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetChartOfAccountQuery, GetChartOfAccountDetailsDto>
    {
        private readonly IChartOfAccountRepository _chartOfAccountRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="chartOfAccountRepository"></param>
        public GetChartOfAccountQueryHandler(IChartOfAccountRepository chartOfAccountRepository)
        {
            _chartOfAccountRepository = chartOfAccountRepository;
        }

        /// <summary>
        /// Handles request for getting credit card account details data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetChartOfAccountDetailsDto> Handle(GetChartOfAccountQuery query, CancellationToken cancellationToken)
        {
            var chartOfAccount = await _chartOfAccountRepository.FirstOrDefaultAsync(account => account.AccountNo == query.AccountNo);
            return ObjectMapper.Map<GetChartOfAccountDetailsDto>(chartOfAccount);
        }
    }
}
