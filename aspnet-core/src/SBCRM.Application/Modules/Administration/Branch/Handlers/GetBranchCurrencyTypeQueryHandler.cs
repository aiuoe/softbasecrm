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
        private readonly IBranchARCurrencyTypeRepository _branchARCurrencyTypeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchARCurrencyTypeRepository"></param>
        public GetBranchCurrencyTypeQueryHandler(IBranchARCurrencyTypeRepository branchARCurrencyTypeRepository)
        {
            _branchARCurrencyTypeRepository = branchARCurrencyTypeRepository;
        }

        /// <summary>
        /// Get branch currency type
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchCurrencyTypeDto> Handle(GetBranchCurrencyTypeQuery query, CancellationToken cancellationToken)
        {
            var branchCurrencyType = await _branchARCurrencyTypeRepository.FirstOrDefaultAsync(x => x.Branch == query.Branch && x.CurrencyType == query.CurrencyType);
            return ObjectMapper.Map<BranchCurrencyTypeDto>(branchCurrencyType);
        }
    }

}
