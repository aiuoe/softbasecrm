using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using Abp.UI;
using MediatR;
using SBCRM.Base;
using SBCRM.Blob;
using SBCRM.Common;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch command handler
    /// </summary>
    public class CreateBranchCommandHandler : UseCaseServiceBase, IRequestHandler<CreateBranchCommand, UpsertBranchDto>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IBranchRepository _branchRepository;
        private readonly IApplicationStorageService _applicationStorageService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="branchRepository"></param>
        /// <param name="applicationStorageService"></param>
        public CreateBranchCommandHandler(
            IUnitOfWorkManager unitOfWorkManager,
            IBranchRepository branchRepository,
            IApplicationStorageService applicationStorageService)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _branchRepository = branchRepository;
            _applicationStorageService = applicationStorageService;
        }

        /// <summary>
        /// Create branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpsertBranchDto> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var branchWithSameNumber = await _branchRepository.FirstOrDefaultAsync(x => x.Number == command.Number);
                GuardHelper.ThrowIf(branchWithSameNumber != null, new UserFriendlyException(L("BranchNumberUnique")));
            }

            var branch = ObjectMapper.Map<Core.BaseEntities.Branch>(command);
            if (command.BinaryLogoFile is not null)
            {
                branch.Image = await _applicationStorageService.UploadBlobFile($"branches/{command.Number}", command.BinaryLogoFile, command.LogoFile, command.FileType);
            }

            //SetTenant(branch);
            branch.TenantId = 1;

            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            return ObjectMapper.Map<UpsertBranchDto>(branch);
        }
    }

}
