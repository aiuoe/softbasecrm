namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the country object filters to export excel
    /// </summary>
    public class GetAllCountriesForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string CodeFilter { get; set; }

    }
}