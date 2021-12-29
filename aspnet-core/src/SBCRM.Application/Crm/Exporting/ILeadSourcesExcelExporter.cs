using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Interfaces that contains methods for export of data to excel
    /// </summary>
    public interface ILeadSourcesExcelExporter
    {
        /// <summary>
        /// Method that export data to excel
        /// </summary>
        /// <param name="leadSources"></param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetLeadSourceForViewDto> leadSources);
    }
}