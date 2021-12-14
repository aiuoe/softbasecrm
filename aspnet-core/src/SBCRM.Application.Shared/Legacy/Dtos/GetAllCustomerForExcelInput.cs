using System.Collections.Generic;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object filters to export excel
    /// </summary>
    public class GetAllCustomerForExcelInput
    {
        public string Filter { get; set; }
        public List<int?> AccountTypeId { get; set; } = new List<int?>();
    }
}