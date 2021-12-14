using System.Collections.Generic;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy.Exporting
{
    /// <summary>
    /// Customer Excel exporter
    /// </summary>
    public interface ICustomerExcelExporter
    {
        /// <summary>
        /// Export customers to file
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetCustomerForViewDto> customer);
    }
}