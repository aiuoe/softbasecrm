using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using Abp.UI;
using MediatR;
using SBCRM.Base;
using SBCRM.Common;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch command handler
    /// </summary>
    public class CreateBranchCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateBranchCommand, BranchForEditDto>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="branchRepository"></param>
        public CreateBranchCommandHandler(
            IUnitOfWorkManager unitOfWorkManager,
            IBranchRepository branchRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
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
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var branchWithSameNumber = await _branchRepository.FirstOrDefaultAsync(x => x.Number == command.Number);
                GuardHelper.ThrowIf(branchWithSameNumber != null, new UserFriendlyException(L("BranchNumberUnique")));
            }

            var branch = ObjectMapper.Map<Core.BaseEntities.Branch>(command);
            SetTenant(branch);

            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            return ObjectMapper.Map<BranchForEditDto>(branch);
        }
    }

}
