using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for Country Tax Code dropdown
    /// </summary>
    public class CountryTaxCodeInBranchDto
    {
        public long Id { get; set; }
        public string CountryTaxCodes { get; set; }
    }
}
