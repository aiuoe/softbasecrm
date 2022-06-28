using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for Standard Tax Code dropdown
    /// </summary>
    public class TaxCodeInBranchDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
    }
}
