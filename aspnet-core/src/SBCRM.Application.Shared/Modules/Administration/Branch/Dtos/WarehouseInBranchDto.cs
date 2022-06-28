using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for Default Warehouse dropdown
    /// </summary>
    public class WarehouseInBranchDto
    {
        public long Id { get; set; }
        public string Warehouse { get; set; }
    }
}
