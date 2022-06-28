using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Queries;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get branch currency type query handler
    /// </summary>
    public class GetBranchCurrencyTypeQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchCurrencyTypeQuery, GetBranchCurrencyTypeDto>
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
        public async Task<GetBranchCurrencyTypeDto> Handle(GetBranchCurrencyTypeQuery query, CancellationToken cancellationToken)
        {
            var branchCurrencyType = await _branchARCurrencyTypeRepository.FirstOrDefaultAsync(x => x.Branch == query.BranchId && x.Id == query.CurrencyTypeId);
            return ObjectMapper.Map<GetBranchCurrencyTypeDto>(branchCurrencyType);
        }
    }

}
