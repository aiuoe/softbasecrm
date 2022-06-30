using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
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

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="chartOfAccountRepository"></param>
        /// <param name="warehouseRepository"></param>
        /// <param name="taxRepository"></param>
        /// <param name="currencyTypeRepository"></param>
        public GetBranchInitialDataQueryHandler(IBranchRepository branchRepository,
            IChartOfAccountRepository chartOfAccountRepository,
            IWarehouseRepository warehouseRepository,
            ITaxRepository taxRepository,
            ICurrencyTypeRepository currencyTypeRepository)
        {
            _branchRepository = branchRepository;
            _chartOfAccountRepository = chartOfAccountRepository;
            _warehouseRepository = warehouseRepository;
            _taxRepository = taxRepository;
            _currencyTypeRepository = currencyTypeRepository;
        }

        /// <summary>
        /// Handles request for getting initial values for branch dropdowns
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetBranchInitialDataDto> Handle(GetBranchInitialDataQuery query, CancellationToken cancellationToken)
        {
            //var branch = new Core.BaseEntities.Branch
            //{
            //    Name = command.Name,
            //    Number = command.Number,
            //    SubName = command.SubName,
            //    Address = command.Address
            //};
            //SetTenant(branch);
            //branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            //return new GetBranchForEditDto
            //{
            //    AdditionalPropertyA = "A",
            //    AdditionalPropertyB = "B",
            //    Branch = ObjectMapper.Map<BranchDto>(branch)
            //};
            var branches = await _branchRepository.GetAllListAsync();
            branches= branches.OrderBy(branch=>branch.Number).ToList();
            var arAccounts = await _chartOfAccountRepository.GetAllListAsync(account=> (bool)account.AccountsRecievable);
            arAccounts=arAccounts.OrderBy(arAccounts=>arAccounts.AccountNo).ToList();
            var warehouses = await _warehouseRepository.GetAllListAsync();
            warehouses=warehouses.OrderByDescending(w=>w.ServiceVan).ThenByDescending(w=>w.Consignment).ThenBy(w=>w.Warehouse1).ToList();
            var currencyTypes = await _currencyTypeRepository.GetAllListAsync();
            currencyTypes=currencyTypes.OrderBy(c=>c.CurrencyTypeName).ToList();
            var taxCodes = await _taxRepository.GetAllListAsync();
            taxCodes = taxCodes.OrderBy(t => t.Code).ToList();

            var branchDtoList = ObjectMapper.Map<List<BranchLookupDto>>(branches);
            var arAccountDtoList = ObjectMapper.Map<List<AccountReceivableInBranchDto>>(arAccounts);
            var warehouseDtoList = ObjectMapper.Map<List<WarehouseLookupDto>>(warehouses);
            var currencyTypeDtoList = ObjectMapper.Map<List<CurrencyTypeLookupDto>>(currencyTypes);
            var taxCodeDtoList = ObjectMapper.Map<List<TaxCodeInBranchDto>>(taxCodes);

            var brancheDtoResponse = new GetBranchInitialDataDto();
            brancheDtoResponse.Branches = branchDtoList;
            brancheDtoResponse.AccountsReceivables = arAccountDtoList;
            brancheDtoResponse.Warehouses = warehouseDtoList;
            brancheDtoResponse.CurrencyTypes = currencyTypeDtoList;
            brancheDtoResponse.TaxCodes = taxCodeDtoList;

            return brancheDtoResponse;
        }
    }

}
