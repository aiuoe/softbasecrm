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
    public class GetBranchByIdQueryHandler : UseCaseServiceBase, IRequestHandler<GetBranchByIdQuery, BranchForEditDto>
    {
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
        /// <param name="branchRepository"></param>
        /// <param name="warehouseRepository"></param>
        /// <param name="taxRepository"></param>
        /// <param name="stateTaxCodeRepository"></param>
        /// <param name="localTaxCodeRepository"></param>
        /// <param name="cityTaxCodeRepository"></param>
        /// <param name="countyTaxCodeRepository"></param>
        public GetBranchByIdQueryHandler(
            IBranchRepository branchRepository,
            IWarehouseRepository warehouseRepository,
            ITaxRepository taxRepository,
            IStateTaxCodeRepository stateTaxCodeRepository,
            ILocalTaxCodeRepository localTaxCodeRepository,
            ICityTaxCodeRepository cityTaxCodeRepository,
            ICountyTaxCodeRepository countyTaxCodeRepository)
        {
            _branchRepository = branchRepository;
            _warehouseRepository = warehouseRepository;
            _taxRepository = taxRepository;
            _stateTaxCodeRepository = stateTaxCodeRepository;
            _localTaxCodeRepository = localTaxCodeRepository;
            _cityTaxCodeRepository = cityTaxCodeRepository;
            _countyTaxCodeRepository = countyTaxCodeRepository;
        }

        /// <summary>
        /// Handles request for getting branch details data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchForEditDto> Handle(GetBranchByIdQuery query, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetAsync(query.Id);
            var warehouse = await _warehouseRepository.FirstOrDefaultAsync(warehouse => warehouse.WarehouseName == branch.DefaultWarehouse);
            var taxCode = await _taxRepository.FirstOrDefaultAsync(tax => tax.Code == branch.TaxCode);
            var stateTaxCode = await _stateTaxCodeRepository.FirstOrDefaultAsync(stateTaxCode => stateTaxCode.TaxCode == branch.StateTaxCode);
            var localTaxCode = await _localTaxCodeRepository.FirstOrDefaultAsync(localTaxCode => localTaxCode.TaxCode == branch.LocalTaxCode);
            var countyTaxCode = await _countyTaxCodeRepository.FirstOrDefaultAsync(countyTaxCode => countyTaxCode.TaxCode == branch.CountyTaxCode);
            var cityTaxCode = await _cityTaxCodeRepository.FirstOrDefaultAsync(cityTaxCode => cityTaxCode.TaxCode == branch.CityTaxCode);

            var branchForEditDto= ObjectMapper.Map<BranchForEditDto>(branch);

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
