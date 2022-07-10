using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Dtos;
using SBCRM.Modules.Common.GetBranches.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.GetBranches.Handlers
{
    /// <summary>
    /// Used to handle query branch by Branch number
    /// </summary>
    public class GetBranchesByNoQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchesByNoQuery, BranchForDepartmentDto>
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchesByNoQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BranchForDepartmentDto> Handle(GetBranchesByNoQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllListAsync(b => b.Number == request.Number);

            return ObjectMapper.Map<BranchForDepartmentDto>(branches.FirstOrDefault());
        }
    }
}
