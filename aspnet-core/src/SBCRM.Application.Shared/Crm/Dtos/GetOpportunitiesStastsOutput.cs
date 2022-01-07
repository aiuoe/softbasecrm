using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Opportunity stats dashboard output
    /// </summary>
    public class GetOpportunitiesStastsOutput
    {
        public int AverageSales { get; set; }
        public int CloseRate { get; set; }
        public int AverageDealSize { get; set; }
        public int TotalClosedSales { get; set; }
    }
}
