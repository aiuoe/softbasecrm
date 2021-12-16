using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Countries Excel exporter
    /// </summary>
    public interface ICountriesExcelExporter
    {
        /// <summary>
        /// Export countries to file
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetCountryForViewDto> countries);
    }
}