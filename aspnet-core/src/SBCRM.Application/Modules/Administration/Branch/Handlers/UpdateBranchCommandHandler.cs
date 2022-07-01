using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Update branch command handler
    /// </summary>
    public class UpdateBranchCommandHandler : SBCRMAppServiceBase, IRequestHandler<UpdateBranchCommand, BranchForEditDto>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        public UpdateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Update branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchForEditDto> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetAsync(command.Id);
            ObjectMapper.Map(command, branch);
            await _branchRepository.UpdateAsync(branch);
            return ObjectMapper.Map<BranchForEditDto>(branch);
        }
    }

}
