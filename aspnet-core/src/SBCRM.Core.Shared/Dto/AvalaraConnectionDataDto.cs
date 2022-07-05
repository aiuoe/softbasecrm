namespace SBCRM.Dto
{
    /// <summary>
    /// Dto to provide avalara connection data
    /// </summary>
    public class AvalaraConnectionDataDto
    {
        public string SalesTaxProvider { get; set; }
        public string AccountNumber { get; set; }
        public string LicenseKey { get; set; }
        public string ServiceUrl { get; set; }
        public int RequestTimeout { get; set; }
    }
}
