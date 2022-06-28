using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch use case command handler
    /// </summary>
    public class CreateBranchCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateBranchCommand, GetBranchForEditDto>
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
        public async Task<GetBranchForEditDto> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            var branch = new Core.BaseEntities.Branch
            {
                Name = command.Name,
                Number = command.Number,
                SubName = command.SubName,
                Address = command.Address
            };
            SetTenant(branch);
            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            return new GetBranchForEditDto
            {
                AdditionalPropertyA = "A",
                AdditionalPropertyB = "B",
                Branch = ObjectMapper.Map<BranchDto>(branch)
            };
        }
    }

}
