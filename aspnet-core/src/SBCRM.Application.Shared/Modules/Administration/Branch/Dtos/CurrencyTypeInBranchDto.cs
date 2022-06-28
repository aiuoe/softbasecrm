using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for CurrencyTypes dropdown
    /// </summary>
    public class CurrencyTypeInBranchDto
    {
        public long Id { get; set; }
        public string CurrencyType { get; set; }
    }
}
