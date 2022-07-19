using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get branch data by id query handler
    /// </summary>
    public class GetBranchByIdQueryHandler : UseCaseServiceBase, IRequestHandler<GetBranchByIdQuery, UpsertBranchDto>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        public GetBranchByIdQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Handles request for getting branch details data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpsertBranchDto> Handle(GetBranchByIdQuery query, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetAsync(query.Id);
            return ObjectMapper.Map<UpsertBranchDto>(branch);
        }
    }
}
