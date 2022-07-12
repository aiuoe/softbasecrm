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
    public class GetBranchesByNoCommandHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchesByNoCommand, List<GetBranchDto>>
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchesByNoCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<GetBranchDto>> Handle(GetBranchesByNoCommand request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllListAsync(b => b.Number == request.Number);

            return ObjectMapper.Map(branches, new List<GetBranchDto>());
        }
    }
}
