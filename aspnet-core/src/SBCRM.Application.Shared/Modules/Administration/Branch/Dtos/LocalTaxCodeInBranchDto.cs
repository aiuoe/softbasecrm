using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for Local Tax Code dropdown
    /// </summary>
    public class LocalTaxCodeInBranchDto
    {
        public long Id { get; set; }
        public string LocalTaxCodes { get; set; }
    }
}
