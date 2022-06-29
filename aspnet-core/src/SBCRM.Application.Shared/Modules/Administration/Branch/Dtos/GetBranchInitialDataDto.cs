using SBCRM.Modules.Administration.Branch.Dtos;
using System.Collections.Generic;

namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// DTO for fetching initial data for Branch sub module
    /// </summary>
    public class GetBranchInitialDataDto
    {
        public List<BranchLookupDto> Branches { get; set; }
        public List<AccountReceivableInBranchDto> AccountsReceivables { get; set; }
        public List<WarehouseLookupDto> Warehouses { get; set; }
        public List<CurrencyTypeLookupDto> CurrencyTypes { get; set; }
        public List<TaxCodeInBranchDto> TaxCodes { get; set; }
    }
}
