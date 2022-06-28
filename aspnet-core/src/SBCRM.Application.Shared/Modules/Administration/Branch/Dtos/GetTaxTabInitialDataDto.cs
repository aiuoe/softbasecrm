using System.Collections.Generic;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for fetching initial data for tax tab in branch sub module
    /// </summary>
    public class GetTaxTabInitialDataDto
    {
        public List<StateTaxCodeInBranchDto> StateTaxCodes { get; set; }
        public List<CountryTaxCodeInBranchDto> CountryTaxCodes { get; set; }
        public List<CityTaxCodeInBranchDto> CityTaxCodes { get; set; }
        public List<LocalTaxCodeInBranchDto> LocalTaxCodes { get; set; }
    }
}
