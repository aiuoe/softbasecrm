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
    public class GetAllBranchesQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetAllBranchesQuery, List<BranchForDepartmentDto>>
    {
        private readonly IBranchRepository _branchRepository;

        public GetAllBranchesQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<BranchForDepartmentDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllListAsync();

            return ObjectMapper.Map(branches, new List<BranchForDepartmentDto>());
        }
    }
}
