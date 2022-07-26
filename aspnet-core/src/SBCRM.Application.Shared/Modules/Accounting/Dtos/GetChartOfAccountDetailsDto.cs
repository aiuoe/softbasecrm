namespace SBCRM.Modules.Accounting.Dtos
{
    /// <summary>
    /// DTO for fetching ChartOfAccount details
    /// </summary>
    public class GetChartOfAccountDetailsDto
    {
        public long Id { get; set; }
        public string AccountNo { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
