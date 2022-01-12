using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object filters to export excel
    /// </summary>
    public class GetAllOpportunitiesDashboardForExcelInput
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string[] Account { get; set; }

        public short[] Branches { get; set; }

        public short[] Departments { get; set; }
    }
}