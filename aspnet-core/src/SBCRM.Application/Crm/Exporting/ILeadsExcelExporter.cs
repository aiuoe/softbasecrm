using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Interface that implements methods to return a list of leads on excel format
    /// </summary>
    public interface ILeadsExcelExporter
    {
        /// <summary>
        /// Exports a list of leads
        /// </summary>
        /// <param name="leads"></param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetLeadForViewDto> leads);

        /// <summary>
        /// Exports an excel file with duplicated leads when importing leads
        /// </summary>
        /// <param name="leads"></param>
        /// <returns></returns>
        FileDto ExportDuplicatedLeadsToExcel(List<LeadDto> leads);
    }
}