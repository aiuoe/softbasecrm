using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Delete branch command handler
    /// </summary>
    public class DeleteBranchCommandHandler : SBCRMAppServiceBase, IRequestHandler<DeleteBranchCommand>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        public DeleteBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Delete branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.FirstOrDefaultAsync(x => x.Id == command.BranchId);
            if (branch != null)
            {
                await _branchRepository.DeleteAsync(branch);
            }
            return Unit.Value;
        }
    }
}
