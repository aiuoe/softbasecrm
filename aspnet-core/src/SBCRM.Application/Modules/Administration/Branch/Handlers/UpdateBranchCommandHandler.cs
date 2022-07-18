using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Blob;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Update branch command handler
    /// </summary>
    public class UpdateBranchCommandHandler : UseCaseServiceBase, IRequestHandler<UpdateBranchCommand, UpsertBranchDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly IStateTaxCodeRepository _stateTaxCodeRepository;
        private readonly ILocalTaxCodeRepository _localTaxCodeRepository;
        private readonly ICityTaxCodeRepository _cityTaxCodeRepository;
        private readonly ICountyTaxCodeRepository _countyTaxCodeRepository;
        private readonly IApplicationStorageService _applicationStorageService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="warehouseRepository"></param>
        /// <param name="taxRepository"></param>
        /// <param name="stateTaxCodeRepository"></param>
        /// <param name="localTaxCodeRepository"></param>
        /// <param name="cityTaxCodeRepository"></param>
        /// <param name="countyTaxCodeRepository"></param>
        /// <param name="applicationStorageService"></param>
        public UpdateBranchCommandHandler(
            IBranchRepository branchRepository,
            IWarehouseRepository warehouseRepository,
            ITaxRepository taxRepository,
            IStateTaxCodeRepository stateTaxCodeRepository,
            ILocalTaxCodeRepository localTaxCodeRepository,
            ICityTaxCodeRepository cityTaxCodeRepository,
            ICountyTaxCodeRepository countyTaxCodeRepository,
            IApplicationStorageService applicationStorageService)
        {
            _branchRepository = branchRepository;
            _warehouseRepository = warehouseRepository;
            _taxRepository = taxRepository;
            _stateTaxCodeRepository = stateTaxCodeRepository;
            _localTaxCodeRepository = localTaxCodeRepository;
            _cityTaxCodeRepository = cityTaxCodeRepository;
            _countyTaxCodeRepository = countyTaxCodeRepository;
            _applicationStorageService = applicationStorageService;
        }

        /// <summary>
        /// Update branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpsertBranchDto> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetAsync(command.Id);
            ObjectMapper.Map(command, branch);

            if (command.BinaryLogoFile is not null)
            {
                branch.Image = await _applicationStorageService.UploadBlobFile("Branches", command.BinaryLogoFile, command.LogoFile, command.FileType);
            }

            await _branchRepository.UpdateAsync(branch);
            return ObjectMapper.Map<UpsertBranchDto>(branch);
        }
    }

}
