using SBCRM.Modules.Administration.Branch.Dtos;
using System.Collections.Generic;

namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// DTO for fetching initial data for Branch sub module
    /// </summary>
    public class GetInitialValuesForBranchDropdownDto
    {
        public List<BranchesDto> Branches { get; set; }
        public List<ARAccountsInBranchDto> ARAccounts { get; set; }
        public List<WarehouseInBranchDto> Warehouses { get; set; }
        public List<CurrencyTypeInBranchDto> CurrencyTypes { get; set; }
        public List<TaxCodeInBranchDto> TaxCodes { get; set; }
    }
}




