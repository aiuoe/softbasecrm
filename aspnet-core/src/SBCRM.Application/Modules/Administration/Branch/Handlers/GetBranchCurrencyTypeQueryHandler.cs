using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Queries;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get branch currency type query handler
    /// </summary>
    public class GetBranchCurrencyTypeQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchCurrencyTypeQuery, BranchCurrencyTypeDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IBranchARCurrencyTypeRepository _branchARCurrencyTypeRepository;
        private readonly ICurrencyTypeRepository _currencyTypeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="branchARCurrencyTypeRepository"></param>
        /// <param name="currencyTypeRepository"></param>
        public GetBranchCurrencyTypeQueryHandler(
            IBranchRepository branchRepository,
            IBranchARCurrencyTypeRepository branchARCurrencyTypeRepository,
            ICurrencyTypeRepository currencyTypeRepository)
        {
            _branchRepository = branchRepository;
            _branchARCurrencyTypeRepository = branchARCurrencyTypeRepository;
            _currencyTypeRepository = currencyTypeRepository;
        }

        /// <summary>
        /// Get branch currency type
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchCurrencyTypeDto> Handle(GetBranchCurrencyTypeQuery query, CancellationToken cancellationToken)
        {
            var branchTask = _branchRepository.FirstOrDefaultAsync(x => x.Id == query.BranchId);
            var currencyTypeTask = _currencyTypeRepository.FirstOrDefaultAsync(x => x.Id == query.CurrencyTypeId);
            await Task.WhenAll(branchTask, currencyTypeTask);
            var branchCurrencyType = await _branchARCurrencyTypeRepository.FirstOrDefaultAsync(x => x.Branch == branchTask.Result.Number && x.CurrencyType == currencyTypeTask.Result.CurrencyTypeName);
            return ObjectMapper.Map<BranchCurrencyTypeDto>(branchCurrencyType);
        }
    }
}
