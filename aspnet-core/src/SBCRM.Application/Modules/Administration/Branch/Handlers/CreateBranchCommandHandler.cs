using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using Abp.UI;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Common;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch command handler
    /// </summary>
    public class CreateBranchCommandHandler : UseCaseServiceBase, IRequestHandler<CreateBranchCommand, BranchForEditDto>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IBranchRepository _branchRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly IStateTaxCodeRepository _stateTaxCodeRepository;
        private readonly ILocalTaxCodeRepository _localTaxCodeRepository;
        private readonly ICityTaxCodeRepository _cityTaxCodeRepository;
        private readonly ICountyTaxCodeRepository _countyTaxCodeRepository;

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
        public CreateBranchCommandHandler(
            IUnitOfWorkManager unitOfWorkManager,
            IBranchRepository branchRepository,
            IWarehouseRepository warehouseRepository,
            ITaxRepository taxRepository,
            IStateTaxCodeRepository stateTaxCodeRepository,
            ILocalTaxCodeRepository localTaxCodeRepository,
            ICityTaxCodeRepository cityTaxCodeRepository,
            ICountyTaxCodeRepository countyTaxCodeRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _branchRepository = branchRepository;
            _warehouseRepository = warehouseRepository;
            _taxRepository = taxRepository;
            _stateTaxCodeRepository = stateTaxCodeRepository;
            _localTaxCodeRepository = localTaxCodeRepository;
            _cityTaxCodeRepository = cityTaxCodeRepository;
            _countyTaxCodeRepository = countyTaxCodeRepository;
        }

        /// <summary>
        /// Create branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchForEditDto> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            //TO:DO generating number for now. will change based on client decision.
            command.Number = await _branchRepository.GetAll().MaxAsync(x => x.Number);
            command.Number++;

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
            branch.DefaultWarehouse = warehouse?.WarehouseName;
            branch.TaxCode = taxCode?.Code;
            branch.StateTaxCode = stateTaxCode?.TaxCode;
            branch.LocalTaxCode = localTaxCode?.TaxCode;
            branch.CityTaxCode = cityTaxCode?.TaxCode;
            branch.CountyTaxCode = countyTaxCode?.TaxCode;

            //SetTenant(branch);
            branch.TenantId = 1;

            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            var branchForEditDto = ObjectMapper.Map<BranchForEditDto>(branch);

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
