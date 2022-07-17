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
        /// <param name="unitOfWorkManager"></param>
        /// <param name="branchRepository"></param>
        /// <param name="warehouseRepository"></param>
        /// <param name="taxRepository"></param>
        /// <param name="stateTaxCodeRepository"></param>
        /// <param name="localTaxCodeRepository"></param>
        /// <param name="cityTaxCodeRepository"></param>
        /// <param name="countyTaxCodeRepository"></param>
        /// <param name="applicationStorageService"></param>
        public CreateBranchCommandHandler(
            IUnitOfWorkManager unitOfWorkManager,
            IBranchRepository branchRepository,
            IWarehouseRepository warehouseRepository,
            ITaxRepository taxRepository,
            IStateTaxCodeRepository stateTaxCodeRepository,
            ILocalTaxCodeRepository localTaxCodeRepository,
            ICityTaxCodeRepository cityTaxCodeRepository,
            ICountyTaxCodeRepository countyTaxCodeRepository,
            IApplicationStorageService applicationStorageService)
        {
            _unitOfWorkManager = unitOfWorkManager;
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
            
            var warehouse = await _warehouseRepository.FirstOrDefaultAsync(x => x.Id == command.DefaultWarehouseId);
            var taxCode = await _taxRepository.FirstOrDefaultAsync(x => x.Id == command.TaxCodeId);
            var stateTaxCode = await _stateTaxCodeRepository.FirstOrDefaultAsync(x => x.Id == command.StateTaxCodeId);
            var localTaxCode = await _localTaxCodeRepository.FirstOrDefaultAsync(x => x.Id == command.LocalTaxCodeId);
            var cityTaxCode = await _cityTaxCodeRepository.FirstOrDefaultAsync(x => x.Id == command.CityTaxCodeId);
            var countyTaxCode = await _countyTaxCodeRepository.FirstOrDefaultAsync(x => x.Id == command.CountyTaxCodeId);

            var branch = ObjectMapper.Map<Core.BaseEntities.Branch>(command);
            if (command.BinaryLogoFile is not null)
            {
                branch.Image = await _applicationStorageService.UploadBlobFile($"branches/{command.Number}", command.BinaryLogoFile, command.LogoFile, command.FileType);
            }
            branch.DefaultWarehouse = warehouse?.WarehouseName;
            branch.TaxCode = taxCode?.Code;
            branch.StateTaxCode = stateTaxCode?.TaxCode;
            branch.LocalTaxCode = localTaxCode?.TaxCode;
            branch.CityTaxCode = cityTaxCode?.TaxCode;
            branch.CountyTaxCode = countyTaxCode?.TaxCode;

            //SetTenant(branch);
            branch.TenantId = 1;

            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            var branchForEditDto = ObjectMapper.Map<UpsertBranchDto>(branch);

            branchForEditDto.DefaultWarehouseId = warehouse?.Id;
            branchForEditDto.TaxCodeId = taxCode?.Id;
            branchForEditDto.StateTaxCodeId = stateTaxCode?.Id;
            branchForEditDto.LocalTaxCodeId = localTaxCode?.Id;
            branchForEditDto.CountyTaxCodeId = countyTaxCode?.Id;
            branchForEditDto.CityTaxCodeId = cityTaxCode?.Id;

            return branchForEditDto;
        }
    }

}
