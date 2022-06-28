using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    public class GetValuesForDropdownsInTaxSetupBanchDto
    {
        public List<StateTaxCodeInBranchDto> StateTaxCodes { get; set; }
        public List<CountryTaxCodeInBranchDto> CountryTaxCodes { get; set; }
        public List<CityTaxCodeInBranchDto> CityTaxCodes { get; set; }
        public List<LocalTaxCodeInBranchDto> LocalTaxCodes { get; set; }
    }
}
