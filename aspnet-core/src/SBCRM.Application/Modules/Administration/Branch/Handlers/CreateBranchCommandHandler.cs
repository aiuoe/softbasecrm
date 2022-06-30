using System.Threading;
using System.Threading.Tasks;
using Abp.UI;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch command handler
    /// </summary>
    public class CreateBranchCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateBranchCommand, BranchForEditDto>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        public CreateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Create branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchForEditDto> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            var branchWithSameNumber = await _branchRepository.FirstOrDefaultAsync(x => x.Number == command.Number);
            if (branchWithSameNumber != null)
            {
                throw new UserFriendlyException("BranchNumberUnique");
            }

            var branch = ObjectMapper.Map<Core.BaseEntities.Branch>(command);
            SetTenant(branch);

            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            return ObjectMapper.Map<BranchForEditDto>(branch);
        }
    }

}
