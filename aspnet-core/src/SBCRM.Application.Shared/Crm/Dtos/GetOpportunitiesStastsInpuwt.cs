using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    public class AverageSalesOutput
    {
        public int AverageSales { get; set; }
    }
    public class CloseRateOutput
    {
        public int CloseRate { get; set; }
    }

    public class AverageDealSizeOutput
    {
        public int AverageSales { get; set; }
    }

    public class TotalClosedSalesOutput
    {
        public int TotalClosedSales { get; set; }
    }

    public class GetOpportunitiesStastsOutput
    {
        public List<int> OpportunitiesId { get; set; }
        public int AverageSales { get; set; }
        public int CloseRate { get; set; }
        public int AverageDealSize { get; set; }
        public int TotalClosedSales { get; set; }
    }
    //public class GetOpportunitiesStastsOutput
    //{
    //    public List<int> OpportunitiesId { get; set; }
    //    public AverageSalesOutput AverageSales { get; set; }
    //    public CloseRateOutput CloseRate { get; set; }
    //    public AverageDealSizeOutput AverageDealSize { get; set; }
    //    public TotalClosedSalesOutput TotalClosedSales { get; set; }
    //}
}
