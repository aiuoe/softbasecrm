namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Opportunity stats dashboard output
    /// </summary>
    public class GetOpportunitiesStastsOutput
    {
        public double AverageSales { get; set; }
        public double CloseRate { get; set; }
        public int AverageDealSize { get; set; }
        public int TotalClosedSales { get; set; }
    }
}
