using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Crm;
using SBCRM.Crm.Dtos;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch use case command handler
    /// </summary>
    public class GetBranchInitialDataQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchInitialDataQuery, GetBranchInitialDataDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IChartOfAccountRepository _chartOfAccountRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly ICurrencyTypeRepository _currencyTypeRepository;
        private readonly IRepository<Country> _countryRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="chartOfAccountRepository"></param>
        /// <param name="warehouseRepository"></param>
        /// <param name="taxRepository"></param>
        /// <param name="currencyTypeRepository"></param>
        /// <param name="countryRepository"></param>
        public GetBranchInitialDataQueryHandler(
            IBranchRepository branchRepository,
            IChartOfAccountRepository chartOfAccountRepository,
            IWarehouseRepository warehouseRepository,
            ITaxRepository taxRepository,
            ICurrencyTypeRepository currencyTypeRepository,
            IRepository<Country> countryRepository)
        {
            _branchRepository = branchRepository;
            _chartOfAccountRepository = chartOfAccountRepository;
            _warehouseRepository = warehouseRepository;
            _taxRepository = taxRepository;
            _currencyTypeRepository = currencyTypeRepository;
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Handles request for getting initial values for branch dropdowns
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetBranchInitialDataDto> Handle(GetBranchInitialDataQuery query, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllListAsync();
            branches = branches.OrderBy(branch => branch.Number).ToList();
            var arAccounts = await _chartOfAccountRepository.GetAllListAsync(account => (bool)account.AccountsRecievable);
            arAccounts = arAccounts.OrderBy(arAccounts => arAccounts.AccountNo).ToList();
            var warehouses = await _warehouseRepository.GetAllListAsync();
            warehouses = warehouses.OrderByDescending(w => w.ServiceVan).ThenByDescending(w => w.Consignment).ThenBy(w => w.WarehouseName).ToList();
            var currencyTypes = await _currencyTypeRepository.GetAllListAsync();
            currencyTypes = currencyTypes.OrderBy(c => c.CurrencyTypeName).ToList();
            var taxCodes = await _taxRepository.GetAllListAsync();
            taxCodes = taxCodes.OrderBy(t => t.Code).ToList();
            var countries = await _countryRepository.GetAll().ToListAsync();
            countries = countries.OrderBy(t => t.Code).ToList();

            return new GetBranchInitialDataDto()
            {
                Branches = ObjectMapper.Map<List<BranchLookupDto>>(branches),
                AccountsReceivables = ObjectMapper.Map<List<AccountReceivableInBranchDto>>(arAccounts),
                Warehouses = ObjectMapper.Map<List<WarehouseLookupDto>>(warehouses),
                TvhWarehouses = GetTvhWarehouses(),
                CurrencyTypes = ObjectMapper.Map<List<CurrencyTypeLookupDto>>(currencyTypes),
                TaxCodes = ObjectMapper.Map<List<TaxCodeInBranchDto>>(taxCodes),
                Countries = ObjectMapper.Map<List<CountryDto>>(countries),
            };
        }

        private List<TvhWarehouseLookupDto> GetTvhWarehouses()
        {
            return new List<TvhWarehouseLookupDto>()
            {
                new TvhWarehouseLookupDto() { Key = "0", Name = "All, US" },
                new TvhWarehouseLookupDto() { Key = "1", Name = "Kansas, US" },
                new TvhWarehouseLookupDto() { Key = "2", Name = "California, US" },
                new TvhWarehouseLookupDto() { Key = "3", Name = "Oregon, US" },
                new TvhWarehouseLookupDto() { Key = "5", Name = "South Carolina, US" },
                new TvhWarehouseLookupDto() { Key = "6", Name = "Pennsylvania, US" },
                new TvhWarehouseLookupDto() { Key = "7", Name = "Illinois, US" },
                new TvhWarehouseLookupDto() { Key = "8", Name = "Lousiana, US" },
                new TvhWarehouseLookupDto() { Key = "9", Name = "Florida, US" },
                new TvhWarehouseLookupDto() { Key = "21", Name = "Ontario, Canada" },
                new TvhWarehouseLookupDto() { Key = "22", Name = "British Columbia, Canada" },
                new TvhWarehouseLookupDto() { Key = "51", Name = "Mexico City, Mexico" },
                new TvhWarehouseLookupDto() { Key = "52", Name = "Monterrey, Mexico" },
            };
        }
    }

}
